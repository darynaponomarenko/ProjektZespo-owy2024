using Repository.Models;

namespace Repository.Repo
{
    public interface IRegisteredAppointment
    {
        Task<IEnumerable<RegisteredAppointment>> GetAppointments();
        Task AddRegisteredAppointment(RegisteredAppointment appointment);
    }
}
