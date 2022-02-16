using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP01_HeartDiseaseDiagnostic
{
    public class IKNN
    {
        /* main methods */
        //void Train(string filename_train_set_csv, int k = 1, string distance = "euclidean"); // or "manhattan"
        //float Evaluate(string filename_test_set_csv);
        //int Predict(HeartDiagnostic sample);


        /* utils */
        private static double EuclideanDistance(HeartDiagnostic s1, HeartDiagnostic s2)
        {
            double NormalizedChestPain = s1.NormalizedChestPain - s2.NormalizedChestPain;
            double NormalizedThalassemia = s1.NormalizedThalassemia - s2.NormalizedThalassemia;
            double NormalizedOldPeak = s1.NormalizedOldPeak - s2.NormalizedOldPeak;
            double NormalizedFluoroscopy = s1.NormalizedFluoroscopy - s2.NormalizedFluoroscopy;

            NormalizedChestPain *= NormalizedChestPain;
            NormalizedThalassemia *= NormalizedThalassemia;
            NormalizedOldPeak *= NormalizedOldPeak;
            NormalizedFluoroscopy *= NormalizedFluoroscopy;

            return Math.Sqrt(NormalizedChestPain + NormalizedThalassemia + NormalizedOldPeak + NormalizedFluoroscopy);
        }
        private static double ManhattanDistance(HeartDiagnostic s1, HeartDiagnostic s2)
        {
            double NormalizedChestPain = Math.Abs(s1.NormalizedChestPain - s2.NormalizedChestPain);
            double NormalizedThalassemia = Math.Abs(s1.NormalizedThalassemia - s2.NormalizedThalassemia);
            double NormalizedOldPeak = Math.Abs(s1.NormalizedOldPeak - s2.NormalizedOldPeak);
            double NormalizedFluoroscopy = Math.Abs(s1.NormalizedFluoroscopy - s2.NormalizedFluoroscopy);

            return Math.Sqrt(NormalizedChestPain + NormalizedThalassemia + NormalizedOldPeak + NormalizedFluoroscopy);
        }
        private static int Vote(List<int> sorted_labels)
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
        //List<int> ShellSort(List<float> distances, List<int> labels);
    }
}