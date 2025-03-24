using Microsoft.EntityFrameworkCore.Migrations;

namespace WebBookStoreManage.Migrations
{
    public partial class addSDTtoNguoiDung : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<string>(
                name: "soDienThoai",
                table: "NGUOIDUNG",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "soDienThoai",
                table: "NGUOIDUNG");

        }
    }
}
