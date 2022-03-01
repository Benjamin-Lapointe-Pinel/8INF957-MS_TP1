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
        public GenderEnum Gender { get; set; }
        public virtual bool IsValid =>
            !string.IsNullOrWhiteSpace(FirstName) &&
            !string.IsNullOrWhiteSpace(LastName);

        public Person()
        {
            FirstName = "";
            LastName = "";
            Birthdate = DateOnly.FromDateTime(DateTime.Now);
            Gender = GenderEnum.Man;
        }

        public Person(string firstName, string lastName, DateOnly birthdate, GenderEnum gender)
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

        public enum GenderEnum
        {
            Man,
            Woman
        }
    }
}
