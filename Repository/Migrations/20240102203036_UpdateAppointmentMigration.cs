using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAppointmentMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comments",
                table: "RegisteredAppointments");

            migrationBuilder.RenameColumn(
                name: "RefferalDate",
                table: "RegisteredAppointments",
                newName: "DateOfIssue");

            migrationBuilder.RenameColumn(
                name: "PayerType",
                table: "RegisteredAppointments",
                newName: "Payers");

            migrationBuilder.RenameColumn(
                name: "OrderingEntity",
                table: "RegisteredAppointments",
                newName: "PayerExtraNote");

            migrationBuilder.RenameColumn(
                name: "NFZContractNumber",
                table: "RegisteredAppointments",
                newName: "NFZContractNr");

            migrationBuilder.RenameColumn(
                name: "Duration",
                table: "RegisteredAppointments",
                newName: "ContractingAuthorities");

            migrationBuilder.RenameColumn(
                name: "DiagnosisFromRefferal",
                table: "RegisteredAppointments",
                newName: "AdmissionReasoning");

            migrationBuilder.AlterColumn<string>(
                name: "Time",
                table: "RegisteredAppointments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "RegisteredAppointments",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "RegisteredAppointments");

            migrationBuilder.RenameColumn(
                name: "Payers",
                table: "RegisteredAppointments",
                newName: "PayerType");

            migrationBuilder.RenameColumn(
                name: "PayerExtraNote",
                table: "RegisteredAppointments",
                newName: "OrderingEntity");

            migrationBuilder.RenameColumn(
                name: "NFZContractNr",
                table: "RegisteredAppointments",
                newName: "NFZContractNumber");

            migrationBuilder.RenameColumn(
                name: "DateOfIssue",
                table: "RegisteredAppointments",
                newName: "RefferalDate");

            migrationBuilder.RenameColumn(
                name: "ContractingAuthorities",
                table: "RegisteredAppointments",
                newName: "Duration");

            migrationBuilder.RenameColumn(
                name: "AdmissionReasoning",
                table: "RegisteredAppointments",
                newName: "DiagnosisFromRefferal");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Time",
                table: "RegisteredAppointments",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Comments",
                table: "RegisteredAppointments",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
