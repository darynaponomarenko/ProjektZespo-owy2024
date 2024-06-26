using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_v1._0.Messages
{
    public class AppointmentSelectedMessage
    {
        public string? WorkList {  get; set; }
        public string? PayersName {  get; set; }
        public string? Time { get; set; }
        public string? Pesel { get; set; }

        public string? Code { get; set; }

        public int PatientId { get; set; }

        public string? NFZ {  get; set; }
    }
}
