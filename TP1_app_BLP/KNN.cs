using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;

namespace TP01_HeartDiseaseDiagnostic
{
    public class KNN : IKNN
    {
        private List<HeartDiagnostic> heartDiagnostics;
        private int k;
        private Func<HeartDiagnostic, HeartDiagnostic, float> distanceFunction;

        public void Train(string filename_train_set_csv, int k = 5, string distance = "euclidean")
        {
            this.k = k;

            this.distanceFunction = distance switch
            {
                "manhattan" => ManhattanDistance,
                "euclidean" => EuclideanDistance,
                _ => throw new ArgumentException(),
            };

            this.heartDiagnostics = heartDiagnosticsFromCsv(filename_train_set_csv);
        }
        public float Evaluate(string filename_test_set_csv)
        {
            List<HeartDiagnostic> tests = heartDiagnosticsFromCsv(filename_test_set_csv);
            float success = 0;
            foreach (HeartDiagnostic heartDiagnostic in tests)
            {
                if (Predict(heartDiagnostic) == heartDiagnostic.Diagnostic)
                {
                    success++;
                }
            }
            return success / tests.Count;
        }
        public int Predict(HeartDiagnostic sample)
        {
            List<float> distances = heartDiagnostics.Select(hd => distanceFunction(hd, sample)).ToList();
            List<int> labels = heartDiagnostics.Select(hd => (int)hd.Diagnostic).ToList();

            labels = ShellSort(distances, labels);

            return Vote(labels.Take(k).ToList());
        }
        private static List<HeartDiagnostic> heartDiagnosticsFromCsv(string filepath)
        {
            using var streamreader = new StreamReader(filepath);
            using var csv = new CsvReader(streamreader, new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                NewLine = Environment.NewLine,
            });
            return csv.GetRecords<HeartDiagnostic>().ToList();
        }
        public float ManhattanDistance(HeartDiagnostic s1, HeartDiagnostic s2)
        {
            double NormalizedChestPain = Math.Abs(s1.NormalizedChestPain - s2.NormalizedChestPain);
            double NormalizedThalassemia = Math.Abs(s1.NormalizedThalassemia - s2.NormalizedThalassemia);
            double NormalizedOldPeak = Math.Abs(s1.NormalizedOldPeak - s2.NormalizedOldPeak);
            double NormalizedFluoroscopy = Math.Abs(s1.NormalizedFluoroscopy - s2.NormalizedFluoroscopy);

            return (float)Math.Sqrt(NormalizedChestPain + NormalizedThalassemia + NormalizedOldPeak + NormalizedFluoroscopy);
        }
        public float EuclideanDistance(HeartDiagnostic s1, HeartDiagnostic s2)
        {
            double NormalizedChestPain = s1.NormalizedChestPain - s2.NormalizedChestPain;
            double NormalizedThalassemia = s1.NormalizedThalassemia - s2.NormalizedThalassemia;
            double NormalizedOldPeak = s1.NormalizedOldPeak - s2.NormalizedOldPeak;
            double NormalizedFluoroscopy = s1.NormalizedFluoroscopy - s2.NormalizedFluoroscopy;

            NormalizedChestPain *= NormalizedChestPain;
            NormalizedThalassemia *= NormalizedThalassemia;
            NormalizedOldPeak *= NormalizedOldPeak;
            NormalizedFluoroscopy *= NormalizedFluoroscopy;

            return (float)Math.Sqrt(NormalizedChestPain + NormalizedThalassemia + NormalizedOldPeak + NormalizedFluoroscopy);
        }
        public int Vote(List<int> sorted_labels)
        {
            var labelTally = new Dictionary<int, uint>();
            foreach (var label in sorted_labels)
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
            throw new NotImplementedException();
        }
    }
}