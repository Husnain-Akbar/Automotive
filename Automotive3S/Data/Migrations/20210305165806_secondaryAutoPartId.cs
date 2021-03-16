using Microsoft.EntityFrameworkCore.Migrations;

namespace Automotive3S.Data.Migrations
{
    public partial class secondaryAutoPartId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PartGalleries_AutoParts_AutoPartId",
                table: "PartGalleries");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "PartGalleries");

            migrationBuilder.AlterColumn<int>(
                name: "AutoPartId",
                table: "PartGalleries",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PartGalleries_AutoParts_AutoPartId",
                table: "PartGalleries",
                column: "AutoPartId",
                principalTable: "AutoParts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PartGalleries_AutoParts_AutoPartId",
                table: "PartGalleries");

            migrationBuilder.AlterColumn<int>(
                name: "AutoPartId",
                table: "PartGalleries",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "PartGalleries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_PartGalleries_AutoParts_AutoPartId",
                table: "PartGalleries",
                column: "AutoPartId",
                principalTable: "AutoParts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
