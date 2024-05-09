using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalDoctorManagement.Infrastructure.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class İnit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    DoctorID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdentityNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.DoctorID);
                });

            migrationBuilder.CreateTable(
                name: "Hospitals",
                columns: table => new
                {
                    HospitalID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HospitalName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospitals", x => x.HospitalID);
                });

            migrationBuilder.CreateTable(
                name: "DoctorHospital",
                columns: table => new
                {
                    DoctorsDoctorID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HospitalsHospitalID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorHospital", x => new { x.DoctorsDoctorID, x.HospitalsHospitalID });
                    table.ForeignKey(
                        name: "FK_DoctorHospital_Doctors_DoctorsDoctorID",
                        column: x => x.DoctorsDoctorID,
                        principalTable: "Doctors",
                        principalColumn: "DoctorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorHospital_Hospitals_HospitalsHospitalID",
                        column: x => x.HospitalsHospitalID,
                        principalTable: "Hospitals",
                        principalColumn: "HospitalID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DoctorHospital_HospitalsHospitalID",
                table: "DoctorHospital",
                column: "HospitalsHospitalID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoctorHospital");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Hospitals");
        }
    }
}
