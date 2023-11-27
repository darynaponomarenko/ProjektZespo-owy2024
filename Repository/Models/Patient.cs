using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Repository.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? MiddleName { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Pesel { get; set; }
   
        public DateTime DateOfBirth { get; set; }

        public List<Address>? Addresses { get; set; } = new List<Address>();
        public List<Appointment>? Appointment { get; set; } = new List<Appointment>();

    }
}
