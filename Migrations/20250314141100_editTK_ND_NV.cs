using Microsoft.EntityFrameworkCore.Migrations;

namespace WebBookStoreManage.Migrations
{
    public partial class editTK_ND_NV : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TAIKHOAN_NGUOIDUNG_IdNguoiDung",
                table: "TAIKHOAN");

            migrationBuilder.DropForeignKey(
                name: "FK_TAIKHOAN_NHANVIEN_IdNhanVien",
                table: "TAIKHOAN");

            migrationBuilder.DropIndex(
                name: "IX_TAIKHOAN_IdNguoiDung",
                table: "TAIKHOAN");

            migrationBuilder.DropIndex(
                name: "IX_TAIKHOAN_IdNhanVien",
                table: "TAIKHOAN");

            migrationBuilder.DropColumn(
                name: "IdNguoiDung",
                table: "TAIKHOAN");

            migrationBuilder.DropColumn(
                name: "IdNhanVien",
                table: "TAIKHOAN");

            migrationBuilder.AddColumn<int>(
                name: "IdTaiKhoan",
                table: "NHANVIEN",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdTaiKhoan",
                table: "NGUOIDUNG",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<decimal>(
                name: "GiaBan",
                table: "SANPHAM",
                type: "decimal(12,2)",
                nullable: true,
                computedColumnSql: "CASE WHEN GiamGia IS NULL OR GiamGia = 0 THEN GiaGoc ELSE GiaGoc - (GiaGoc * GiamGia / 100) END",
                stored: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true,
                oldComputedColumnSql: "CASE WHEN GiamGia IS NULL OR GiamGia = 0 THEN GiaGoc ELSE GiaGoc - (GiaGoc * GiamGia / 100) END",
                oldStored: true);

            migrationBuilder.CreateIndex(
                name: "IX_NHANVIEN_IdTaiKhoan",
                table: "NHANVIEN",
                column: "IdTaiKhoan",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NGUOIDUNG_IdTaiKhoan",
                table: "NGUOIDUNG",
                column: "IdTaiKhoan",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_NGUOIDUNG_TAIKHOAN_IdTaiKhoan",
                table: "NGUOIDUNG",
                column: "IdTaiKhoan",
                principalTable: "TAIKHOAN",
                principalColumn: "IdTaiKhoan",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NHANVIEN_TAIKHOAN_IdTaiKhoan",
                table: "NHANVIEN",
                column: "IdTaiKhoan",
                principalTable: "TAIKHOAN",
                principalColumn: "IdTaiKhoan",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NGUOIDUNG_TAIKHOAN_IdTaiKhoan",
                table: "NGUOIDUNG");

            migrationBuilder.DropForeignKey(
                name: "FK_NHANVIEN_TAIKHOAN_IdTaiKhoan",
                table: "NHANVIEN");

            migrationBuilder.DropIndex(
                name: "IX_NHANVIEN_IdTaiKhoan",
                table: "NHANVIEN");

            migrationBuilder.DropIndex(
                name: "IX_NGUOIDUNG_IdTaiKhoan",
                table: "NGUOIDUNG");

            migrationBuilder.DropColumn(
                name: "IdTaiKhoan",
                table: "NHANVIEN");

            migrationBuilder.DropColumn(
                name: "IdTaiKhoan",
                table: "NGUOIDUNG");

            migrationBuilder.AddColumn<int>(
                name: "IdNguoiDung",
                table: "TAIKHOAN",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdNhanVien",
                table: "TAIKHOAN",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "GiaBan",
                table: "SANPHAM",
                type: "decimal(18,2)",
                nullable: true,
                computedColumnSql: "CASE WHEN GiamGia IS NULL OR GiamGia = 0 THEN GiaGoc ELSE GiaGoc - (GiaGoc * GiamGia / 100) END",
                stored: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(12,2)",
                oldNullable: true,
                oldComputedColumnSql: "CASE WHEN GiamGia IS NULL OR GiamGia = 0 THEN GiaGoc ELSE GiaGoc - (GiaGoc * GiamGia / 100) END",
                oldStored: true);

            migrationBuilder.CreateIndex(
                name: "IX_TAIKHOAN_IdNguoiDung",
                table: "TAIKHOAN",
                column: "IdNguoiDung",
                unique: true,
                filter: "[IdNguoiDung] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TAIKHOAN_IdNhanVien",
                table: "TAIKHOAN",
                column: "IdNhanVien",
                unique: true,
                filter: "[IdNhanVien] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_TAIKHOAN_NGUOIDUNG_IdNguoiDung",
                table: "TAIKHOAN",
                column: "IdNguoiDung",
                principalTable: "NGUOIDUNG",
                principalColumn: "IdNguoiDung",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TAIKHOAN_NHANVIEN_IdNhanVien",
                table: "TAIKHOAN",
                column: "IdNhanVien",
                principalTable: "NHANVIEN",
                principalColumn: "IdNhanVien",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
