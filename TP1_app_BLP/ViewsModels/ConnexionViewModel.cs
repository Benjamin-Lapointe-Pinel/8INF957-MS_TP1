using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public ObservableCollection<Doctor> Doctors { get; private set; }
        public Doctor SelectedDoctor { get; set; }
        public ICommand Connect { get; private set; }
        public ICommand CreateAccount { get; private set; }

        public ConnexionViewModel()
        {
            Doctors = new()
            {
                new("Benjamin", "Lapointe", new(1995, 11, 13), Person.GenderEnum.Man, "Rimouski", new DateOnly(), "lapb0010@uqar.ca"),
                new("Mamadou", "Diallo", new(1994, 09, 3), Person.GenderEnum.Man, "Lévis", new DateOnly(), "Mamadou.mous@uqar.ca"),
                new("Bashar", "Fatemeh", new(1997, 09, 3), Person.GenderEnum.Woman, "Quebec", new DateOnly(), "Fatemah.bashar@uqar.ca")
            };
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
