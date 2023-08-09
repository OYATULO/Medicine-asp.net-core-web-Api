using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Medicine.API.Migrations
{
    /// <inheritdoc />
    public partial class first1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cabinets",
                columns: table => new
                {
                    Cab_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cab_Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cabinets", x => x.Cab_ID);
                });

            migrationBuilder.CreateTable(
                name: "Districts",
                columns: table => new
                {
                    Dis_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dis_Number = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.Dis_ID);
                });

            migrationBuilder.CreateTable(
                name: "Specializations",
                columns: table => new
                {
                    Spec_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Spec_Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specializations", x => x.Spec_ID);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Pat_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pat_Surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Pat_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Pat_Middlename = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Pat_Address = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Pat_Bday = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Pat_Denger = table.Column<int>(type: "int", nullable: true),
                    Pat_Dis_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Pat_ID);
                    table.ForeignKey(
                        name: "FK_Patients_Districts_Pat_Dis_ID",
                        column: x => x.Pat_Dis_ID,
                        principalTable: "Districts",
                        principalColumn: "Dis_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Doc_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Doc_fullname = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Doc_Cab_ID = table.Column<int>(type: "int", nullable: false),
                    Doc_Spec_ID = table.Column<int>(type: "int", nullable: false),
                    IfDistrict_doctor = table.Column<bool>(type: "bit", nullable: false),
                    Doc_Dis_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Doc_ID);
                    table.ForeignKey(
                        name: "FK_Doctors_Cabinets_Doc_Cab_ID",
                        column: x => x.Doc_Cab_ID,
                        principalTable: "Cabinets",
                        principalColumn: "Cab_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Doctors_Districts_Doc_Dis_ID",
                        column: x => x.Doc_Dis_ID,
                        principalTable: "Districts",
                        principalColumn: "Dis_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Doctors_Specializations_Doc_Spec_ID",
                        column: x => x.Doc_Spec_ID,
                        principalTable: "Specializations",
                        principalColumn: "Spec_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_Doc_Cab_ID",
                table: "Doctors",
                column: "Doc_Cab_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_Doc_Dis_ID",
                table: "Doctors",
                column: "Doc_Dis_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_Doc_Spec_ID",
                table: "Doctors",
                column: "Doc_Spec_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_Pat_Dis_ID",
                table: "Patients",
                column: "Pat_Dis_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Cabinets");

            migrationBuilder.DropTable(
                name: "Specializations");

            migrationBuilder.DropTable(
                name: "Districts");
        }
    }
}
