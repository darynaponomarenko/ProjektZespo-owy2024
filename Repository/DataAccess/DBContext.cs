using Microsoft.EntityFrameworkCore;
using Repository.Models;

namespace Repository.DataAccess
{
    public class DBContext : DbContext 
    {
        public DBContext(DbContextOptions options) : base(options) { }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
