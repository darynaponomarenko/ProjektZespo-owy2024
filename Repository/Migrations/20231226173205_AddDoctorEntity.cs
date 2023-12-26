using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddDoctorEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_registeredAppointments_ICD10s_ICD10Id",
                table: "registeredAppointments");

            migrationBuilder.DropForeignKey(
                name: "FK_registeredAppointments_Patient_MedicalWorkerId",
                table: "registeredAppointments");

            migrationBuilder.DropForeignKey(
                name: "FK_registeredAppointments_Patient_PatientId",
                table: "registeredAppointments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_registeredAppointments",
                table: "registeredAppointments");

            migrationBuilder.RenameTable(
                name: "registeredAppointments",
                newName: "RegisteredAppointments");

            migrationBuilder.RenameIndex(
                name: "IX_registeredAppointments_PatientId",
                table: "RegisteredAppointments",
                newName: "IX_RegisteredAppointments_PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_registeredAppointments_MedicalWorkerId",
                table: "RegisteredAppointments",
                newName: "IX_RegisteredAppointments_MedicalWorkerId");

            migrationBuilder.RenameIndex(
                name: "IX_registeredAppointments_ICD10Id",
                table: "RegisteredAppointments",
                newName: "IX_RegisteredAppointments_ICD10Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RegisteredAppointments",
                table: "RegisteredAppointments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RegisteredAppointments_ICD10s_ICD10Id",
                table: "RegisteredAppointments",
                column: "ICD10Id",
                principalTable: "ICD10s",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RegisteredAppointments_Patient_MedicalWorkerId",
                table: "RegisteredAppointments",
                column: "MedicalWorkerId",
                principalTable: "Patient",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RegisteredAppointments_Patient_PatientId",
                table: "RegisteredAppointments",
                column: "PatientId",
                principalTable: "Patient",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegisteredAppointments_ICD10s_ICD10Id",
                table: "RegisteredAppointments");

            migrationBuilder.DropForeignKey(
                name: "FK_RegisteredAppointments_Patient_MedicalWorkerId",
                table: "RegisteredAppointments");

            migrationBuilder.DropForeignKey(
                name: "FK_RegisteredAppointments_Patient_PatientId",
                table: "RegisteredAppointments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RegisteredAppointments",
                table: "RegisteredAppointments");

            migrationBuilder.RenameTable(
                name: "RegisteredAppointments",
                newName: "registeredAppointments");

            migrationBuilder.RenameIndex(
                name: "IX_RegisteredAppointments_PatientId",
                table: "registeredAppointments",
                newName: "IX_registeredAppointments_PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_RegisteredAppointments_MedicalWorkerId",
                table: "registeredAppointments",
                newName: "IX_registeredAppointments_MedicalWorkerId");

            migrationBuilder.RenameIndex(
                name: "IX_RegisteredAppointments_ICD10Id",
                table: "registeredAppointments",
                newName: "IX_registeredAppointments_ICD10Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_registeredAppointments",
                table: "registeredAppointments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_registeredAppointments_ICD10s_ICD10Id",
                table: "registeredAppointments",
                column: "ICD10Id",
                principalTable: "ICD10s",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_registeredAppointments_Patient_MedicalWorkerId",
                table: "registeredAppointments",
                column: "MedicalWorkerId",
                principalTable: "Patient",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_registeredAppointments_Patient_PatientId",
                table: "registeredAppointments",
                column: "PatientId",
                principalTable: "Patient",
                principalColumn: "Id");
        }
    }
}
