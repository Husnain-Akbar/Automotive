using Microsoft.EntityFrameworkCore.Migrations;

namespace Automotive3S.Data.Migrations
{
    public partial class updateorderheader : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CouponCode",
                table: "OrderHeaders",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "CouponCodeDiscount",
                table: "OrderHeaders",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "OrderTotalOriginal",
                table: "OrderHeaders",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CouponCode",
                table: "OrderHeaders");

            migrationBuilder.DropColumn(
                name: "CouponCodeDiscount",
                table: "OrderHeaders");

            migrationBuilder.DropColumn(
                name: "OrderTotalOriginal",
                table: "OrderHeaders");
        }
    }
}
