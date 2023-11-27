using Microsoft.AspNetCore.Mvc;
using Repository.Models;
using Repository.Repo;
using System.ComponentModel.DataAnnotations;

namespace HMS_WebApi_v1._0.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientRepo _patientRepo;

        public PatientController(IPatientRepo patientRepo)
        {
            _patientRepo = patientRepo;
        }
        
        [HttpGet(Name = "GetPatients")]
        public async Task<IActionResult> GetPatients()
        {
            var patients = await _patientRepo.GetPatients();
            return Ok(patients);
            
        }

        [HttpGet(Name = "GetPatient")]
        public async Task<IActionResult> GetPatient([Required] int id)
        {
            var patient = await _patientRepo.GetPatient(id);
            if (patient != null)
                return Ok(patient);
            else
                return BadRequest("Patient not found");
        }

        [HttpPost(Name = "AddPatient")]
        public async Task<IActionResult> AddPatient(Patient patient)
        {
            /*if(patient == null)
            {
                return BadRequest("Wrong data!");
            }
            else
            {
                await _patientRepo.AddPatient(patient);
                return Ok();

            }*/
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _patientRepo.AddPatient(patient);
            return Ok(patient);
            
        }
    }
}