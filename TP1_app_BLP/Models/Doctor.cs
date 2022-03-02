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
        public string City { get; set; }
        public override bool IsValid =>
            base.IsValid &&
            !string.IsNullOrWhiteSpace(Email) &&
            !string.IsNullOrWhiteSpace(City);

        public Doctor(string firstName, string lastName, DateOnly birthdate, GenderEnum gender, DateOnly dateEntryOffice, string email, string city)
            : base(firstName, lastName, birthdate, gender)
        {
            DateEntryOffice = dateEntryOffice;
            Email = email;
            City = city;
        }

        public Doctor() : base()
        {
            DateEntryOffice = DateOnly.FromDateTime(DateTime.Now);
            Email = "";
            City = "";
        }
    }
}
