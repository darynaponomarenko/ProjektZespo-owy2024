using Microsoft.AspNetCore.Mvc;
using Repository.Models;
using Repository.Repo;

namespace HMS_WebApi_v1._0.Controllers
{
    [ApiController]
    [Route("api/appointment")]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentRepo _appointmentRepo;

        public AppointmentController(IAppointmentRepo appointmentRepo)
        {
            _appointmentRepo = appointmentRepo;
        }

        [HttpPost]
        //[Route("AddAppointment")]
        public async Task<IActionResult> Add(Appointment appointment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _appointmentRepo.AddAppointment(appointment);
            return Ok(appointment);
        }
    }
}
