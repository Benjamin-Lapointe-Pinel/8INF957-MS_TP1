using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_app_BLP
{
    public class Doctor : Person
    {
        public DateOnly DateEntryOffice { get; private set; }
        public string Email { get; private set; }

        public Doctor(string firstName, string lastName, DateOnly birthdate, Gender gender, DateOnly dateEntryOffice, string email)
            : base(firstName, lastName, birthdate, gender)
        {
            DateEntryOffice = dateEntryOffice;
            Email = email;
        }
    }
}
