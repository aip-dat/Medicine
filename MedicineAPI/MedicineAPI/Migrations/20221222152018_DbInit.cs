using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MedicineAPI.Migrations
{
    public partial class DbInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medicine",
                columns: table => new
                {
                    idMedicine = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nameMedicine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    descriptionMedicine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    numberMedicine = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicine", x => x.idMedicine);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Medicine");
        }
    }
}
