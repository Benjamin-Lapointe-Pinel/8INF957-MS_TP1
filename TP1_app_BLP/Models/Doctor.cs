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
        public override bool IsValid => base.IsValid && !string.IsNullOrWhiteSpace(Email);

        public Doctor(string firstName, string lastName, DateOnly birthdate, GenderEnum gender, string city, DateOnly dateEntryOffice, string email)
            : base(firstName, lastName, birthdate, gender, city)
        {
            DateEntryOffice = dateEntryOffice;
            Email = email;
        }

        public Doctor() : base()
        {
            DateEntryOffice = DateOnly.FromDateTime(DateTime.Now);
            Email = "";
            City = "";
        }

        public Doctor(Doctor doctor)
            : this(doctor.FirstName, doctor.LastName, doctor.Birthdate, doctor.Gender, doctor.City, doctor.DateEntryOffice, doctor.Email)
        { }
    }
}
