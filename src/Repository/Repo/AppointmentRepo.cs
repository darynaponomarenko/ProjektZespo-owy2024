using Microsoft.EntityFrameworkCore;
using Repository.DataAccess;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repo
{
    public class AppointmentRepo : IAppointmentRepo
    {
        private readonly DBContext _dbContext;

        public AppointmentRepo(DBContext context)
        {
            _dbContext = context;
        }

        /*public async Task<Appointment> GetAppointment()
        {

        }*/

        public async Task AddAppointment(Appointment appointment)
        {
            var newAppointment = _dbContext.Appointments;
            if (newAppointment == null)
                throw new ArgumentNullException(nameof(appointment));
            else
                _dbContext.Appointments.Add(appointment);
            await _dbContext.SaveChangesAsync();
        }

    }
}
