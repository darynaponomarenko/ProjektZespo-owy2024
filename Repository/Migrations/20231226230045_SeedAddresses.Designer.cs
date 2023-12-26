﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository.DataAccess;

#nullable disable

namespace Repository.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20231226230045_SeedAddresses")]
    partial class SeedAddresses
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Repository.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ApartmentNr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PatientId")
                        .HasColumnType("int");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Zipcode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.ToTable("Addresses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ApartmentNr = "40",
                            City = "Warszawa",
                            Country = "Polska",
                            State = "mazowieckie",
                            Street = "Wrocławska",
                            Zipcode = "00-014"
                        },
                        new
                        {
                            Id = 2,
                            ApartmentNr = "11",
                            City = "Warszawa",
                            Country = "Polska",
                            State = "mazowieckie",
                            Street = "Opolska",
                            Zipcode = "00-006"
                        },
                        new
                        {
                            Id = 3,
                            ApartmentNr = "0/0",
                            City = "Wieleń",
                            Country = "Polska",
                            State = "wielkopolskie",
                            Street = "park Orzechowski",
                            Zipcode = "71-912"
                        },
                        new
                        {
                            Id = 4,
                            ApartmentNr = "65b",
                            City = "Sucha Beskidzka",
                            Country = "Polska",
                            State = "małopolskie",
                            Street = "al. Szczerba",
                            Zipcode = "33-850"
                        },
                        new
                        {
                            Id = 5,
                            ApartmentNr = "18b",
                            City = "Wyrzysk",
                            Country = "Polska",
                            State = "wielkopolskie",
                            Street = "bulw. Łukaszewski",
                            Zipcode = "66-957"
                        },
                        new
                        {
                            Id = 6,
                            ApartmentNr = "795",
                            City = "Krzyż Wielkopolski",
                            Country = "Polska",
                            State = "wielkopolskie",
                            Street = "Pająk",
                            Zipcode = "28-489"
                        },
                        new
                        {
                            Id = 7,
                            ApartmentNr = "52b",
                            City = "Józefów",
                            Country = "Polska",
                            State = "mazowieckie",
                            Street = "rynek Szczęsny",
                            Zipcode = "58-400"
                        },
                        new
                        {
                            Id = 8,
                            ApartmentNr = "41b",
                            City = "Pyskowice",
                            Country = "Polska",
                            State = "śląskie",
                            Street = "os. Drabik",
                            Zipcode = "90-571"
                        });
                });

            modelBuilder.Entity("Repository.Models.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Diagnosis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DoctorId")
                        .HasColumnType("int");

                    b.Property<int?>("ICD10Id")
                        .HasColumnType("int");

                    b.Property<string>("Inspection")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Interview")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PatientId")
                        .HasColumnType("int");

                    b.Property<string>("Recommendations")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.Property<string>("TreatmentContinuationMethod")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TreatmentHistory")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("ICD10Id");

                    b.HasIndex("PatientId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("Repository.Models.ICD10", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ICD10s");
                });

            modelBuilder.Entity("Repository.Models.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pesel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Patient");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Patient");

                    b.UseTphMappingStrategy();

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateOfBirth = new DateTime(2003, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "test@gmail.com",
                            Name = "TestName1",
                            PhoneNumber = "1234567890",
                            Surname = "TestSurname"
                        },
                        new
                        {
                            Id = 2,
                            DateOfBirth = new DateTime(1998, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "test2@gmail.com",
                            Name = "TestName2",
                            PhoneNumber = "1234567098",
                            Surname = "TestSurname2"
                        },
                        new
                        {
                            Id = 3,
                            DateOfBirth = new DateTime(1978, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "test1@gmail.com",
                            Name = "TestName3",
                            PhoneNumber = "123456000",
                            Surname = "TestSurname1"
                        });
                });

            modelBuilder.Entity("Repository.Models.RegisteredAppointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Comments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DiagnosisFromRefferal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Duration")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ICD10Id")
                        .HasColumnType("int");

                    b.Property<int?>("MedicalWorkerId")
                        .HasColumnType("int");

                    b.Property<string>("NFZContractNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrderingEntity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PatientId")
                        .HasColumnType("int");

                    b.Property<string>("PayerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PayerType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Priority")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Procedure")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReasonForAdmission")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RefferalDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Time")
                        .HasColumnType("datetime2");

                    b.Property<string>("Worklist")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ICD10Id");

                    b.HasIndex("MedicalWorkerId");

                    b.HasIndex("PatientId");

                    b.ToTable("RegisteredAppointments");
                });

            modelBuilder.Entity("Repository.Models.Room", b =>
                {
                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Number");

                    b.ToTable("Room");
                });

            modelBuilder.Entity("Repository.Models.Doctor", b =>
                {
                    b.HasBaseType("Repository.Models.Patient");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<string>("NPWZ")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Doctor");

                    b.HasData(
                        new
                        {
                            Id = 5,
                            DateOfBirth = new DateTime(1978, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "ksikora@gmail.com",
                            MiddleName = "Antoni",
                            Name = "Klaudiusz",
                            Pesel = "74022667398",
                            PhoneNumber = "+48824167256",
                            Surname = "Sikora",
                            DoctorId = 1,
                            NPWZ = "2481447"
                        },
                        new
                        {
                            Id = 6,
                            DateOfBirth = new DateTime(1983, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "rnowak@gmail.com",
                            MiddleName = "Arkadiusz",
                            Name = "Robert",
                            Pesel = "63070129769",
                            PhoneNumber = "+48762388491",
                            Surname = "Nowak",
                            DoctorId = 2,
                            NPWZ = "6850524"
                        },
                        new
                        {
                            Id = 7,
                            DateOfBirth = new DateTime(1995, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "aszymczak@gmail.com",
                            Name = "Asia",
                            Pesel = "86032216879",
                            PhoneNumber = "+48912653345",
                            Surname = "Szymcza",
                            DoctorId = 3,
                            NPWZ = "3774598"
                        },
                        new
                        {
                            Id = 8,
                            DateOfBirth = new DateTime(1981, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "hsawicka@gmail.com",
                            MiddleName = "Małgorzata",
                            Name = "Helena",
                            Pesel = "48100316265",
                            PhoneNumber = "+48266939156",
                            Surname = "Sawicka",
                            DoctorId = 4,
                            NPWZ = "8521562"
                        });
                });

            modelBuilder.Entity("Repository.Models.Address", b =>
                {
                    b.HasOne("Repository.Models.Patient", null)
                        .WithMany("Addresses")
                        .HasForeignKey("PatientId");
                });

            modelBuilder.Entity("Repository.Models.Appointment", b =>
                {
                    b.HasOne("Repository.Models.Doctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId");

                    b.HasOne("Repository.Models.ICD10", "ICD10")
                        .WithMany()
                        .HasForeignKey("ICD10Id");

                    b.HasOne("Repository.Models.Patient", "Patient")
                        .WithMany("Appointment")
                        .HasForeignKey("PatientId");

                    b.Navigation("Doctor");

                    b.Navigation("ICD10");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Repository.Models.RegisteredAppointment", b =>
                {
                    b.HasOne("Repository.Models.ICD10", "ICD10")
                        .WithMany()
                        .HasForeignKey("ICD10Id");

                    b.HasOne("Repository.Models.Doctor", "MedicalWorker")
                        .WithMany()
                        .HasForeignKey("MedicalWorkerId");

                    b.HasOne("Repository.Models.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId");

                    b.Navigation("ICD10");

                    b.Navigation("MedicalWorker");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Repository.Models.Patient", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("Appointment");
                });
#pragma warning restore 612, 618
        }
    }
}
