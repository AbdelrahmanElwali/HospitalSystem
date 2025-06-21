using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPatientStayBedRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Beds");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Beds");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Rooms",
                newName: "RoomType");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Beds",
                newName: "BedNumber");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Capacity",
                table: "Rooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "RoomNumber",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "DailyRate",
                table: "Beds",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "IsOccupied",
                table: "Beds",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "PatientStayId",
                table: "Beds",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Beds_PatientStayId",
                table: "Beds",
                column: "PatientStayId",
                unique: true,
                filter: "[PatientStayId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Beds_PatientStays_PatientStayId",
                table: "Beds",
                column: "PatientStayId",
                principalTable: "PatientStays",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beds_PatientStays_PatientStayId",
                table: "Beds");

            migrationBuilder.DropIndex(
                name: "IX_Beds_PatientStayId",
                table: "Beds");

            migrationBuilder.DropColumn(
                name: "Capacity",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "RoomNumber",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "DailyRate",
                table: "Beds");

            migrationBuilder.DropColumn(
                name: "IsOccupied",
                table: "Beds");

            migrationBuilder.DropColumn(
                name: "PatientStayId",
                table: "Beds");

            migrationBuilder.RenameColumn(
                name: "RoomType",
                table: "Rooms",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "BedNumber",
                table: "Beds",
                newName: "Name");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Beds",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Beds",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
