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
        public string Name { get; set; } = null!;        //non-nullable variable
        public string Surname { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
   
        public DateTime DateOfBirth { get; set; }

        public List<Address> Addresses { get; set; } = new List<Address>();
        public Appointment Appointment { get; set; } = null!;
        public MedicalRecords MedicalRecords { get; set; } = null!;

    }
}
