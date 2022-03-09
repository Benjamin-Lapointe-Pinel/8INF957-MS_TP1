using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TP01_HeartDiseaseDiagnostic;

namespace TP1_app_BLP.ViewsModels
{
    public class PatientViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public List<string> Villes { get; private set; } = new()
        {
            "Rimouski",
            "Lévis",
            "Québec",
            "Montréal",
            "Rivière-du-Loup"
        };
        public string Title => IsReadOnly ? "Informations patient" : "Ajout patient";
        public string DiagnosticMessage => Patient.Diagnostic ? "Résultat : Présence de Maladie" : "Résultat : Absence de Maladie";
        public bool IsReadOnly { get; private set; }
        public bool IsEnabled => !IsReadOnly;
        private Patient _patient;
        public Patient Patient
        {
            get
            {
                return _patient;
            }
            set
            {
                if (_patient != value)
                {
                    _patient = value;
                    OnPropertyChanged();
                }
            }
        }
        public ICommand ValidatePatientAndCloseWindow { get; private set; }

        public PatientViewModel(Patient patient, bool isReadOnly = false)
        {
            Patient = patient;
            IsReadOnly = isReadOnly;

            ValidatePatientAndCloseWindow = new RelayCommand<Window>(
                window =>
                {
                    window.DialogResult = true;
                },
                window =>
                {
                    return Patient.IsValid;
                });

        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
