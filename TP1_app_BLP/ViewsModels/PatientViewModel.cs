using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TP01_HeartDiseaseDiagnostic;

namespace TP1_app_BLP.ViewsModels
{
    internal class PatientViewModel
    {
        public List<string> Villes { get; private set; } = new()
        {
            "Rimouski",
            "Lévis",
            "Québec",
            "Montréal",
            "Rivière-du-Loup"
        };
        public bool IsReadOnly { get; private set; }
        public bool IsEnabled => !IsReadOnly;
        public Patient Patient { get; set; }
        public ICommand ValidateDoctorAndCloseWindow { get; private set; }

        public PatientViewModel(Patient patient, bool isReadOnly = false)
        {
            Patient = patient;
            IsReadOnly = isReadOnly;

            ValidateDoctorAndCloseWindow = new RelayCommand<Window>(
                window => window.DialogResult = true,
                window => Patient.IsValid);

        }

     
    }
}
