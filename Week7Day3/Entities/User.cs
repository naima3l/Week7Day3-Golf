using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week7Day3.Entities
{
    class User
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public EnumSex Sex { get; set; }
        public bool Registred { get; set; }
        public int? Id { get; set; }

        public User(string name, string surname, DateTime birthDate, EnumSex sex, bool registred, int? id)
        {
            Name = name;
            Surname = surname;
            BirthDate = birthDate;
            Sex = sex;
            Registred = registred;
            Id = id;
        }

        public User()
        {

        }

        public string Print()
        {
            return $"Nome : {Name}, Cognome : {Surname}, Data di nascita : {BirthDate.ToShortDateString()}, Sesso : {Sex}, Tesserato : {Registred}";
        }
    }
    enum EnumSex
    {
        M,
        F
    }
}
