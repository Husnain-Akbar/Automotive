using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Automotive3S.Data.Migrations
{
    public partial class autorepare : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "AutoParts",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "ListPrice",
                table: "AutoParts",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AutoParts",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "AutoParts",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Price100",
                table: "AutoParts",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Price50",
                table: "AutoParts",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "AutoParts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "AutoParts");

            migrationBuilder.DropColumn(
                name: "ListPrice",
                table: "AutoParts");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AutoParts");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "AutoParts");

            migrationBuilder.DropColumn(
                name: "Price100",
                table: "AutoParts");

            migrationBuilder.DropColumn(
                name: "Price50",
                table: "AutoParts");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "AutoParts");
        }
    }
}
