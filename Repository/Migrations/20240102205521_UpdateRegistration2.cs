using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRegistration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegisteredAppointments_ICD10s_ICD10Id",
                table: "RegisteredAppointments");

            migrationBuilder.DropIndex(
                name: "IX_RegisteredAppointments_ICD10Id",
                table: "RegisteredAppointments");

            migrationBuilder.DropColumn(
                name: "ICD10Id",
                table: "RegisteredAppointments");

            migrationBuilder.AddColumn<string>(
                name: "CodeICD",
                table: "RegisteredAppointments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodeICD",
                table: "RegisteredAppointments");

            migrationBuilder.AddColumn<int>(
                name: "ICD10Id",
                table: "RegisteredAppointments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RegisteredAppointments_ICD10Id",
                table: "RegisteredAppointments",
                column: "ICD10Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RegisteredAppointments_ICD10s_ICD10Id",
                table: "RegisteredAppointments",
                column: "ICD10Id",
                principalTable: "ICD10s",
                principalColumn: "Id");
        }
    }
}
