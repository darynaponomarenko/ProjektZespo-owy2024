using Abp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.DataAccess;
using Repository.Models;

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
                                .Include(patient => patient.Addresses)
                                .Include(patient => patient.Appointment)
                                .Where(patient => patient.Id == id)
                                .FirstOrDefaultAsync();
            if (patient == null)
            {
                throw new EntityNotFoundException($"Patient with ID {id} not found.");
            }
            return patient;        
        }

        public async Task<IEnumerable<Patient>> GetPatients()
        {
            var patients = await _dbContext.Patient
                            .Include(patient => patient.Addresses)
                            .Include(patient => patient.Appointment)
                            .ToListAsync();


            return patients;
        }

        public async Task AddPatient(Patient patient)
        {
            var newPatient = _dbContext.Patient;
            if(newPatient == null)
                throw new ArgumentNullException(nameof(patient));
            else
            _dbContext.Patient.Add(patient);
            await _dbContext.SaveChangesAsync();

        }
    }
}
