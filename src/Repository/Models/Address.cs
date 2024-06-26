namespace Repository.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string? Street { get; set; }
        public string? ApartmentNr { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Zipcode { get; set; }

        public int PatientId { get; set; }
        public Patient? Patient { get; set; }


    }
}