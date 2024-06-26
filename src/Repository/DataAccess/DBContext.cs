using Microsoft.EntityFrameworkCore;
using Repository.Models;

namespace Repository.DataAccess
{
    public class DBContext : DbContext 
    {
        public DBContext()
        {
        }
        public DBContext(DbContextOptions options) : base(options) { }

        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<Address> Addresses { get; set; }

        public DbSet<Appointment>  Appointments { get; set; }

        public DbSet<RegisteredAppointment> RegisteredAppointments { get; set; }

        public DbSet<ICD10> ICD10s { get; set; }

        public DbSet<ContractingAuthorities> ContractingAuthorities { get; set; }

        public DbSet<ReportEntityModel> Reports { get; set; }

        public DbSet<LoginData> LoginData { get; set; }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
         
            modelBuilder.Entity<Patient>().HasData(
                new Patient
                {
                    Id = 1,
                    Name = "TestName1",
                    Surname = "TestSurname",
                    Email = "test@gmail.com",
                    PhoneNumber = "1234567890",
                    DateOfBirth = new DateTime(2003, 07, 15)
                },
                new Patient
                {
                    Id = 2,
                    Name = "TestName2",
                    Surname = "TestSurname2",
                    Email = "test2@gmail.com",
                    PhoneNumber = "1234567098",
                    DateOfBirth = new DateTime(1998,11, 17)
                },
                new Patient
                {
                    Id = 3,
                    Name = "TestName3",
                    Surname = "TestSurname1",
                    Email = "test1@gmail.com",
                    PhoneNumber = "123456000",
                    DateOfBirth = new DateTime(1978, 03, 19)
                }
                );

            //DOCTORS

            modelBuilder.Entity<Doctor>().HasData(
               new Doctor
               {
                   Id = 5,
                   Name = "Klaudiusz",
                   Surname = "Sikora",
                   MiddleName = "Antoni",
                   Email = "ksikora@gmail.com",
                   PhoneNumber = "+48824167256",
                   Pesel = "74022667398",
                   DateOfBirth = new DateTime(1978, 07, 13),
                   DoctorId = 1, 
                   NPWZ = "2481447"
               },
               new Doctor
               {
                   Id = 6,
                   Name = "Robert",
                   MiddleName = "Arkadiusz",
                   Surname = "Nowak",
                   Email = "rnowak@gmail.com",
                   PhoneNumber = "+48762388491",
                   Pesel = "63070129769",
                   DateOfBirth = new DateTime(1983, 01, 02),
                   DoctorId = 2,
                   NPWZ = "6850524"
               },
               new Doctor
               {
                   Id = 7,
                   Name = "Asia",
                   Surname = "Szymcza",
                   Email = "aszymczak@gmail.com",
                   PhoneNumber = "+48912653345",
                   Pesel = "86032216879",
                   DateOfBirth = new DateTime(1995, 02, 26),
                   DoctorId = 3,
                   NPWZ = "3774598"
               },
               new Doctor
               {
                   Id = 8,
                   Name = "Helena",
                   Surname = "Sawicka",
                   MiddleName = "Małgorzata",
                   Email = "hsawicka@gmail.com",
                   PhoneNumber = "+48266939156",
                   Pesel = "48100316265",
                   DateOfBirth = new DateTime(1981, 11, 29),
                   DoctorId = 4,
                   NPWZ = "8521562"
               }
               );

            //ADDRESSES

            modelBuilder.Entity<Address>().HasData(
               new Address
               {
                   Id = 1,
                   Street = "Wrocławska",
                   ApartmentNr = "40",
                   Country = "Polska",
                   City = "Warszawa",
                   State = "mazowieckie",
                   Zipcode = "00-014"
               },
               new Address
               {
                   Id = 2,
                   Street = "Opolska",
                   ApartmentNr = "11",
                   Country = "Polska",
                   City = "Warszawa",
                   State = "mazowieckie",
                   Zipcode = "00-006"
               },
               new Address
               {
                   Id = 3,
                   Street = "park Orzechowski",
                   ApartmentNr = "0/0",
                   Country = "Polska",
                   City = "Wieleń",
                   State = "wielkopolskie",
                   Zipcode = "71-912"
               },
               new Address
               {
                   Id = 4,
                   Street = "al. Szczerba",
                   ApartmentNr = "65b",
                   Country = "Polska",
                   City = "Sucha Beskidzka",
                   State = "małopolskie",
                   Zipcode = "33-850"
               },
               new Address
               {
                   Id = 5,
                   Street = "bulw. Łukaszewski",
                   ApartmentNr = "18b",
                   Country = "Polska",
                   City = "Wyrzysk",
                   State = "wielkopolskie",
                   Zipcode = "66-957"
               },
               new Address
               {
                   Id = 6,
                   Street = "Pająk",
                   ApartmentNr = "795",
                   Country = "Polska",
                   City = "Krzyż Wielkopolski",
                   State = "wielkopolskie",
                   Zipcode = "28-489"
               },
               new Address
               {
                   Id = 7,
                   Street = "rynek Szczęsny",
                   ApartmentNr = "52b",
                   Country = "Polska",
                   City = "Józefów",
                   State = "mazowieckie",
                   Zipcode = "58-400"
               },
               new Address
               {
                   Id = 8,
                   Street = "os. Drabik",
                   ApartmentNr = "41b",
                   Country = "Polska",
                   City = "Pyskowice",
                   State = "śląskie",
                   Zipcode = "90-571"
               });



        }


    }
}
