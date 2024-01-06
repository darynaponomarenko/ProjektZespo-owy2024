using Microsoft.AspNetCore.Mvc;
using Repository.Models;
using Repository.Repo;
using System.ComponentModel.DataAnnotations;

namespace HMS_WebApi_v1._0.Controllers
{
    [ApiController]
    [Route("api/patient")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientRepo _patientRepo;

        public PatientController(IPatientRepo patientRepo)
        {
            _patientRepo = patientRepo;
        }
        
        [HttpGet]
        //[Route("GetPatients")]
        public async Task<IActionResult> Get()
        {
            var patients = await _patientRepo.GetPatients();
            return Ok(patients);
            
        }

        [HttpGet("{id}")]
        //[Route("GetPatient")]
        public async Task<IActionResult> GetById([Required] int id)
        {
            var patient = await _patientRepo.GetPatient(id);
            if (patient != null)
                return Ok(patient);
            else
                return NotFound("Patient not found");
        }

        [HttpGet("/{pesel}")]
        public async Task<IActionResult> GetId([Required] string pesel)
        {
            var patient = await _patientRepo.GetPatientId(pesel);
            if (patient != null)
                return Ok(patient);
            else
                return NotFound("Patient not found");
        }

        [HttpPost]
        //[Route("AddPatient")]
        public async Task<IActionResult> Add([FromBody]Patient patient)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _patientRepo.AddPatient(patient);
            return CreatedAtAction(nameof(GetById), new { id = patient.Id }, patient);
            
        }
    }
}