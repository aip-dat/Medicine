using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MedicineAPI.Migrations
{
    public partial class AddTblUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    idUser = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nameUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    passwordUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
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
                name: "User");
        }
    }
}
