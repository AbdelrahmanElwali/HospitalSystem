using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddNewEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DeskNumber",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Users",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Specilizations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specilizations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DoctorSpecilizations",
                columns: table => new
                {
                    DoctorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SpecilizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DoctorId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SpecilizationId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorSpecilizations", x => new { x.DoctorId, x.SpecilizationId });
                    table.ForeignKey(
                        name: "FK_DoctorSpecilizations_Specilizations_SpecilizationId",
                        column: x => x.SpecilizationId,
                        principalTable: "Specilizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorSpecilizations_Specilizations_SpecilizationId1",
                        column: x => x.SpecilizationId1,
                        principalTable: "Specilizations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DoctorSpecilizations_Users_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorSpecilizations_Users_DoctorId1",
                        column: x => x.DoctorId1,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DoctorSpecilizations_DoctorId1",
                table: "DoctorSpecilizations",
                column: "DoctorId1");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorSpecilizations_SpecilizationId",
                table: "DoctorSpecilizations",
                column: "SpecilizationId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorSpecilizations_SpecilizationId1",
                table: "DoctorSpecilizations",
                column: "SpecilizationId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoctorSpecilizations");

            migrationBuilder.DropTable(
                name: "Specilizations");

            migrationBuilder.DropColumn(
                name: "DeskNumber",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Users");
        }
    }
}
