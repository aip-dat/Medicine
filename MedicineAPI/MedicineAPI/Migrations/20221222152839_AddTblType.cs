using Microsoft.EntityFrameworkCore.Migrations;

namespace MedicineAPI.Migrations
{
    public partial class AddTblType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "nameMedicine",
                table: "Medicine",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "idType",
                table: "Medicine",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Type",
                columns: table => new
                {
                    idType = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nameType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type", x => x.idType);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Medicine_idType",
                table: "Medicine",
                column: "idType");

            migrationBuilder.AddForeignKey(
                name: "FK_Medicine_Type_idType",
                table: "Medicine",
                column: "idType",
                principalTable: "Type",
                principalColumn: "idType",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medicine_Type_idType",
                table: "Medicine");

            migrationBuilder.DropTable(
                name: "Type");

            migrationBuilder.DropIndex(
                name: "IX_Medicine_idType",
                table: "Medicine");

            migrationBuilder.DropColumn(
                name: "idType",
                table: "Medicine");

            migrationBuilder.AlterColumn<string>(
                name: "nameMedicine",
                table: "Medicine",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);
        }
    }
}
