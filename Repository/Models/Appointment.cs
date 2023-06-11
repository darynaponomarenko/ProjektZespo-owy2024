using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public Doctor? Doctor { get; set; }
        public int DoctorId { get; set; }
        public Patient? Patient { get; set; }
        public int PatientId { get; set; }

        public DateTime Date { get; set; }
        public DateTime Time { get; set; }

        public string Status { get; set; } = null!;

        public string? Note { get; set; } 
    }
}
