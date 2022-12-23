using Microsoft.EntityFrameworkCore.Migrations;

namespace MedicineAPI.Migrations
{
    public partial class AddTblPreName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_prescriptions_DrUser_drUseridDrUser",
                table: "prescriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_prescriptions_Medicine_medicineidMedicine",
                table: "prescriptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_prescriptions",
                table: "prescriptions");

            migrationBuilder.RenameTable(
                name: "prescriptions",
                newName: "Prescription");

            migrationBuilder.RenameIndex(
                name: "IX_prescriptions_medicineidMedicine",
                table: "Prescription",
                newName: "IX_Prescription_medicineidMedicine");

            migrationBuilder.RenameIndex(
                name: "IX_prescriptions_drUseridDrUser",
                table: "Prescription",
                newName: "IX_Prescription_drUseridDrUser");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Prescription",
                table: "Prescription",
                column: "idPrescription");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_DrUser_drUseridDrUser",
                table: "Prescription",
                column: "drUseridDrUser",
                principalTable: "DrUser",
                principalColumn: "idDrUser",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_Medicine_medicineidMedicine",
                table: "Prescription",
                column: "medicineidMedicine",
                principalTable: "Medicine",
                principalColumn: "idMedicine",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_DrUser_drUseridDrUser",
                table: "Prescription");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_Medicine_medicineidMedicine",
                table: "Prescription");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Prescription",
                table: "Prescription");

            migrationBuilder.RenameTable(
                name: "Prescription",
                newName: "prescriptions");

            migrationBuilder.RenameIndex(
                name: "IX_Prescription_medicineidMedicine",
                table: "prescriptions",
                newName: "IX_prescriptions_medicineidMedicine");

            migrationBuilder.RenameIndex(
                name: "IX_Prescription_drUseridDrUser",
                table: "prescriptions",
                newName: "IX_prescriptions_drUseridDrUser");

            migrationBuilder.AddPrimaryKey(
                name: "PK_prescriptions",
                table: "prescriptions",
                column: "idPrescription");

            migrationBuilder.AddForeignKey(
                name: "FK_prescriptions_DrUser_drUseridDrUser",
                table: "prescriptions",
                column: "drUseridDrUser",
                principalTable: "DrUser",
                principalColumn: "idDrUser",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_prescriptions_Medicine_medicineidMedicine",
                table: "prescriptions",
                column: "medicineidMedicine",
                principalTable: "Medicine",
                principalColumn: "idMedicine",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
