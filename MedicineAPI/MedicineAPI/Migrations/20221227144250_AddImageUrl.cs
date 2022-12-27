using Microsoft.EntityFrameworkCore.Migrations;

namespace MedicineAPI.Migrations
{
    public partial class AddImageUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "imageUrlUser",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "imageUrlMedicine",
                table: "Medicine",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "imageUrlDrUser",
                table: "DrUser",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "imageUrlUser",
                table: "User");

            migrationBuilder.DropColumn(
                name: "imageUrlMedicine",
                table: "Medicine");

            migrationBuilder.DropColumn(
                name: "imageUrlDrUser",
                table: "DrUser");
        }
    }
}
