namespace Repository.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string Street { get; set; } = null!;
        public string ApartmentNr { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string City { get; set; } = null!;
        public string State { get; set; } = null!;
        public string Zipcode { get; set; } = null!;
    }
}