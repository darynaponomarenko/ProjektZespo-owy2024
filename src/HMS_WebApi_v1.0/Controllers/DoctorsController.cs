using Microsoft.AspNetCore.Mvc;
using Repository.Repo;

namespace HMS_WebApi_v1._0.Controllers
{
    [ApiController]
    [Route("api/doctors")]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorRepo _doctorRepo;

        public DoctorsController(IDoctorRepo doctorRepo)
        {
            _doctorRepo = doctorRepo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var doctors = await _doctorRepo.GetDoctors();
            return Ok(doctors);
        }
    }
}
