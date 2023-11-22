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
    public class PatientRepo : IPatientRepo
    {
        private readonly DBContext _dbContext;

        public PatientRepo(DBContext context)
        {
            _dbContext = context;
        }

        public async Task<Patient> GetPatient(long id)
        {
            var patient = await _dbContext.Patient
                                .Include(patient => patient.Name)
                                .Where(patient => patient.Id == id).FirstOrDefaultAsync();
            return patient;        
        }

        public async Task<IEnumerable<Patient>> GetPatients()
        {
            var patients = await _dbContext.Patient
                            .Include(patients => patients.Name)
                            .ToListAsync();


            return patients;
        }
    }
}
