using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HMS_v1._0.Models
{
    public class Patient
    {
        public int Id { get; }
        public string Name { get; }

        public string Surname {  get; }

        public int Age { get; }

        public BigInteger Pesel { get; }

        public Patient( int id, string name,string surname, int age, BigInteger pesel )
        {
            this.Id = id;
            this.Name = name;
            this.Surname = surname;
            this.Age = age;
            this.Pesel = pesel;
        }

        //test data patient
        public Patient() 
        {
            Id = 1;
            Name = "Jan";
            Surname = "Kowalski";
            Age = 33;
            Pesel = 65121710265;
        }

        

    }
}
