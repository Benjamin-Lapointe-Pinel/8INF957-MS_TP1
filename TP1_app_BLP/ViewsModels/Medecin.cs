using System;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace TP1_Projet.Models
{
    internal class Medecin : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private string _nom;
        public string Nom
        {
            get { return _nom; }
            set
            {
                if (_nom != value)
                {
                    _nom = value;
                    SetEstValide();
                }
            }
        }
        public string Profession { get; set; }
        private string message;
        public string Message
        {
            get { return message; }
            set
            {
                if (message != value)
                {
                    message = value;
                    OnPropertyChanged();
                }
            }
        }
        private bool _estValide;
        public bool EstValide
        {
            get { return _estValide; }
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



        private void SetEstValide()
        {
            _estValide = !string.IsNullOrEmpty(Nom) && !string.IsNullOrEmpty(Profession);
        }
    }


}
