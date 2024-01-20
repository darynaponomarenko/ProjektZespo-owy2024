using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models
{
    public class Doctor : Patient
    {
        public int DoctorId {  get; set; }
        public string NPWZ { get; set; } = null!;
        
        //public int LoginId { get; set; }
        public LoginData LoginData { get; set; }

        


       
    }
}
