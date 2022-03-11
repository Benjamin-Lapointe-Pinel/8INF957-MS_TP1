using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using Microsoft.Win32;
using TP01_HeartDiseaseDiagnostic;
using TP1_app_BLP.ViewsModels;

namespace TP1_app_BLP.Views
{
    public partial class Accueil : Window
    {
        private AccueilViewModel accueilViewModel;
        public Accueil(Doctor doctor)
        {
            accueilViewModel = new AccueilViewModel(doctor);
            DataContext = accueilViewModel;
            InitializeComponent();
        }

        
    }
}
