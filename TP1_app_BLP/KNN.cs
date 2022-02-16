using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP01_HeartDiseaseDiagnostic
{
    public class KNN : IKNN
    {
        public void Train(string filename_train_set_csv, int k = 1, string distance = "euclidean")
        {
            throw new NotImplementedException();
        }
        public float Evaluate(string filename_test_set_csv)
        {
            throw new NotImplementedException();
        }
        public int Predict(HeartDiagnostic sample)
        {
            throw new NotImplementedException();
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