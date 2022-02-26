using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using TP01_HeartDiseaseDiagnostic;

namespace TP1_app_BLP.ViewsModels
{
    public class DoctorEditorViewModel
    {
        public List<string> Villes { get; private set; } = new()
        {
            "Rimouski",
            "Lévis",
            "Québec",
            "Montréal",
            "Rivière-du-Loup"
        };
        public Doctor Doctor { get; set; }
        public bool IsValid =>
            !string.IsNullOrWhiteSpace(Doctor.FirstName) &&
            !string.IsNullOrWhiteSpace(Doctor.LastName) &&
            !string.IsNullOrWhiteSpace(Doctor.Email) &&
            !string.IsNullOrWhiteSpace(Doctor.Ville);

        public ICommand ValidateDoctorAndCloseWindow => new RelayCommand<Window>(
            window => window.DialogResult = true,
            window => true);

        public DoctorEditorViewModel(Doctor doctor)
        {
            Doctor = doctor;
        }
    }
}
