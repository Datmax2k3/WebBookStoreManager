using Microsoft.EntityFrameworkCore.Migrations;

namespace WebBookStoreManage.Migrations
{
    public partial class updateSanPham5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "GiaBan",
                table: "SANPHAM",
                type: "decimal(18,2)",
                nullable: true,
                computedColumnSql: "CASE WHEN GiamGia IS NULL OR GiamGia = 0 THEN GiaGoc ELSE GiaGoc - (GiaGoc * GiamGia / 100) END",
                stored: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GiaBan",
                table: "SANPHAM");
        }
    }
}
