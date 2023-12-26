using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class SeedAddresses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
