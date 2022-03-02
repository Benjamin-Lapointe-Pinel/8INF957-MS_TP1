using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP01_HeartDiseaseDiagnostic
{
    public class Patient : Person
    {
        public bool Diagnostic { get; private set; }

        public Patient()
        {
            Diagnostic = false;
        }

        public Patient(string firstName, string lastName, DateOnly birthdate, GenderEnum gender, bool diagnostic) : base(firstName, lastName, birthdate, gender)
        {
            Diagnostic = diagnostic;
        }
    }
}
