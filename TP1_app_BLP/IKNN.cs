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
        private double EuclideanDistance(HeartDiagnostic s1, HeartDiagnostic s2)
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
        private double ManhattanDistance(HeartDiagnostic s1, HeartDiagnostic s2) {
            double NormalizedChestPain = Math.Abs(s1.NormalizedChestPain - s2.NormalizedChestPain);
            double NormalizedThalassemia = Math.Abs(s1.NormalizedThalassemia - s2.NormalizedThalassemia);
            double NormalizedOldPeak = Math.Abs(s1.NormalizedOldPeak - s2.NormalizedOldPeak);
            double NormalizedFluoroscopy = Math.Abs(s1.NormalizedFluoroscopy - s2.NormalizedFluoroscopy);

            return Math.Sqrt(NormalizedChestPain + NormalizedThalassemia + NormalizedOldPeak + NormalizedFluoroscopy);
        }
        //int Vote(List<int> sorted_labels);
        //List<int> ShellSort(List<float> distances, List<int> labels);
    }
}