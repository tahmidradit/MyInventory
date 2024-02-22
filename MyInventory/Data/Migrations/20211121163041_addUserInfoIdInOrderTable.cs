using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyInventory.Data.Migrations
{
    public partial class addUserInfoIdInOrderTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserInfoId",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserInfoId",
                table: "Orders");
        }
    }
}
