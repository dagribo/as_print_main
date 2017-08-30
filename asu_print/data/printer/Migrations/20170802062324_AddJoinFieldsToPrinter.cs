using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace data.printer.Migrations
{
    public partial class AddJoinFieldsToPrinter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Printers",
                newName: "SerialNumber");

            migrationBuilder.AddColumn<string>(
                name: "Barcode",
                table: "Printers",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FirmId",
                table: "Printers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Barcode",
                table: "Printers");

            migrationBuilder.DropColumn(
                name: "FirmId",
                table: "Printers");

            migrationBuilder.RenameColumn(
                name: "SerialNumber",
                table: "Printers",
                newName: "Name");
        }
    }
}
