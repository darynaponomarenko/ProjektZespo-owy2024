using Microsoft.AspNetCore.Mvc;
using Repository.Models;
using Repository.Repo;

namespace HMS_WebApi_v1._0.Controllers
{
    [ApiController]
    [Route("api/registeredAppointment")]
    public class RegisteredAppointmentController : ControllerBase
    {
        private readonly IRegisteredAppointment _registeredAppointmentRepo;

        public RegisteredAppointmentController(IRegisteredAppointment registeredAppointmentRepo)
        {
            _registeredAppointmentRepo = registeredAppointmentRepo;
        }


        [HttpGet]
        //[Route("GetRegisteredAppointments")]
        public async Task<IActionResult> Get()
        {
            var appointments  = await _registeredAppointmentRepo.GetAppointments();
            return Ok(appointments);
        }

        [HttpPost]
        //[Route("RegisterAppointment")]
        public async Task<IActionResult> Add(RegisteredAppointment appointment)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            await _registeredAppointmentRepo.AddRegisteredAppointment(appointment);
            return Ok(appointment);
        }
    }
}
