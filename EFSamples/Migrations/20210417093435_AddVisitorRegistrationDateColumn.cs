using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFSamples.Migrations
{
    public partial class AddVisitorRegistrationDateColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "RegistrationDate",
                table: "Visitors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Visitors",
                keyColumn: "Id",
                keyValue: -2,
                column: "RegistrationDate",
                value: new DateTime(2021, 4, 17, 12, 34, 35, 249, DateTimeKind.Local).AddTicks(3368));

            migrationBuilder.UpdateData(
                table: "Visitors",
                keyColumn: "Id",
                keyValue: -1,
                column: "RegistrationDate",
                value: new DateTime(2021, 4, 17, 12, 34, 35, 246, DateTimeKind.Local).AddTicks(6165));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RegistrationDate",
                table: "Visitors");
        }
    }
}
