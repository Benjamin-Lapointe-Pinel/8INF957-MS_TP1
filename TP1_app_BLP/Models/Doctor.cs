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
        public override bool IsValid =>
            base.IsValid &&
            !string.IsNullOrWhiteSpace(Email) &&
            !string.IsNullOrWhiteSpace(Ville);

        public Doctor(string firstName, string lastName, DateOnly birthdate, Gender gender, DateOnly dateEntryOffice, string email, string ville)
            : base(firstName, lastName, birthdate, gender)
        {
            DateEntryOffice = dateEntryOffice;
            Email = email;
            Ville = ville;
        }

        public Doctor() : base()
        {
            DateEntryOffice = DateOnly.FromDateTime(DateTime.Now);
            Email = "";
            Ville = "";
        }
    }
}
