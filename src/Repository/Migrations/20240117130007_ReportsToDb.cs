using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class ReportsToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReportEntityId",
                table: "Appointments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReportId",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PayersName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pesel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeOfForm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContractNr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContractingAuthority = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeOfRefferal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Diagnosis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodeICD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PurposeOfAdvice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TreatmentHistory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoctorsData = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_ReportEntityId",
                table: "Appointments",
                column: "ReportEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Reports_ReportEntityId",
                table: "Appointments",
                column: "ReportEntityId",
                principalTable: "Reports",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Reports_ReportEntityId",
                table: "Appointments");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_ReportEntityId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "ReportEntityId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "ReportId",
                table: "Appointments");
        }
    }
}
