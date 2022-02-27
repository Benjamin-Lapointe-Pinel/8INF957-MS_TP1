using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP01_HeartDiseaseDiagnostic;

namespace TP1_app_BLP.ViewsModels
{
    public class AccueilViewModel : DoctorEditorViewModel
    {
        public string Greeting => $"Bienvenue Dr. {Doctor}";

        public AccueilViewModel(Doctor doctor) : base(doctor, true) { }
    }
}
