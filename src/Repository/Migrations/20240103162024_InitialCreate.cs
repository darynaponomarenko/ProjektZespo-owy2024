using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ICD10s",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ICD10s", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pesel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: true),
                    NPWZ = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApartmentNr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Zipcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorID = table.Column<int>(type: "int", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Interview = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Inspection = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Diagnosis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TreatmentHistory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Recommendations = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TreatmentContinuationMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ICD10 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_Patient_DoctorID",
                        column: x => x.DoctorID,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Appointments_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "RegisteredAppointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    Pesel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Procedure = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Priority = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Worklist = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Payers = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PayerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PayerExtraNote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfIssue = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ContractingAuthorities = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReasonForAdmission = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodeICD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NFZContractNr = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisteredAppointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegisteredAppointments_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "ApartmentNr", "City", "Country", "PatientId", "State", "Street", "Zipcode" },
                values: new object[,]
                {
                    { 1, "40", "Warszawa", "Polska", null, "mazowieckie", "Wrocławska", "00-014" },
                    { 2, "11", "Warszawa", "Polska", null, "mazowieckie", "Opolska", "00-006" },
                    { 3, "0/0", "Wieleń", "Polska", null, "wielkopolskie", "park Orzechowski", "71-912" },
                    { 4, "65b", "Sucha Beskidzka", "Polska", null, "małopolskie", "al. Szczerba", "33-850" },
                    { 5, "18b", "Wyrzysk", "Polska", null, "wielkopolskie", "bulw. Łukaszewski", "66-957" },
                    { 6, "795", "Krzyż Wielkopolski", "Polska", null, "wielkopolskie", "Pająk", "28-489" },
                    { 7, "52b", "Józefów", "Polska", null, "mazowieckie", "rynek Szczęsny", "58-400" },
                    { 8, "41b", "Pyskowice", "Polska", null, "śląskie", "os. Drabik", "90-571" }
                });

            migrationBuilder.InsertData(
                table: "Patient",
                columns: new[] { "Id", "DateOfBirth", "Discriminator", "Email", "MiddleName", "Name", "Pesel", "PhoneNumber", "Surname" },
                values: new object[,]
                {
                    { 1, new DateTime(2003, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Patient", "test@gmail.com", null, "TestName1", null, "1234567890", "TestSurname" },
                    { 2, new DateTime(1998, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Patient", "test2@gmail.com", null, "TestName2", null, "1234567098", "TestSurname2" },
                    { 3, new DateTime(1978, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Patient", "test1@gmail.com", null, "TestName3", null, "123456000", "TestSurname1" }
                });

            migrationBuilder.InsertData(
                table: "Patient",
                columns: new[] { "Id", "DateOfBirth", "Discriminator", "DoctorId", "Email", "MiddleName", "NPWZ", "Name", "Pesel", "PhoneNumber", "Surname" },
                values: new object[,]
                {
                    { 5, new DateTime(1978, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Doctor", 1, "ksikora@gmail.com", "Antoni", "2481447", "Klaudiusz", "74022667398", "+48824167256", "Sikora" },
                    { 6, new DateTime(1983, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Doctor", 2, "rnowak@gmail.com", "Arkadiusz", "6850524", "Robert", "63070129769", "+48762388491", "Nowak" },
                    { 7, new DateTime(1995, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Doctor", 3, "aszymczak@gmail.com", null, "3774598", "Asia", "86032216879", "+48912653345", "Szymcza" },
                    { 8, new DateTime(1981, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Doctor", 4, "hsawicka@gmail.com", "Małgorzata", "8521562", "Helena", "48100316265", "+48266939156", "Sawicka" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_PatientId",
                table: "Addresses",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DoctorID",
                table: "Appointments",
                column: "DoctorID");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PatientId",
                table: "Appointments",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_RegisteredAppointments_PatientId",
                table: "RegisteredAppointments",
                column: "PatientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "ICD10s");

            migrationBuilder.DropTable(
                name: "RegisteredAppointments");

            migrationBuilder.DropTable(
                name: "Patient");
        }
    }
}
