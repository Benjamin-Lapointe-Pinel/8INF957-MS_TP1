using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// <summary>
    /// Interaction logic for Accueil.xaml
    /// </summary>
    public partial class Accueil : Window
    {
        private AccueilViewModel accueilViewModel;
        public Accueil(Doctor doctor)
        {
            accueilViewModel = new AccueilViewModel(doctor);
            DataContext = accueilViewModel;
            InitializeComponent();

            TabItem tab = new TabItem();
            tab.Content = "CreerCompte.xaml";
            

            List<MesItems> tabItems = new List<MesItems>();
            tabItems.Add(new MesItems { Header = "Informations", Content = "Page informations" });
            tabItems.Add(new MesItems { Header = "Diagnostique", Content = "Page diagnostique" });
            tabItems.Add(new MesItems { Header = "Configuration IA", Content = "Page Configuration IA" });

            TabsControl.ItemsSource = tabItems;
        }
    }

    public class MesItems
    {
        public string Header { get; set; }
        public string Content { get; set; }
    }
}

