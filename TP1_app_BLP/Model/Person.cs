using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_app_BLP
{
    public class Person
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateOnly Birthdate { get; private set; }
        public Gender Gender { get; private set; }

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
