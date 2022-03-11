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
using TP01_HeartDiseaseDiagnostic;

namespace TP1_app_BLP.ViewsModels
{
    public class DoctorEditorViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

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
        private Doctor _doctor;
        public Doctor Doctor
        {
            get
            {
                return _doctor;
            }
            set
            {
                if (_doctor != value)
                {
                    _doctor = value;
                    OnPropertyChanged();
                }
            }
        }
        public ICommand ValidateDoctorAndCloseWindow { get; private set; }

        public DoctorEditorViewModel(Doctor doctor, bool isReadOnly = false)
        {
            Doctor = doctor;
            IsReadOnly = isReadOnly;
           

        ValidateDoctorAndCloseWindow = new RelayCommand<Window>(
                window =>
                {
                    window.DialogResult = true;
                },
                window =>
                {
                    return Doctor.IsValid;
                });
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
