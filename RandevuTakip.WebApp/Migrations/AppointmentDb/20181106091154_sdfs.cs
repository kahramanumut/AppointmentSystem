using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RandevuTakip.WebApp.Migrations.AppointmentDb
{
    public partial class sdfs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_departments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserGuidId = table.Column<string>(nullable: true),
                    DepartmentName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_patients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserGuidId = table.Column<string>(nullable: true),
                    IdentityNo = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_patients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_doctors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserGuidId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    DepartmentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_doctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_doctors_tbl_departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "tbl_departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_appointments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserGuidId = table.Column<string>(nullable: true),
                    PatientId = table.Column<int>(nullable: true),
                    DepartmentId = table.Column<int>(nullable: true),
                    DoctorId = table.Column<int>(nullable: true),
                    Timestamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_appointments_tbl_departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "tbl_departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_appointments_tbl_doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "tbl_doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_appointments_tbl_patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "tbl_patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_appointments_DepartmentId",
                table: "tbl_appointments",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_appointments_DoctorId",
                table: "tbl_appointments",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_appointments_PatientId",
                table: "tbl_appointments",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_doctors_DepartmentId",
                table: "tbl_doctors",
                column: "DepartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_appointments");

            migrationBuilder.DropTable(
                name: "tbl_doctors");

            migrationBuilder.DropTable(
                name: "tbl_patients");

            migrationBuilder.DropTable(
                name: "tbl_departments");
        }
    }
}
