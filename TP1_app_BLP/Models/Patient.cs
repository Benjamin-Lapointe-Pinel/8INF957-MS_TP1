using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP01_HeartDiseaseDiagnostic
{
    public class Patient : Person
    {
        public bool Diagnostic { get; set; } = false;

        public Patient()
        {
        }

        public Patient(string firstName, string lastName, DateOnly birthdate, GenderEnum gender, string city, bool diagnostic = false)
            : base(firstName, lastName, birthdate, gender, city)
        {
            Diagnostic = diagnostic;
        }
    }
}
