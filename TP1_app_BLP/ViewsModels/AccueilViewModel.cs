using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using Microsoft.Win32;
using TP01_HeartDiseaseDiagnostic;
using TP1_app_BLP.Views;

namespace TP1_app_BLP.ViewsModels
{
    public class AccueilViewModel : DoctorEditorViewModel
    {
        public List<string> Distances { get; private set; } = new()
        {
            "Manhattan",
            "Euclidienne"
        };
        private string trainFile;
        private string testFile;
        private float _successRate;
        private Doctor backupDoctor;
        private IKNN knn;
        private bool KnnReady => knn == null;
        public int K { get; set; } = 1;
        public int Distance { get; set; }
        private bool configIaFormIsValid =>
            !string.IsNullOrWhiteSpace(trainFile) &&
            !string.IsNullOrWhiteSpace(testFile) &&
            K > 0;
        public ICommand ModifyDoctor { get; private set; }
        public ICommand CancelDoctor { get; private set; }
        public ICommand TrainCommand { get; private set; }
        public ICommand TestCommand { get; private set; }
        public ICommand EvaluateCommand { get; private set; }
        public string Greeting => $"Bienvenue Dr. {Doctor}";
        private string _successRateMessage;
        public string SuccessRateMessage
        {
            get
            {
                return _successRateMessage;
            }
            set
            {
                if (_successRateMessage != value)
                {
                    _successRateMessage = value;
                    OnPropertyChanged();
                }
            }
        }
        public List<Patient> Patients { get; private set; } = new List<Patient>();
        public ICommand InfoPatient { get; private set; }
        public ICommand ComptePatient { get; private set; }
        public Patient SelectedPatient { get; set; }

        public AccueilViewModel(Doctor doctor) : base(doctor)
        {
            backupDoctor = new Doctor(doctor);

            ModifyDoctor = new RelayCommand(() => backupDoctor = new Doctor(Doctor), () => Doctor.IsValid);
            CancelDoctor = new RelayCommand(() => Doctor = new Doctor(backupDoctor));
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
                float successRate = knn.Evaluate(testFile) * 100;
                SuccessRateMessage = $"Taux de reconnaissance : {successRate:F2}%";
            }, () => configIaFormIsValid);
            ComptePatient = new RelayCommand(() =>
            {
                var comptePatient = new ComptePatient();
                bool? result = comptePatient.ShowDialog();
                if (result.HasValue && result.Value)
                {
                    Patients.Add(comptePatient.patientViewModel.Patient);
                }
            });
            InfoPatient = new RelayCommand<Window>(window =>
            {
                var infoPatient = new ComptePatient(SelectedPatient);
                infoPatient.Show();


            });
        }
    }
}
