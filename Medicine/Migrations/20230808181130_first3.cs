using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Medicine.API.Migrations
{
    /// <inheritdoc />
    public partial class first3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Cabinets_Doc_Cab_ID",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Districts_Doc_Dis_ID",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Specializations_Doc_Spec_ID",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Districts_Pat_Dis_ID",
                table: "Patients");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Cabinets_Doc_Cab_ID",
                table: "Doctors",
                column: "Doc_Cab_ID",
                principalTable: "Cabinets",
                principalColumn: "Cab_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Districts_Doc_Dis_ID",
                table: "Doctors",
                column: "Doc_Dis_ID",
                principalTable: "Districts",
                principalColumn: "Dis_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Specializations_Doc_Spec_ID",
                table: "Doctors",
                column: "Doc_Spec_ID",
                principalTable: "Specializations",
                principalColumn: "Spec_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Districts_Pat_Dis_ID",
                table: "Patients",
                column: "Pat_Dis_ID",
                principalTable: "Districts",
                principalColumn: "Dis_ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Cabinets_Doc_Cab_ID",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Districts_Doc_Dis_ID",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Specializations_Doc_Spec_ID",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Districts_Pat_Dis_ID",
                table: "Patients");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Cabinets_Doc_Cab_ID",
                table: "Doctors",
                column: "Doc_Cab_ID",
                principalTable: "Cabinets",
                principalColumn: "Cab_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Districts_Doc_Dis_ID",
                table: "Doctors",
                column: "Doc_Dis_ID",
                principalTable: "Districts",
                principalColumn: "Dis_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Specializations_Doc_Spec_ID",
                table: "Doctors",
                column: "Doc_Spec_ID",
                principalTable: "Specializations",
                principalColumn: "Spec_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Districts_Pat_Dis_ID",
                table: "Patients",
                column: "Pat_Dis_ID",
                principalTable: "Districts",
                principalColumn: "Dis_ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
