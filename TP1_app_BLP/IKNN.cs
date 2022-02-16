using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP01_HeartDiseaseDiagnostic
{
    internal interface IKNN
    {
        /* main methods */
        void Train(string filename_train_set_csv, int k = 1, string distance = "euclidean"); // or "manhattan"
        float Evaluate(string filename_test_set_csv);
        int Predict(HeartDiagnostic sample);
        /* utils */
        float EuclideanDistance(HeartDiagnostic first_sample, HeartDiagnostic second_sample);
        float ManhattanDistance(HeartDiagnostic first_sample, HeartDiagnostic second_sample);
        int Vote(List<int> sorted_labels);
        List<int> ShellSort(List<float> distances, List<int> labels);
    }
}