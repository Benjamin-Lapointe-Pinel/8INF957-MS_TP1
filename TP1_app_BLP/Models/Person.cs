using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TP01_HeartDiseaseDiagnostic
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly Birthdate { get; set; }
        public Gender Gender { get; set; }

        public Person()
        {
            FirstName = "";
            LastName = "";
            Birthdate = new DateOnly();
            Gender = Gender.Man;
        }

        public Person(string firstName, string lastName, DateOnly birthdate, Gender gender)
        {
            FirstName = firstName;
            LastName = lastName;
            Birthdate = birthdate;
            Gender = gender;
        }

        public override string ToString()
        {
            return $"{LastName}, {FirstName}";
        }
    }
}
