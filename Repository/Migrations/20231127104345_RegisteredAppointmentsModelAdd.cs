using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class RegisteredAppointmentsModelAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "registeredAppointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: true),
                    Procedure = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Priority = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Worklist = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PayerType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PayerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefferalDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OrderingEntity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiagnosisFromRefferal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ICD10Id = table.Column<int>(type: "int", nullable: true),
                    ReasonForAdmission = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NFZContractNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedicalWorkerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_registeredAppointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_registeredAppointments_ICD10s_ICD10Id",
                        column: x => x.ICD10Id,
                        principalTable: "ICD10s",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_registeredAppointments_Patient_MedicalWorkerId",
                        column: x => x.MedicalWorkerId,
                        principalTable: "Patient",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_registeredAppointments_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_registeredAppointments_ICD10Id",
                table: "registeredAppointments",
                column: "ICD10Id");

            migrationBuilder.CreateIndex(
                name: "IX_registeredAppointments_MedicalWorkerId",
                table: "registeredAppointments",
                column: "MedicalWorkerId");

            migrationBuilder.CreateIndex(
                name: "IX_registeredAppointments_PatientId",
                table: "registeredAppointments",
                column: "PatientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "registeredAppointments");
        }
    }
}
