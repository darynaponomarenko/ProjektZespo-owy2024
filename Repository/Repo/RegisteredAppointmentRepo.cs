using Abp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.DataAccess;
using Repository.Models;

namespace Repository.Repo
{
    public class RegisteredAppointmentRepo : IRegisteredAppointment
    {
        private readonly DBContext _dbContext;

        public RegisteredAppointmentRepo(DBContext context)
        {
            _dbContext = context;
        }

        public async Task<IEnumerable<RegisteredAppointment>> GetAppointments()
        {
            var appointment = await _dbContext.RegisteredAppointments
                .ToListAsync();
            return appointment;
        }

        public async Task<RegisteredAppointment> GetById(long id)
        {
            var appointment = await _dbContext.RegisteredAppointments
                .Where(appointment => appointment.Id == id)
                .FirstOrDefaultAsync();
            if(appointment == null)
            {
                throw new EntityNotFoundException($"Appointment with ID {id} not found.");
            }
            return appointment;
        }

        public async Task AddRegisteredAppointment(RegisteredAppointment appointment)
        {
            var newAppointment = _dbContext.RegisteredAppointments;
            if (newAppointment == null)
                throw new ArgumentNullException(nameof(appointment));
            else
                _dbContext.RegisteredAppointments.Add(appointment);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAppointmentAsync(RegisteredAppointment appointment)
        {
            
            _dbContext.Entry(appointment).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
