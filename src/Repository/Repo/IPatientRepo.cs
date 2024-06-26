using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repo
{
    public interface IPatientRepo
    {
        Task<IEnumerable<Patient>> GetPatients();
        Task<Patient> GetPatient(long id);

        Task AddPatient(Patient patient);

        Task<int> GetPatientId(string pesel);

        
    }
}
