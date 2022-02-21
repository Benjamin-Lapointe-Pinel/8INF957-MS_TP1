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
        private List<HeartDiagnostic> heartDiagnostics;
        private int k;
        private Func<HeartDiagnostic, HeartDiagnostic, float> distanceFunction;

        public void Train(string filename_train_set_csv, int k = 6, string distance = "euclidean")
        {
            this.k = k;

            this.distanceFunction = distance switch
            {
                "manhattan" => ManhattanDistance,
                "euclidean" => EuclideanDistance,
                _ => throw new ArgumentException("invalid distance choice"),
            };

            this.heartDiagnostics = heartDiagnosticsFromCsv(filename_train_set_csv);
        }

        public float Evaluate(string filename_test_set_csv)
        {
            List<HeartDiagnostic> tests = heartDiagnosticsFromCsv(filename_test_set_csv);
            float success = 0;
            foreach (HeartDiagnostic heartDiagnostic in tests)
            {
                if ((Predict(heartDiagnostic) == 1) == heartDiagnostic.Label)
                {
                    success++;
                }
            }
            return success / tests.Count;
        }

        public int Predict(HeartDiagnostic sample)
        {
            List<float> distances = heartDiagnostics.Select(hd => distanceFunction(hd, sample)).ToList();
            List<int> labels = heartDiagnostics.Select(hd => hd.Label ? 1 : 0).ToList();

            return Vote(ShellSort(distances, labels));
        }

        private static List<HeartDiagnostic> heartDiagnosticsFromCsv(string filepath)
        {
            using var streamreader = new StreamReader(filepath);
            using var csv = new CsvReader(streamreader, new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                NewLine = Environment.NewLine
            });
            return csv.GetRecords<HeartDiagnostic>().ToList();
        }

        public float ManhattanDistance(HeartDiagnostic s1, HeartDiagnostic s2)
        {
            float total = 0;
            for (int i = 0; i < s1.Features.Length; i++)
            {
                total += MathF.Abs(s1.Features[i] - s2.Features[i]);
            }
            return total;
        }

        public float EuclideanDistance(HeartDiagnostic s1, HeartDiagnostic s2)
        {
            float total = 0;
            for (int i = 0; i < s1.Features.Length; i++)
            {
                total += MathF.Pow(s1.Features[i] - s2.Features[i], 2);
            }
            return MathF.Sqrt(total);
        }

        public int Vote(List<int> sorted_labels)
        {
            var labelTally = new Dictionary<int, uint>();
            foreach (var label in sorted_labels.Take(k))
            {
                if (labelTally.ContainsKey(label))
                {
                    labelTally[label]++;
                }
                else
                {
                    labelTally[label] = 0;
                }
            }
            return labelTally.Aggregate((l1, l2) => l1.Value > l2.Value ? l1 : l2).Key;
        }

        public List<int> ShellSort(List<float> distances, List<int> labels)
        {
            var labelsArray = labels.ToArray();
            Array.Sort(distances.ToArray(), labelsArray);
            return labelsArray.ToList();
        }
    }
}