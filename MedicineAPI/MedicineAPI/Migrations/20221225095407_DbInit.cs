using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MedicineAPI.Migrations
{
    public partial class DbInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DetailPrescription",
                columns: table => new
                {
                    idDetailPrescription = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    idPrescription = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    idMedicine = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    quantityDetailPrescription = table.Column<double>(type: "float", nullable: false),
                    contentDetailPrescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    hourDetailPrescription = table.Column<int>(type: "int", nullable: false),
                    minuteDetailPrescription = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailPrescription", x => x.idDetailPrescription);
                });

            migrationBuilder.CreateTable(
                name: "DrUser",
                columns: table => new
                {
                    idDrUser = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nameDrUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    passwordDrUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fullNameDrUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    emailDrUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phoneDrUser = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrUser", x => x.idDrUser);
                });

            migrationBuilder.CreateTable(
                name: "Medicine",
                columns: table => new
                {
                    idMedicine = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nameMedicine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    descriptionMedicine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    idType = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicine", x => x.idMedicine);
                });

            migrationBuilder.CreateTable(
                name: "Prescription",
                columns: table => new
                {
                    idPrescription = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    idDrUser = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    datePrescription = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescription", x => x.idPrescription);
                });

            migrationBuilder.CreateTable(
                name: "Type",
                columns: table => new
                {
                    idType = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nameType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type", x => x.idType);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    idUser = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nameUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    passwordUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fullNameUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    emailUser = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.idUser);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetailPrescription");

            migrationBuilder.DropTable(
                name: "DrUser");

            migrationBuilder.DropTable(
                name: "Medicine");

            migrationBuilder.DropTable(
                name: "Prescription");

            migrationBuilder.DropTable(
                name: "Type");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
