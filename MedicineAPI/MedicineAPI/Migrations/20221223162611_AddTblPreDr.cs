using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MedicineAPI.Migrations
{
    public partial class AddTblPreDr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "numberMedicine",
                table: "Medicine");

            migrationBuilder.CreateTable(
                name: "DrUser",
                columns: table => new
                {
                    idDrUser = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nameDrUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    passwordDrUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    fullNameDrUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    emailDrUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phoneDrUser = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrUser", x => x.idDrUser);
                });

            migrationBuilder.CreateTable(
                name: "prescriptions",
                columns: table => new
                {
                    idPrescription = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    idDrUser = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    idMedicine = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    quantityPrescription = table.Column<double>(type: "float", nullable: false),
                    contentPrescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    medicineidMedicine = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    drUseridDrUser = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prescriptions", x => x.idPrescription);
                    table.ForeignKey(
                        name: "FK_prescriptions_DrUser_drUseridDrUser",
                        column: x => x.drUseridDrUser,
                        principalTable: "DrUser",
                        principalColumn: "idDrUser",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_prescriptions_Medicine_medicineidMedicine",
                        column: x => x.medicineidMedicine,
                        principalTable: "Medicine",
                        principalColumn: "idMedicine",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_prescriptions_drUseridDrUser",
                table: "prescriptions",
                column: "drUseridDrUser");

            migrationBuilder.CreateIndex(
                name: "IX_prescriptions_medicineidMedicine",
                table: "prescriptions",
                column: "medicineidMedicine");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "prescriptions");

            migrationBuilder.DropTable(
                name: "DrUser");

            migrationBuilder.AddColumn<double>(
                name: "numberMedicine",
                table: "Medicine",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
