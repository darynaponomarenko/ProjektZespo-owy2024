using Microsoft.EntityFrameworkCore;
using Repository.DataAccess;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repo
{
    
    public class DoctorRepo:IDoctorRepo
    {
        private readonly DBContext _dbContext;

        public DoctorRepo(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            var doctors = await _dbContext.Doctor.ToListAsync();
            return doctors;
        }
    }
}
