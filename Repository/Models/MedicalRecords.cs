using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models
{
    public class MedicalRecords
    {
        public int Id { get; set; }
        public Patient? Patient { get; set; }
        public int PatientId { get; set; }

        public DateTime Date {  get; set; }
        public DateTime Time { get; set; }

        public string? Diagnose { get; set; }

        public string? MedicationsPrescribed { get; set; }

        public string? TestResults { get; set; }

        public string? Notes { get; set; }
    }
}
