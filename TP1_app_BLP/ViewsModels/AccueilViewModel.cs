using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using Microsoft.Win32;
using TP01_HeartDiseaseDiagnostic;

namespace TP1_app_BLP.ViewsModels
{
    public class AccueilViewModel : DoctorEditorViewModel
    {
        private string trainFile;
        private string testFile;
        private float successRate;
        private IKNN knn;
        public int K { get; set; }
        public int Distance { get; set; }
        private bool validForm => !string.IsNullOrWhiteSpace(trainFile) && !string.IsNullOrWhiteSpace(testFile);
        public ICommand TrainCommand { get; private set; }
        public ICommand TestCommand { get; private set; }
        public ICommand EvaluateCommand { get; private set; }

        public string Greeting => $"Bienvenue Dr. {Doctor}";
        public string SuccessRateMessage => $"Taux de reconnaissance : {successRate}%";

        public AccueilViewModel(Doctor doctor) : base(doctor, true)
        {
            TrainCommand = new RelayCommand(() =>
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                bool? result = openFileDialog.ShowDialog();
                if (result.HasValue && result.Value)
                {
                    trainFile = openFileDialog.FileName;
                }
            });
            TestCommand = new RelayCommand(() =>
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                bool? result = openFileDialog.ShowDialog();
                if (result.HasValue && result.Value)
                {
                    testFile = openFileDialog.FileName;
                }
            });
            EvaluateCommand = new RelayCommand(() =>
            {
                knn = new KNN();
                knn.Train(trainFile, K, Distance);
                successRate = knn.Evaluate(testFile);
            }, () => validForm);
        }
    }
}
