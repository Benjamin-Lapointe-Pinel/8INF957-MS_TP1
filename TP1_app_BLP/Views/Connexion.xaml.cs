﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TP01_HeartDiseaseDiagnostic;
using TP1_app_BLP.ViewsModels;

namespace TP1_Projet.Views
{
    public partial class Connexion : Window
    {
        private ConnexionViewModel connexionViewModel;
        public Connexion()
        {
            connexionViewModel = new ConnexionViewModel(new List<Doctor>
            {
                new("Benjamin", "Lapointe", new(1995, 11, 13), Person.GenderEnum.Man, new DateOnly(), "lapb0010@uqar.ca", "Rimouski"),
                new("Mamadou", "Diallo", new(1994, 09, 3), Person.GenderEnum.Man, new DateOnly(), "Mamadou.mous@uqar.ca", "Lévis"),
                new("Bhas", "Fatemeh", new(1997, 09, 3), Person.GenderEnum.Woman, new DateOnly(), "Fatemah.Bashar@uqar.ca", "Quebec")
            });
            DataContext = connexionViewModel;
            InitializeComponent();
        }
    }
}
