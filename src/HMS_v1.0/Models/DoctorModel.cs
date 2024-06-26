using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_v1._0.Models
{
    public class DoctorModel : PatientModel
    {
        public int DoctorId { get; set; }
        public string NPWZ { get; set; } = null!;

    }
}
