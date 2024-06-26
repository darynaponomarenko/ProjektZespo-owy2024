namespace Repository.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? MiddleName { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Pesel { get; set; }
   
        public DateTime DateOfBirth { get; set; }

        public List<RegisteredAppointment>? RegisteredAppointments { get;} = new List<RegisteredAppointment>();
        public List<Address>? Addresses { get;} = new List<Address>();
        public List<Appointment>? Appointment { get;} = new List<Appointment>();

    }
}
