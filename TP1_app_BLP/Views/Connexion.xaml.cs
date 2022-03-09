using System;
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
            connexionViewModel = new ConnexionViewModel();
            DataContext = connexionViewModel;
            InitializeComponent();
        }
    }
}
