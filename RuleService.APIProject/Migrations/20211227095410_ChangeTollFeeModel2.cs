using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RuleService.APIProject.Migrations
{
    public partial class ChangeTollFeeModel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TollFees_CostTypes_CostTypeId",
                table: "TollFees");

            migrationBuilder.DropIndex(
                name: "IX_TollFees_CostTypeId",
                table: "TollFees");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EventStart",
                table: "TollFees",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EventEnd",
                table: "TollFees",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.AlterColumn<int>(
                name: "CostTypeId",
                table: "TollFees",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "EventStart",
                table: "TollFees",
                type: "time",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "EventEnd",
                table: "TollFees",
                type: "time",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "CostTypeId",
                table: "TollFees",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_TollFees_CostTypeId",
                table: "TollFees",
                column: "CostTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_TollFees_CostTypes_CostTypeId",
                table: "TollFees",
                column: "CostTypeId",
                principalTable: "CostTypes",
                principalColumn: "Id");
        }
    }
}
