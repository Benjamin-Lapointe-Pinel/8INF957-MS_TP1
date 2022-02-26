using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using TP01_HeartDiseaseDiagnostic;
using TP1_app_BLP.Views;
using TP1_Projet.Views;
using TP1_Projet.ViewsModels;

namespace TP1_app_BLP.ViewsModels
{
    public class ConnexionViewModel
    {
        private Window loginWindow;
        public List<Doctor> Doctors { get; private set; } = new List<Doctor>();
        public Doctor SelectedDoctor { get; set; }

        public ICommand Connect => new RelayCommand(() =>
        {
            var accueil = new Accueil(SelectedDoctor);
            accueil.Show();
            loginWindow.Close();
        });

        public ICommand CreateAccount => new RelayCommand(() =>
        {
            var createAccount = new CreateAccount();
            bool? result = createAccount.ShowDialog();
            if (result.HasValue && result.Value)
            {
                Doctors.Add(createAccount.doctorEditorViewModel.Doctor);
            }
        });

        public ConnexionViewModel(Window loginWindow, IEnumerable<Doctor> doctors)
        {
            this.loginWindow = loginWindow;
            Doctors.AddRange(doctors);
            SelectedDoctor = Doctors[0];
        }
    }
}
