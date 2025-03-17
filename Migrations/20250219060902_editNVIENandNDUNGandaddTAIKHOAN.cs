using Microsoft.EntityFrameworkCore.Migrations;

namespace WebBookStoreManage.Migrations
{
    public partial class editNVIENandNDUNGandaddTAIKHOAN : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MatKhau",
                table: "NHANVIEN");

            migrationBuilder.DropColumn(
                name: "TenDangNhap",
                table: "NHANVIEN");

            migrationBuilder.DropColumn(
                name: "MatKhau",
                table: "NGUOIDUNG");

            migrationBuilder.CreateTable(
                name: "VAITRO",
                columns: table => new
                {
                    IdVaiTro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenVaiTro = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VAITRO", x => x.IdVaiTro);
                });

            migrationBuilder.CreateTable(
                name: "TAIKHOAN",
                columns: table => new
                {
                    IdTaiKhoan = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenDangNhap = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MatKhau = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IdVaiTro = table.Column<int>(type: "int", nullable: false),
                    IdNguoiDung = table.Column<int>(type: "int", nullable: true),
                    IdNhanVien = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TAIKHOAN", x => x.IdTaiKhoan);
                    table.ForeignKey(
                        name: "FK_TAIKHOAN_NGUOIDUNG_IdNguoiDung",
                        column: x => x.IdNguoiDung,
                        principalTable: "NGUOIDUNG",
                        principalColumn: "IdNguoiDung",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TAIKHOAN_NHANVIEN_IdNhanVien",
                        column: x => x.IdNhanVien,
                        principalTable: "NHANVIEN",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TAIKHOAN_VAITRO_IdVaiTro",
                        column: x => x.IdVaiTro,
                        principalTable: "VAITRO",
                        principalColumn: "IdVaiTro",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_TAIKHOAN_IdVaiTro",
                table: "TAIKHOAN",
                column: "IdVaiTro");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TAIKHOAN");

            migrationBuilder.DropTable(
                name: "VAITRO");

            migrationBuilder.AddColumn<string>(
                name: "MatKhau",
                table: "NHANVIEN",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TenDangNhap",
                table: "NHANVIEN",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MatKhau",
                table: "NGUOIDUNG",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }
    }
}
