using HMS_v1._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_v1._0.Messages
{
    public class SendDataToFormsMessage
    {
        public string? PayersName { get; set; }
        public string? Pesel { get; set; }
        public string? CodeICD { get; set; }
        public string? CodeDescription { get; set; }
        public string Doctor { get; set; }
    }
}
