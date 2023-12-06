using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DataAccess
{
    public class DesignTimeDBContextFactory : IDesignTimeDbContextFactory<DBContext>
    {
        public DBContext CreateDbContext(string[] args)
        {
            var options = new DbContextOptionsBuilder<DBContext>();
            options.UseSqlServer("Data Source=DESKTOP-J7CUSB6\\SQLEXPRESS;Initial Catalog = HMSLocalDB; User id=sa; Password=test; TrustServerCertificate=True");

            return new DBContext(options.Options);
        }
    }
}
