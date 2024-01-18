using Abp.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IActionResult> Get()
        {
            var appointments = await _registeredAppointmentRepo.GetAppointments();
            return Ok(appointments);
        }

        [HttpPost]
        public async Task<IActionResult> Add(RegisteredAppointment appointment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _registeredAppointmentRepo.AddRegisteredAppointment(appointment);
            return Ok(appointment);
        }

        [HttpPut("api/registeredAppointment/{id}")]
        public async Task<IActionResult> UpdateAppointment(int id, [FromBody] RegisteredAppointment appointment)
        {
            if(appointment == null)
            {
                return BadRequest("Invalid update data");
            }

            var existingAppointment = await _registeredAppointmentRepo.GetById(id);

            if(existingAppointment != null)
            {
                existingAppointment.Procedure = appointment.Procedure;
                existingAppointment.Priority = appointment.Priority;
                existingAppointment.Worklist = appointment.Worklist;
                existingAppointment.Date = appointment.Date;
                existingAppointment.Time = appointment.Time;
                existingAppointment.PayerExtraNote = appointment.PayerExtraNote;
                existingAppointment.DateOfIssue = appointment.DateOfIssue;
                existingAppointment.ContractingAuthorities = appointment.ContractingAuthorities;
                existingAppointment.ReasonForAdmission = appointment.ReasonForAdmission;
                existingAppointment.CodeICD = appointment.CodeICD;
                existingAppointment.NFZContractNr = appointment.NFZContractNr;
                existingAppointment.IsActive = appointment.IsActive;
            }
            else
            {
                return NotFound("Appointment not found");
            }

            try
            {
                await _registeredAppointmentRepo.UpdateAppointmentAsync(existingAppointment);
                return Ok("Appointment updated successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error updating appointment: {ex.Message}");
            }
          
        }
    }
}
