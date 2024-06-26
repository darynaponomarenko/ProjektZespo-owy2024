﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_v1._0.Messages
{
    public class NewlyAddedPatientMessage
    { 
        public string? PatientName { get; set; }
        public int PatientAge {  get; set; }
        public string? Pesel {  get; set; }

        public int PatientId {  get; set; }

        public string CodeICD { get; set; }
    }
}
