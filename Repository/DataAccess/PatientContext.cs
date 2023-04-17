using Microsoft.EntityFrameworkCore;
using Repository.Models;

namespace Repository.DataAccess
{
    public class PatientContext : DbContext
    {
        public PatientContext(DbContextOptions options) : base(options) { }
        
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Address> Addresses { get; set; }


    }
}
