using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;
using TP1_app_BLP.Model;

namespace TP01_HeartDiseaseDiagnostic
{
    public class KNN : IKNN
    {
        private List<Diagnostic> heartDiagnostics;
        private int k;
        private Func<Diagnostic, Diagnostic, float> distanceFunction;
        public bool HasBeenTrained => heartDiagnostics != null && heartDiagnostics.Any();

        public void Train(string filename_train_set_csv, int k = 6, int distance = 1)
        {
            this.k = k;

            distanceFunction = distance switch
            {
                0 => ManhattanDistance,
                1 => EuclideanDistance,
                _ => throw new ArgumentException("invalid distance choice"),
            };

            heartDiagnostics = ImportSamples(filename_train_set_csv);
        }

        public float Evaluate(string filename_test_set_csv)
        {
            List<Diagnostic> tests = ImportSamples(filename_test_set_csv);
            float success = 0;
            foreach (Diagnostic heartDiagnostic in tests)
            {
                if (Predict(heartDiagnostic) == heartDiagnostic.Label)
                {
                    success++;
                }
            }
            return success / tests.Count;
        }

        public bool Predict(Diagnostic sample)
        {
            List<float> distances = heartDiagnostics.Select(hd => distanceFunction(hd, sample)).ToList();
            List<bool> labels = heartDiagnostics.Select(hd => hd.Label).ToList();
            ShellSort(distances, labels);

            return Vote(labels.Take(k).ToList());
        }

        public List<Diagnostic> ImportSamples(string filepath)
        {
            using var streamreader = new StreamReader(filepath);
            using var csv = new CsvReader(streamreader, new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                NewLine = Environment.NewLine
            });
            return csv.GetRecords<Diagnostic>().ToList();
        }

        public float ManhattanDistance(Diagnostic s1, Diagnostic s2)
        {
            float total = 0;
            for (int i = 0; i < s1.Features.Length; i++)
            {
                total += MathF.Abs(s1.Features[i] - s2.Features[i]);
            }
            return total;
        }

        public float EuclideanDistance(Diagnostic s1, Diagnostic s2)
        {
            float total = 0;
            for (int i = 0; i < s1.Features.Length; i++)
            {
                total += MathF.Pow(s1.Features[i] - s2.Features[i], 2);
            }
            return MathF.Sqrt(total);
        }

        public bool Vote(List<bool> sorted_labels)
        {
            uint truesTally = 0;
            uint falsesTally = 0;
            foreach (var label in sorted_labels)
            {
                if (label)
                {
                    truesTally++;
                }
                else
                {
                    falsesTally++;
                }
            }
            return truesTally > falsesTally;
        }

        public void ShellSort(List<float> distances, List<bool> labels)
        {
            for (int gap = labels.Count / 2; gap >= 1; gap /= 2)
            {
                for (int i = gap; i < labels.Count; i += gap)
                {
                    float distance = distances[i];
                    bool label = labels[i];
                    int j = i;
                    for (; j >= gap && distances[j - gap] > distance; j -= gap)
                    {
                        distances[j] = distances[j - gap];
                        labels[j] = labels[j - gap];
                    }
                    distances[j] = distance;
                    labels[j] = label;
                }
            }
        }

        public void ConfusionMatrix(List<bool> predicted_labels, List<bool> expert_labels, bool[] labels)
        {
            throw new NotImplementedException();
        }
    }
}