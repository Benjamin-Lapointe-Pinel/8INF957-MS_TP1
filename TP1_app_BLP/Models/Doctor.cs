using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP01_HeartDiseaseDiagnostic
{
    public class Doctor : Person
    {
        public DateOnly DateEntryOffice { get; set; }
        public string Email { get; set; }
        public string Ville { get; set; }


        public Doctor(string firstName, string lastName, DateOnly birthdate, Gender gender, DateOnly dateEntryOffice, string email, string ville)
            : base(firstName, lastName, birthdate, gender)
        {
            DateEntryOffice = dateEntryOffice;
            Email = email;
            Ville = ville;
        }

        public Doctor() : base()
        {
            DateEntryOffice = new DateOnly();
            Email = "";
            Ville = "";
        }
    }
}
