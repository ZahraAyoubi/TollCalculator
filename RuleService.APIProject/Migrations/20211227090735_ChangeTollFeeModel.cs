using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RuleService.APIProject.Migrations
{
    public partial class ChangeTollFeeModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "TollFees");

            migrationBuilder.DropColumn(
                name: "IsTollFree",
                table: "TollFees");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "EventEnd",
                table: "TollFees",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "EventStart",
                table: "TollFees",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EventEnd",
                table: "TollFees");

            migrationBuilder.DropColumn(
                name: "EventStart",
                table: "TollFees");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "TollFees",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsTollFree",
                table: "TollFees",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
