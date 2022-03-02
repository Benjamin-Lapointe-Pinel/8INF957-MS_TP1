using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using TP01_HeartDiseaseDiagnostic;

namespace TP1_app_BLP.ViewsModels
{
    public class DoctorEditorViewModel
    {
        public List<string> Cities { get; private set; } = new()
        {
            "Rimouski",
            "Lévis",
            "Québec",
            "Montréal",
            "Rivière-du-Loup"
        };
        public bool IsReadOnly { get; private set; }
        public bool IsEnabled => !IsReadOnly;
        public Doctor Doctor { get; set; }
        public ICommand ValidateDoctorAndCloseWindow { get; private set; }

        public DoctorEditorViewModel(Doctor doctor, bool isReadOnly = false)
        {
            Doctor = doctor;
            IsReadOnly = isReadOnly;

            ValidateDoctorAndCloseWindow = new RelayCommand<Window>(
                window => window.DialogResult = true,
                window => Doctor.IsValid);
        }
    }
}
