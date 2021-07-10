using Microsoft.EntityFrameworkCore.Migrations;

namespace AmazonOrderAPI.Migrations
{
    public partial class Tes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AddressType",
                schema: "amz",
                table: "Address",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "AddressType",
                schema: "amz",
                table: "Address",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
