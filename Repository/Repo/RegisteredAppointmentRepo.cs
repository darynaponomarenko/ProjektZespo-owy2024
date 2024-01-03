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
                /*.Include(appointment => appointment.Id)
                .Include(appointment => appointment.Patient)
                .Include(appointment => appointment.Procedure)
                .Include(appointment => appointment.Priority)
                .Include(appointment => appointment.Time)
                .Include(appointment => appointment.Duration)*/
                .ToListAsync();
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
    }
}
