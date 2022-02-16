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

namespace TP01_HeartDiseaseDiagnostic
{
    public partial class Login : Window
    {
        public List<Doctor> Doctors { get; private set; } = new List<Doctor> {
            new("Benjamin", "Lapointe", new(1995, 11, 13), Gender.Man, new DateOnly(), "lapb0010@uqar.ca")
        };

        public Doctor? SelectedDoctor { get; set; }

        public Login()
        {
            DataContext = this;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
