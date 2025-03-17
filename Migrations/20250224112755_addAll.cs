using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebBookStoreManage.Migrations
{
    public partial class addAll : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DANHMUC",
                columns: table => new
                {
                    IdDanhMuc = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenDanhMuc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ThuTu = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DANHMUC", x => x.IdDanhMuc);
                });

            migrationBuilder.CreateTable(
                name: "DIACHIGIAOHANG",
                columns: table => new
                {
                    IdDiaChi = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoVaTen = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DiaChiGiaoHang = table.Column<string>(type: "nvarchar(225)", maxLength: 225, nullable: true),
                    SdtGiaoHang = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    IdNguoiDung = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DIACHIGIAOHANG", x => x.IdDiaChi);
                    table.ForeignKey(
                        name: "FK_DIACHIGIAOHANG_NGUOIDUNG_IdNguoiDung",
                        column: x => x.IdNguoiDung,
                        principalTable: "NGUOIDUNG",
                        principalColumn: "IdNguoiDung",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TACGIA",
                columns: table => new
                {
                    IdTacGia = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    TenTacGia = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TACGIA", x => x.IdTacGia);
                });

            migrationBuilder.CreateTable(
                name: "DANHMUCCHITIET",
                columns: table => new
                {
                    IdDanhMucCT = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenDanhMucCT = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IdDanhMuc = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DANHMUCCHITIET", x => x.IdDanhMucCT);
                    table.ForeignKey(
                        name: "FK_DANHMUCCHITIET_DANHMUC_IdDanhMuc",
                        column: x => x.IdDanhMuc,
                        principalTable: "DANHMUC",
                        principalColumn: "IdDanhMuc",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PHIEUDAT",
                columns: table => new
                {
                    IdPhieuDat = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NgayTaoPhieu = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdDiaChi = table.Column<int>(type: "int", nullable: false),
                    IdNguoiDung = table.Column<int>(type: "int", nullable: false),
                    TongTien = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PHIEUDAT", x => x.IdPhieuDat);
                    table.ForeignKey(
                        name: "FK_PHIEUDAT_DIACHIGIAOHANG_IdDiaChi",
                        column: x => x.IdDiaChi,
                        principalTable: "DIACHIGIAOHANG",
                        principalColumn: "IdDiaChi");
                    table.ForeignKey(
                        name: "FK_PHIEUDAT_NGUOIDUNG_IdNguoiDung",
                        column: x => x.IdNguoiDung,
                        principalTable: "NGUOIDUNG",
                        principalColumn: "IdNguoiDung");
                });

            migrationBuilder.CreateTable(
                name: "SANPHAM",
                columns: table => new
                {
                    IdSanPham = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    IdDanhMucCT = table.Column<int>(type: "int", nullable: false),
                    TenSanPham = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    IdTacGia = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: true),
                    GiaGoc = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    GiamGia = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    NgayXuatBan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SoLuotXem = table.Column<int>(type: "int", nullable: false),
                    SoLuongCon = table.Column<int>(type: "int", nullable: false),
                    SoLuongDaBan = table.Column<int>(type: "int", nullable: false),
                    MoTaChiTiet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SANPHAM", x => x.IdSanPham);
                    table.ForeignKey(
                        name: "FK_SANPHAM_DANHMUCCHITIET_IdDanhMucCT",
                        column: x => x.IdDanhMucCT,
                        principalTable: "DANHMUCCHITIET",
                        principalColumn: "IdDanhMucCT",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SANPHAM_TACGIA_IdTacGia",
                        column: x => x.IdTacGia,
                        principalTable: "TACGIA",
                        principalColumn: "IdTacGia",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DONHANG",
                columns: table => new
                {
                    IdDonHang = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrangThaiDonHang = table.Column<int>(type: "int", nullable: false),
                    NgayThanhToan = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgayGiaoHang = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdPhieuDat = table.Column<int>(type: "int", nullable: false),
                    IdNhanVien = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DONHANG", x => x.IdDonHang);
                    table.ForeignKey(
                        name: "FK_DONHANG_NHANVIEN_IdNhanVien",
                        column: x => x.IdNhanVien,
                        principalTable: "NHANVIEN",
                        principalColumn: "IdNhanVien",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DONHANG_PHIEUDAT_IdPhieuDat",
                        column: x => x.IdPhieuDat,
                        principalTable: "PHIEUDAT",
                        principalColumn: "IdPhieuDat",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CHITIETPHIEUDAT",
                columns: table => new
                {
                    IdChiTietPhieuDat = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    IdPhieuDat = table.Column<int>(type: "int", nullable: false),
                    IdSanPham = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    ThanhTien = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CHITIETPHIEUDAT", x => x.IdChiTietPhieuDat);
                    table.ForeignKey(
                        name: "FK_CHITIETPHIEUDAT_PHIEUDAT_IdPhieuDat",
                        column: x => x.IdPhieuDat,
                        principalTable: "PHIEUDAT",
                        principalColumn: "IdPhieuDat",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CHITIETPHIEUDAT_SANPHAM_IdSanPham",
                        column: x => x.IdSanPham,
                        principalTable: "SANPHAM",
                        principalColumn: "IdSanPham",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DANHGIA",
                columns: table => new
                {
                    IdDanhGia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdSanPham = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    IdNguoiDung = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DANHGIA", x => x.IdDanhGia);
                    table.ForeignKey(
                        name: "FK_DANHGIA_NGUOIDUNG_IdNguoiDung",
                        column: x => x.IdNguoiDung,
                        principalTable: "NGUOIDUNG",
                        principalColumn: "IdNguoiDung",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DANHGIA_SANPHAM_IdSanPham",
                        column: x => x.IdSanPham,
                        principalTable: "SANPHAM",
                        principalColumn: "IdSanPham",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GIOHANG",
                columns: table => new
                {
                    IdSanPham = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    IdNguoiDung = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GIOHANG", x => new { x.IdSanPham, x.IdNguoiDung });
                    table.ForeignKey(
                        name: "FK_GIOHANG_NGUOIDUNG_IdNguoiDung",
                        column: x => x.IdNguoiDung,
                        principalTable: "NGUOIDUNG",
                        principalColumn: "IdNguoiDung",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GIOHANG_SANPHAM_IdSanPham",
                        column: x => x.IdSanPham,
                        principalTable: "SANPHAM",
                        principalColumn: "IdSanPham",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HINHANHSANPHAM",
                columns: table => new
                {
                    IdHinhAnh = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    UrlAnh = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IdSanPham = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HINHANHSANPHAM", x => x.IdHinhAnh);
                    table.ForeignKey(
                        name: "FK_HINHANHSANPHAM_SANPHAM_IdSanPham",
                        column: x => x.IdSanPham,
                        principalTable: "SANPHAM",
                        principalColumn: "IdSanPham",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CHITIETPHIEUDAT_IdPhieuDat",
                table: "CHITIETPHIEUDAT",
                column: "IdPhieuDat");

            migrationBuilder.CreateIndex(
                name: "IX_CHITIETPHIEUDAT_IdSanPham",
                table: "CHITIETPHIEUDAT",
                column: "IdSanPham");

            migrationBuilder.CreateIndex(
                name: "IX_DANHGIA_IdNguoiDung",
                table: "DANHGIA",
                column: "IdNguoiDung");

            migrationBuilder.CreateIndex(
                name: "IX_DANHGIA_IdSanPham",
                table: "DANHGIA",
                column: "IdSanPham");

            migrationBuilder.CreateIndex(
                name: "IX_DANHMUCCHITIET_IdDanhMuc",
                table: "DANHMUCCHITIET",
                column: "IdDanhMuc");

            migrationBuilder.CreateIndex(
                name: "IX_DIACHIGIAOHANG_IdNguoiDung",
                table: "DIACHIGIAOHANG",
                column: "IdNguoiDung");

            migrationBuilder.CreateIndex(
                name: "IX_DONHANG_IdNhanVien",
                table: "DONHANG",
                column: "IdNhanVien",
                unique: true,
                filter: "[IdNhanVien] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DONHANG_IdPhieuDat",
                table: "DONHANG",
                column: "IdPhieuDat");

            migrationBuilder.CreateIndex(
                name: "IX_GIOHANG_IdNguoiDung",
                table: "GIOHANG",
                column: "IdNguoiDung");

            migrationBuilder.CreateIndex(
                name: "IX_HINHANHSANPHAM_IdSanPham",
                table: "HINHANHSANPHAM",
                column: "IdSanPham");

            migrationBuilder.CreateIndex(
                name: "IX_PHIEUDAT_IdDiaChi",
                table: "PHIEUDAT",
                column: "IdDiaChi");

            migrationBuilder.CreateIndex(
                name: "IX_PHIEUDAT_IdNguoiDung",
                table: "PHIEUDAT",
                column: "IdNguoiDung");

            migrationBuilder.CreateIndex(
                name: "IX_SANPHAM_IdDanhMucCT",
                table: "SANPHAM",
                column: "IdDanhMucCT");

            migrationBuilder.CreateIndex(
                name: "IX_SANPHAM_IdTacGia",
                table: "SANPHAM",
                column: "IdTacGia");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CHITIETPHIEUDAT");

            migrationBuilder.DropTable(
                name: "DANHGIA");

            migrationBuilder.DropTable(
                name: "DONHANG");

            migrationBuilder.DropTable(
                name: "GIOHANG");

            migrationBuilder.DropTable(
                name: "HINHANHSANPHAM");

            migrationBuilder.DropTable(
                name: "PHIEUDAT");

            migrationBuilder.DropTable(
                name: "SANPHAM");

            migrationBuilder.DropTable(
                name: "DIACHIGIAOHANG");

            migrationBuilder.DropTable(
                name: "DANHMUCCHITIET");

            migrationBuilder.DropTable(
                name: "TACGIA");

            migrationBuilder.DropTable(
                name: "DANHMUC");
        }
    }
}
