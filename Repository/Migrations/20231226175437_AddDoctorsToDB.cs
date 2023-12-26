using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddDoctorsToDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
