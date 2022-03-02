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

namespace TP1_app_BLP.ViewsModels
{
    public class ConnexionViewModel
    {
        public List<Doctor> Doctors { get; private set; } = new List<Doctor>();
        public Doctor SelectedDoctor { get; set; }
        public ICommand Connect { get; private set; }
        public ICommand CreateAccount { get; private set; }

        public ConnexionViewModel(IEnumerable<Doctor> doctors)
        {
            Doctors.AddRange(doctors);
            SelectedDoctor = Doctors[0];

            Connect = new RelayCommand<Window>(window =>
            {
                var accueil = new Accueil(SelectedDoctor);
                accueil.Show();
                window.Close();
            });

            CreateAccount = new RelayCommand(() =>
            {
                var createAccount = new CreateAccount();
                bool? result = createAccount.ShowDialog();
                if (result.HasValue && result.Value)
                {
                    Doctors.Add(createAccount.doctorEditorViewModel.Doctor);
                }
            });
        }
    }
}
