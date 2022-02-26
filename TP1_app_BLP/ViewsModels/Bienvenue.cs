using System;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TP1_Projet.ViewsModels
{
    
    internal class Bienvenue
    {
        
        public Models.Medecin medecin { get; set; }
        public ObservableCollection<string> Professions { get; set; }
       public RelayCommandtemp MedecinCommand { get; }

        public Bienvenue()
        {
            medecin = new Models.Medecin();
            Professions = new ObservableCollection<string>() { "Chirurgien", "Infirmier", "Ophtalmologue" };

       
            MedecinCommand = new RelayCommandtemp(
                o => medecin.EstValide,
                o => AfficherMessage()
            );
        }

        private void AfficherMessage()
        {
            throw new NotImplementedException();
        }

       
    }
}
