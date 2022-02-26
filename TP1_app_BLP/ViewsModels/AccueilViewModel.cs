using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP01_HeartDiseaseDiagnostic;

namespace TP1_app_BLP.ViewsModels
{
    public class AccueilViewModel
    {
        public Doctor Doctor {get; private set;}
        public string Greeting => $"Bienvenue Dr. {Doctor}";

        public AccueilViewModel(Doctor doctor)
        {
            Doctor = doctor;
        }
    }
}
