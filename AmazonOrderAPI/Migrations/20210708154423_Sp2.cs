using Microsoft.EntityFrameworkCore.Migrations;

namespace AmazonOrderAPI.Migrations
{
    public partial class Sp2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SellerAPIEndPoint",
                schema: "amz",
                table: "Sellers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SellerAPIEndPoint",
                schema: "amz",
                table: "Sellers");
        }
    }
}
