using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models
{
    public class LoginData
    {
        public int Id { get; set; }
        public string WorkersId { get; set; } = null!;
        public string Password { get; set; } = null!;

        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
    }
}
