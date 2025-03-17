using Microsoft.EntityFrameworkCore.Migrations;

namespace WebBookStoreManage.Migrations
{
    public partial class updateAlldb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CHITIETPHIEUDAT_PHIEUDAT_IdPhieuDat",
                table: "CHITIETPHIEUDAT");

            migrationBuilder.DropForeignKey(
                name: "FK_CHITIETPHIEUDAT_SANPHAM_IdSanPham",
                table: "CHITIETPHIEUDAT");

            migrationBuilder.DropForeignKey(
                name: "FK_DANHGIA_NGUOIDUNG_IdNguoiDung",
                table: "DANHGIA");

            migrationBuilder.DropForeignKey(
                name: "FK_DANHGIA_SANPHAM_IdSanPham",
                table: "DANHGIA");

            migrationBuilder.DropForeignKey(
                name: "FK_DANHMUCCHITIET_DANHMUC_IdDanhMuc",
                table: "DANHMUCCHITIET");

            migrationBuilder.DropForeignKey(
                name: "FK_DIACHIGIAOHANG_NGUOIDUNG_IdNguoiDung",
                table: "DIACHIGIAOHANG");

            migrationBuilder.DropForeignKey(
                name: "FK_DONHANG_NHANVIEN_IdNhanVien",
                table: "DONHANG");

            migrationBuilder.DropForeignKey(
                name: "FK_DONHANG_PHIEUDAT_IdPhieuDat",
                table: "DONHANG");

            migrationBuilder.DropForeignKey(
                name: "FK_GIOHANG_NGUOIDUNG_IdNguoiDung",
                table: "GIOHANG");

            migrationBuilder.DropForeignKey(
                name: "FK_GIOHANG_SANPHAM_IdSanPham",
                table: "GIOHANG");

            migrationBuilder.DropForeignKey(
                name: "FK_HINHANHSANPHAM_SANPHAM_IdSanPham",
                table: "HINHANHSANPHAM");

            migrationBuilder.DropForeignKey(
                name: "FK_NGUOIDUNG_TAIKHOAN_IdTaiKhoan",
                table: "NGUOIDUNG");

            migrationBuilder.DropForeignKey(
                name: "FK_NHANVIEN_LOAINHANVIEN_IdLoaiNhanVien",
                table: "NHANVIEN");

            migrationBuilder.DropForeignKey(
                name: "FK_NHANVIEN_TAIKHOAN_IdTaiKhoan",
                table: "NHANVIEN");

            migrationBuilder.DropForeignKey(
                name: "FK_PHIEUDAT_DIACHIGIAOHANG_IdDiaChi",
                table: "PHIEUDAT");

            migrationBuilder.DropForeignKey(
                name: "FK_PHIEUDAT_NGUOIDUNG_IdNguoiDung",
                table: "PHIEUDAT");

            migrationBuilder.DropForeignKey(
                name: "FK_SANPHAM_DANHMUCCHITIET_IdDanhMucCT",
                table: "SANPHAM");

            migrationBuilder.DropForeignKey(
                name: "FK_SANPHAM_TACGIA_SANPHAM_IdSanPham",
                table: "SANPHAM_TACGIA");

            migrationBuilder.DropForeignKey(
                name: "FK_SANPHAM_TACGIA_TACGIA_IdTacGia",
                table: "SANPHAM_TACGIA");

            migrationBuilder.DropForeignKey(
                name: "FK_TAIKHOAN_VAITRO_IdVaiTro",
                table: "TAIKHOAN");

            migrationBuilder.DropIndex(
                name: "IX_DONHANG_IdNhanVien",
                table: "DONHANG");

            migrationBuilder.RenameColumn(
                name: "TenVaiTro",
                table: "VAITRO",
                newName: "tenVaiTro");

            migrationBuilder.RenameColumn(
                name: "IdVaiTro",
                table: "VAITRO",
                newName: "idVaiTro");

            migrationBuilder.RenameColumn(
                name: "TenDangNhap",
                table: "TAIKHOAN",
                newName: "tenDangNhap");

            migrationBuilder.RenameColumn(
                name: "MatKhau",
                table: "TAIKHOAN",
                newName: "matKhau");

            migrationBuilder.RenameColumn(
                name: "IdVaiTro",
                table: "TAIKHOAN",
                newName: "idVaiTro");

            migrationBuilder.RenameColumn(
                name: "IdTaiKhoan",
                table: "TAIKHOAN",
                newName: "idTaiKhoan");

            migrationBuilder.RenameIndex(
                name: "IX_TAIKHOAN_IdVaiTro",
                table: "TAIKHOAN",
                newName: "IX_TAIKHOAN_idVaiTro");

            migrationBuilder.RenameColumn(
                name: "TenTacGia",
                table: "TACGIA",
                newName: "tenTacGia");

            migrationBuilder.RenameColumn(
                name: "IdTacGia",
                table: "TACGIA",
                newName: "idTacGia");

            migrationBuilder.RenameColumn(
                name: "IdTacGia",
                table: "SANPHAM_TACGIA",
                newName: "idTacGia");

            migrationBuilder.RenameColumn(
                name: "IdSanPham",
                table: "SANPHAM_TACGIA",
                newName: "idSanPham");

            migrationBuilder.RenameIndex(
                name: "IX_SANPHAM_TACGIA_IdTacGia",
                table: "SANPHAM_TACGIA",
                newName: "IX_SANPHAM_TACGIA_idTacGia");

            migrationBuilder.RenameColumn(
                name: "TrangThai",
                table: "SANPHAM",
                newName: "trangThai");

            migrationBuilder.RenameColumn(
                name: "TenSanPham",
                table: "SANPHAM",
                newName: "tenSanPham");

            migrationBuilder.RenameColumn(
                name: "SoLuotXem",
                table: "SANPHAM",
                newName: "soLuotXem");

            migrationBuilder.RenameColumn(
                name: "SoLuongDaBan",
                table: "SANPHAM",
                newName: "soLuongDaBan");

            migrationBuilder.RenameColumn(
                name: "SoLuongCon",
                table: "SANPHAM",
                newName: "soLuongCon");

            migrationBuilder.RenameColumn(
                name: "NgayXuatBan",
                table: "SANPHAM",
                newName: "ngayXuatBan");

            migrationBuilder.RenameColumn(
                name: "MoTaChiTiet",
                table: "SANPHAM",
                newName: "moTaChiTiet");

            migrationBuilder.RenameColumn(
                name: "IdDanhMucCT",
                table: "SANPHAM",
                newName: "idDanhMucCT");

            // Bước 1: Xóa cột GiaBan trước khi đổi tên các cột liên quan
            migrationBuilder.DropColumn(
                name: "GiaBan",
                table: "SANPHAM");

            // Bước 2: Đổi tên các cột
            migrationBuilder.RenameColumn(
                name: "GiamGia",
                table: "SANPHAM",
                newName: "giamGia");

            migrationBuilder.RenameColumn(
                name: "GiaGoc",
                table: "SANPHAM",
                newName: "giaGoc");

            // Bước 3: Tạo lại cột giaBan với công thức mới
            migrationBuilder.AddColumn<decimal>(
                name: "giaBan",
                table: "SANPHAM",
                type: "decimal(12,2)",
                nullable: true,
                computedColumnSql: "CASE WHEN giamGia IS NULL OR giamGia = 0 THEN giaGoc ELSE giaGoc - (giaGoc * giamGia / 100) END",
                stored: true);

            migrationBuilder.RenameColumn(
                name: "IdSanPham",
                table: "SANPHAM",
                newName: "idSanPham");

            migrationBuilder.RenameIndex(
                name: "IX_SANPHAM_IdDanhMucCT",
                table: "SANPHAM",
                newName: "IX_SANPHAM_idDanhMucCT");

            migrationBuilder.RenameColumn(
                name: "TongTien",
                table: "PHIEUDAT",
                newName: "tongTien");

            migrationBuilder.RenameColumn(
                name: "NgayTaoPhieu",
                table: "PHIEUDAT",
                newName: "ngayTaoPhieu");

            migrationBuilder.RenameColumn(
                name: "IdNguoiDung",
                table: "PHIEUDAT",
                newName: "idNguoiDung");

            migrationBuilder.RenameColumn(
                name: "IdDiaChi",
                table: "PHIEUDAT",
                newName: "idDiaChi");

            migrationBuilder.RenameColumn(
                name: "GhiChu",
                table: "PHIEUDAT",
                newName: "ghiChu");

            migrationBuilder.RenameColumn(
                name: "IdPhieuDat",
                table: "PHIEUDAT",
                newName: "idPhieuDat");

            migrationBuilder.RenameIndex(
                name: "IX_PHIEUDAT_IdNguoiDung",
                table: "PHIEUDAT",
                newName: "IX_PHIEUDAT_idNguoiDung");

            migrationBuilder.RenameIndex(
                name: "IX_PHIEUDAT_IdDiaChi",
                table: "PHIEUDAT",
                newName: "IX_PHIEUDAT_idDiaChi");

            migrationBuilder.RenameColumn(
                name: "TenNhanVien",
                table: "NHANVIEN",
                newName: "tenNhanVien");

            migrationBuilder.RenameColumn(
                name: "NgayVaoLam",
                table: "NHANVIEN",
                newName: "ngayVaoLam");

            migrationBuilder.RenameColumn(
                name: "IdTaiKhoan",
                table: "NHANVIEN",
                newName: "idTaiKhoan");

            migrationBuilder.RenameColumn(
                name: "IdLoaiNhanVien",
                table: "NHANVIEN",
                newName: "idLoaiNhanVien");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "NHANVIEN",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "DienThoai",
                table: "NHANVIEN",
                newName: "dienThoai");

            migrationBuilder.RenameColumn(
                name: "IdNhanVien",
                table: "NHANVIEN",
                newName: "idNhanVien");

            migrationBuilder.RenameIndex(
                name: "IX_NHANVIEN_IdTaiKhoan",
                table: "NHANVIEN",
                newName: "IX_NHANVIEN_idTaiKhoan");

            migrationBuilder.RenameIndex(
                name: "IX_NHANVIEN_IdLoaiNhanVien",
                table: "NHANVIEN",
                newName: "IX_NHANVIEN_idLoaiNhanVien");

            migrationBuilder.RenameColumn(
                name: "TenNguoiDung",
                table: "NGUOIDUNG",
                newName: "tenNguoiDung");

            migrationBuilder.RenameColumn(
                name: "NgayDangKy",
                table: "NGUOIDUNG",
                newName: "ngayDangKy");

            migrationBuilder.RenameColumn(
                name: "IdTaiKhoan",
                table: "NGUOIDUNG",
                newName: "idTaiKhoan");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "NGUOIDUNG",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "DiaChi",
                table: "NGUOIDUNG",
                newName: "diaChi");

            migrationBuilder.RenameColumn(
                name: "IdNguoiDung",
                table: "NGUOIDUNG",
                newName: "idNguoiDung");

            migrationBuilder.RenameIndex(
                name: "IX_NGUOIDUNG_IdTaiKhoan",
                table: "NGUOIDUNG",
                newName: "IX_NGUOIDUNG_idTaiKhoan");

            migrationBuilder.RenameIndex(
                name: "IX_NGUOIDUNG_Email",
                table: "NGUOIDUNG",
                newName: "IX_NGUOIDUNG_email");

            migrationBuilder.RenameColumn(
                name: "TenLoaiNhanVien",
                table: "LOAINHANVIEN",
                newName: "tenLoaiNhanVien");

            migrationBuilder.RenameColumn(
                name: "IdLoaiNhanVien",
                table: "LOAINHANVIEN",
                newName: "idLoaiNhanVien");

            migrationBuilder.RenameColumn(
                name: "UrlAnh",
                table: "HINHANHSANPHAM",
                newName: "urlAnh");

            migrationBuilder.RenameColumn(
                name: "IdSanPham",
                table: "HINHANHSANPHAM",
                newName: "idSanPham");

            migrationBuilder.RenameColumn(
                name: "IdHinhAnh",
                table: "HINHANHSANPHAM",
                newName: "idHinhAnh");

            migrationBuilder.RenameIndex(
                name: "IX_HINHANHSANPHAM_IdSanPham",
                table: "HINHANHSANPHAM",
                newName: "IX_HINHANHSANPHAM_idSanPham");

            migrationBuilder.RenameColumn(
                name: "SoLuong",
                table: "GIOHANG",
                newName: "soLuong");

            migrationBuilder.RenameColumn(
                name: "IdNguoiDung",
                table: "GIOHANG",
                newName: "idNguoiDung");

            migrationBuilder.RenameColumn(
                name: "IdSanPham",
                table: "GIOHANG",
                newName: "idSanPham");

            migrationBuilder.RenameIndex(
                name: "IX_GIOHANG_IdNguoiDung",
                table: "GIOHANG",
                newName: "IX_GIOHANG_idNguoiDung");

            migrationBuilder.RenameColumn(
                name: "TrangThaiDonHang",
                table: "DONHANG",
                newName: "trangThaiDonHang");

            migrationBuilder.RenameColumn(
                name: "NgayThanhToan",
                table: "DONHANG",
                newName: "ngayThanhToan");

            migrationBuilder.RenameColumn(
                name: "NgayGiaoHang",
                table: "DONHANG",
                newName: "ngayGiaoHang");

            migrationBuilder.RenameColumn(
                name: "IdPhieuDat",
                table: "DONHANG",
                newName: "idPhieuDat");

            migrationBuilder.RenameColumn(
                name: "IdNhanVien",
                table: "DONHANG",
                newName: "idNhanVien");

            migrationBuilder.RenameColumn(
                name: "IdDonHang",
                table: "DONHANG",
                newName: "idDonHang");

            migrationBuilder.RenameIndex(
                name: "IX_DONHANG_IdPhieuDat",
                table: "DONHANG",
                newName: "IX_DONHANG_idPhieuDat");

            migrationBuilder.RenameColumn(
                name: "SdtGiaoHang",
                table: "DIACHIGIAOHANG",
                newName: "sdtGiaoHang");

            migrationBuilder.RenameColumn(
                name: "IdNguoiDung",
                table: "DIACHIGIAOHANG",
                newName: "idNguoiDung");

            migrationBuilder.RenameColumn(
                name: "HoVaTen",
                table: "DIACHIGIAOHANG",
                newName: "hoVaTen");

            migrationBuilder.RenameColumn(
                name: "DiaChiGiaoHang",
                table: "DIACHIGIAOHANG",
                newName: "diaChiGiaoHang");

            migrationBuilder.RenameColumn(
                name: "IdDiaChi",
                table: "DIACHIGIAOHANG",
                newName: "idDiaChi");

            migrationBuilder.RenameIndex(
                name: "IX_DIACHIGIAOHANG_IdNguoiDung",
                table: "DIACHIGIAOHANG",
                newName: "IX_DIACHIGIAOHANG_idNguoiDung");

            migrationBuilder.RenameColumn(
                name: "TenDanhMucCT",
                table: "DANHMUCCHITIET",
                newName: "tenDanhMucCT");

            migrationBuilder.RenameColumn(
                name: "IdDanhMuc",
                table: "DANHMUCCHITIET",
                newName: "idDanhMuc");

            migrationBuilder.RenameColumn(
                name: "IdDanhMucCT",
                table: "DANHMUCCHITIET",
                newName: "idDanhMucCT");

            migrationBuilder.RenameIndex(
                name: "IX_DANHMUCCHITIET_IdDanhMuc",
                table: "DANHMUCCHITIET",
                newName: "IX_DANHMUCCHITIET_idDanhMuc");

            migrationBuilder.RenameColumn(
                name: "ThuTu",
                table: "DANHMUC",
                newName: "thuTu");

            migrationBuilder.RenameColumn(
                name: "TenDanhMuc",
                table: "DANHMUC",
                newName: "tenDanhMuc");

            migrationBuilder.RenameColumn(
                name: "IdDanhMuc",
                table: "DANHMUC",
                newName: "idDanhMuc");

            migrationBuilder.RenameColumn(
                name: "NoiDung",
                table: "DANHGIA",
                newName: "noiDung");

            migrationBuilder.RenameColumn(
                name: "IdSanPham",
                table: "DANHGIA",
                newName: "idSanPham");

            migrationBuilder.RenameColumn(
                name: "IdNguoiDung",
                table: "DANHGIA",
                newName: "idNguoiDung");

            migrationBuilder.RenameColumn(
                name: "IdDanhGia",
                table: "DANHGIA",
                newName: "idDanhGia");

            migrationBuilder.RenameIndex(
                name: "IX_DANHGIA_IdSanPham",
                table: "DANHGIA",
                newName: "IX_DANHGIA_idSanPham");

            migrationBuilder.RenameIndex(
                name: "IX_DANHGIA_IdNguoiDung",
                table: "DANHGIA",
                newName: "IX_DANHGIA_idNguoiDung");

            migrationBuilder.RenameColumn(
                name: "ThanhTien",
                table: "CHITIETPHIEUDAT",
                newName: "thanhTien");

            migrationBuilder.RenameColumn(
                name: "SoLuong",
                table: "CHITIETPHIEUDAT",
                newName: "soLuong");

            migrationBuilder.RenameColumn(
                name: "IdSanPham",
                table: "CHITIETPHIEUDAT",
                newName: "idSanPham");

            migrationBuilder.RenameColumn(
                name: "IdPhieuDat",
                table: "CHITIETPHIEUDAT",
                newName: "idPhieuDat");

            migrationBuilder.RenameColumn(
                name: "IdChiTietPhieuDat",
                table: "CHITIETPHIEUDAT",
                newName: "idChiTietPhieuDat");

            migrationBuilder.RenameIndex(
                name: "IX_CHITIETPHIEUDAT_IdSanPham",
                table: "CHITIETPHIEUDAT",
                newName: "IX_CHITIETPHIEUDAT_idSanPham");

            migrationBuilder.RenameIndex(
                name: "IX_CHITIETPHIEUDAT_IdPhieuDat",
                table: "CHITIETPHIEUDAT",
                newName: "IX_CHITIETPHIEUDAT_idPhieuDat");

            migrationBuilder.AlterColumn<decimal>(
                name: "giamGia",
                table: "SANPHAM",
                type: "decimal(10,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "tongTien",
                table: "PHIEUDAT",
                type: "decimal(12,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)");

            migrationBuilder.CreateIndex(
                name: "IX_DONHANG_idNhanVien",
                table: "DONHANG",
                column: "idNhanVien",
                unique: true,
                filter: "[idNhanVien] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_CHITIETPHIEUDAT_PHIEUDAT_idPhieuDat",
                table: "CHITIETPHIEUDAT",
                column: "idPhieuDat",
                principalTable: "PHIEUDAT",
                principalColumn: "idPhieuDat",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CHITIETPHIEUDAT_SANPHAM_idSanPham",
                table: "CHITIETPHIEUDAT",
                column: "idSanPham",
                principalTable: "SANPHAM",
                principalColumn: "idSanPham",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DANHGIA_NGUOIDUNG_idNguoiDung",
                table: "DANHGIA",
                column: "idNguoiDung",
                principalTable: "NGUOIDUNG",
                principalColumn: "idNguoiDung",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DANHGIA_SANPHAM_idSanPham",
                table: "DANHGIA",
                column: "idSanPham",
                principalTable: "SANPHAM",
                principalColumn: "idSanPham",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DANHMUCCHITIET_DANHMUC_idDanhMuc",
                table: "DANHMUCCHITIET",
                column: "idDanhMuc",
                principalTable: "DANHMUC",
                principalColumn: "idDanhMuc",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DIACHIGIAOHANG_NGUOIDUNG_idNguoiDung",
                table: "DIACHIGIAOHANG",
                column: "idNguoiDung",
                principalTable: "NGUOIDUNG",
                principalColumn: "idNguoiDung",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DONHANG_NHANVIEN_idNhanVien",
                table: "DONHANG",
                column: "idNhanVien",
                principalTable: "NHANVIEN",
                principalColumn: "idNhanVien",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DONHANG_PHIEUDAT_idPhieuDat",
                table: "DONHANG",
                column: "idPhieuDat",
                principalTable: "PHIEUDAT",
                principalColumn: "idPhieuDat",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GIOHANG_NGUOIDUNG_idNguoiDung",
                table: "GIOHANG",
                column: "idNguoiDung",
                principalTable: "NGUOIDUNG",
                principalColumn: "idNguoiDung",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GIOHANG_SANPHAM_idSanPham",
                table: "GIOHANG",
                column: "idSanPham",
                principalTable: "SANPHAM",
                principalColumn: "idSanPham",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HINHANHSANPHAM_SANPHAM_idSanPham",
                table: "HINHANHSANPHAM",
                column: "idSanPham",
                principalTable: "SANPHAM",
                principalColumn: "idSanPham",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NGUOIDUNG_TAIKHOAN_idTaiKhoan",
                table: "NGUOIDUNG",
                column: "idTaiKhoan",
                principalTable: "TAIKHOAN",
                principalColumn: "idTaiKhoan",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NHANVIEN_LOAINHANVIEN_idLoaiNhanVien",
                table: "NHANVIEN",
                column: "idLoaiNhanVien",
                principalTable: "LOAINHANVIEN",
                principalColumn: "idLoaiNhanVien",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NHANVIEN_TAIKHOAN_idTaiKhoan",
                table: "NHANVIEN",
                column: "idTaiKhoan",
                principalTable: "TAIKHOAN",
                principalColumn: "idTaiKhoan",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PHIEUDAT_DIACHIGIAOHANG_idDiaChi",
                table: "PHIEUDAT",
                column: "idDiaChi",
                principalTable: "DIACHIGIAOHANG",
                principalColumn: "idDiaChi");

            migrationBuilder.AddForeignKey(
                name: "FK_PHIEUDAT_NGUOIDUNG_idNguoiDung",
                table: "PHIEUDAT",
                column: "idNguoiDung",
                principalTable: "NGUOIDUNG",
                principalColumn: "idNguoiDung");

            migrationBuilder.AddForeignKey(
                name: "FK_SANPHAM_DANHMUCCHITIET_idDanhMucCT",
                table: "SANPHAM",
                column: "idDanhMucCT",
                principalTable: "DANHMUCCHITIET",
                principalColumn: "idDanhMucCT",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SANPHAM_TACGIA_SANPHAM_idSanPham",
                table: "SANPHAM_TACGIA",
                column: "idSanPham",
                principalTable: "SANPHAM",
                principalColumn: "idSanPham",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SANPHAM_TACGIA_TACGIA_idTacGia",
                table: "SANPHAM_TACGIA",
                column: "idTacGia",
                principalTable: "TACGIA",
                principalColumn: "idTacGia",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TAIKHOAN_VAITRO_idVaiTro",
                table: "TAIKHOAN",
                column: "idVaiTro",
                principalTable: "VAITRO",
                principalColumn: "idVaiTro",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CHITIETPHIEUDAT_PHIEUDAT_idPhieuDat",
                table: "CHITIETPHIEUDAT");

            migrationBuilder.DropForeignKey(
                name: "FK_CHITIETPHIEUDAT_SANPHAM_idSanPham",
                table: "CHITIETPHIEUDAT");

            migrationBuilder.DropForeignKey(
                name: "FK_DANHGIA_NGUOIDUNG_idNguoiDung",
                table: "DANHGIA");

            migrationBuilder.DropForeignKey(
                name: "FK_DANHGIA_SANPHAM_idSanPham",
                table: "DANHGIA");

            migrationBuilder.DropForeignKey(
                name: "FK_DANHMUCCHITIET_DANHMUC_idDanhMuc",
                table: "DANHMUCCHITIET");

            migrationBuilder.DropForeignKey(
                name: "FK_DIACHIGIAOHANG_NGUOIDUNG_idNguoiDung",
                table: "DIACHIGIAOHANG");

            migrationBuilder.DropForeignKey(
                name: "FK_DONHANG_NHANVIEN_idNhanVien",
                table: "DONHANG");

            migrationBuilder.DropForeignKey(
                name: "FK_DONHANG_PHIEUDAT_idPhieuDat",
                table: "DONHANG");

            migrationBuilder.DropForeignKey(
                name: "FK_GIOHANG_NGUOIDUNG_idNguoiDung",
                table: "GIOHANG");

            migrationBuilder.DropForeignKey(
                name: "FK_GIOHANG_SANPHAM_idSanPham",
                table: "GIOHANG");

            migrationBuilder.DropForeignKey(
                name: "FK_HINHANHSANPHAM_SANPHAM_idSanPham",
                table: "HINHANHSANPHAM");

            migrationBuilder.DropForeignKey(
                name: "FK_NGUOIDUNG_TAIKHOAN_idTaiKhoan",
                table: "NGUOIDUNG");

            migrationBuilder.DropForeignKey(
                name: "FK_NHANVIEN_LOAINHANVIEN_idLoaiNhanVien",
                table: "NHANVIEN");

            migrationBuilder.DropForeignKey(
                name: "FK_NHANVIEN_TAIKHOAN_idTaiKhoan",
                table: "NHANVIEN");

            migrationBuilder.DropForeignKey(
                name: "FK_PHIEUDAT_DIACHIGIAOHANG_idDiaChi",
                table: "PHIEUDAT");

            migrationBuilder.DropForeignKey(
                name: "FK_PHIEUDAT_NGUOIDUNG_idNguoiDung",
                table: "PHIEUDAT");

            migrationBuilder.DropForeignKey(
                name: "FK_SANPHAM_DANHMUCCHITIET_idDanhMucCT",
                table: "SANPHAM");

            migrationBuilder.DropForeignKey(
                name: "FK_SANPHAM_TACGIA_SANPHAM_idSanPham",
                table: "SANPHAM_TACGIA");

            migrationBuilder.DropForeignKey(
                name: "FK_SANPHAM_TACGIA_TACGIA_idTacGia",
                table: "SANPHAM_TACGIA");

            migrationBuilder.DropForeignKey(
                name: "FK_TAIKHOAN_VAITRO_idVaiTro",
                table: "TAIKHOAN");

            migrationBuilder.DropIndex(
                name: "IX_DONHANG_idNhanVien",
                table: "DONHANG");

            migrationBuilder.RenameColumn(
                name: "tenVaiTro",
                table: "VAITRO",
                newName: "TenVaiTro");

            migrationBuilder.RenameColumn(
                name: "idVaiTro",
                table: "VAITRO",
                newName: "IdVaiTro");

            migrationBuilder.RenameColumn(
                name: "tenDangNhap",
                table: "TAIKHOAN",
                newName: "TenDangNhap");

            migrationBuilder.RenameColumn(
                name: "matKhau",
                table: "TAIKHOAN",
                newName: "MatKhau");

            migrationBuilder.RenameColumn(
                name: "idVaiTro",
                table: "TAIKHOAN",
                newName: "IdVaiTro");

            migrationBuilder.RenameColumn(
                name: "idTaiKhoan",
                table: "TAIKHOAN",
                newName: "IdTaiKhoan");

            migrationBuilder.RenameIndex(
                name: "IX_TAIKHOAN_idVaiTro",
                table: "TAIKHOAN",
                newName: "IX_TAIKHOAN_IdVaiTro");

            migrationBuilder.RenameColumn(
                name: "tenTacGia",
                table: "TACGIA",
                newName: "TenTacGia");

            migrationBuilder.RenameColumn(
                name: "idTacGia",
                table: "TACGIA",
                newName: "IdTacGia");

            migrationBuilder.RenameColumn(
                name: "idTacGia",
                table: "SANPHAM_TACGIA",
                newName: "IdTacGia");

            migrationBuilder.RenameColumn(
                name: "idSanPham",
                table: "SANPHAM_TACGIA",
                newName: "IdSanPham");

            migrationBuilder.RenameIndex(
                name: "IX_SANPHAM_TACGIA_idTacGia",
                table: "SANPHAM_TACGIA",
                newName: "IX_SANPHAM_TACGIA_IdTacGia");

            migrationBuilder.RenameColumn(
                name: "trangThai",
                table: "SANPHAM",
                newName: "TrangThai");

            migrationBuilder.RenameColumn(
                name: "tenSanPham",
                table: "SANPHAM",
                newName: "TenSanPham");

            migrationBuilder.RenameColumn(
                name: "soLuotXem",
                table: "SANPHAM",
                newName: "SoLuotXem");

            migrationBuilder.RenameColumn(
                name: "soLuongDaBan",
                table: "SANPHAM",
                newName: "SoLuongDaBan");

            migrationBuilder.RenameColumn(
                name: "soLuongCon",
                table: "SANPHAM",
                newName: "SoLuongCon");

            migrationBuilder.RenameColumn(
                name: "ngayXuatBan",
                table: "SANPHAM",
                newName: "NgayXuatBan");

            migrationBuilder.RenameColumn(
                name: "moTaChiTiet",
                table: "SANPHAM",
                newName: "MoTaChiTiet");

            migrationBuilder.RenameColumn(
                name: "idDanhMucCT",
                table: "SANPHAM",
                newName: "IdDanhMucCT");

            // Bước 1: Xóa cột giaBan
            migrationBuilder.DropColumn(
                name: "giaBan",
                table: "SANPHAM");

            // Bước 2: Đổi tên các cột về tên cũ
            migrationBuilder.RenameColumn(
                name: "giamGia",
                table: "SANPHAM",
                newName: "GiamGia");

            migrationBuilder.RenameColumn(
                name: "giaGoc",
                table: "SANPHAM",
                newName: "GiaGoc");

            // Bước 3: Tạo lại cột GiaBan với công thức cũ
            migrationBuilder.AddColumn<decimal>(
                name: "GiaBan",
                table: "SANPHAM",
                type: "decimal(12,2)",
                nullable: true,
                computedColumnSql: "CASE WHEN GiamGia IS NULL OR GiamGia = 0 THEN GiaGoc ELSE GiaGoc - (GiaGoc * GiamGia / 100) END",
                stored: true);

            migrationBuilder.RenameColumn(
                name: "idSanPham",
                table: "SANPHAM",
                newName: "IdSanPham");

            migrationBuilder.RenameIndex(
                name: "IX_SANPHAM_idDanhMucCT",
                table: "SANPHAM",
                newName: "IX_SANPHAM_IdDanhMucCT");

            migrationBuilder.RenameColumn(
                name: "tongTien",
                table: "PHIEUDAT",
                newName: "TongTien");

            migrationBuilder.RenameColumn(
                name: "ngayTaoPhieu",
                table: "PHIEUDAT",
                newName: "NgayTaoPhieu");

            migrationBuilder.RenameColumn(
                name: "idNguoiDung",
                table: "PHIEUDAT",
                newName: "IdNguoiDung");

            migrationBuilder.RenameColumn(
                name: "idDiaChi",
                table: "PHIEUDAT",
                newName: "IdDiaChi");

            migrationBuilder.RenameColumn(
                name: "ghiChu",
                table: "PHIEUDAT",
                newName: "GhiChu");

            migrationBuilder.RenameColumn(
                name: "idPhieuDat",
                table: "PHIEUDAT",
                newName: "IdPhieuDat");

            migrationBuilder.RenameIndex(
                name: "IX_PHIEUDAT_idNguoiDung",
                table: "PHIEUDAT",
                newName: "IX_PHIEUDAT_IdNguoiDung");

            migrationBuilder.RenameIndex(
                name: "IX_PHIEUDAT_idDiaChi",
                table: "PHIEUDAT",
                newName: "IX_PHIEUDAT_IdDiaChi");

            migrationBuilder.RenameColumn(
                name: "tenNhanVien",
                table: "NHANVIEN",
                newName: "TenNhanVien");

            migrationBuilder.RenameColumn(
                name: "ngayVaoLam",
                table: "NHANVIEN",
                newName: "NgayVaoLam");

            migrationBuilder.RenameColumn(
                name: "idTaiKhoan",
                table: "NHANVIEN",
                newName: "IdTaiKhoan");

            migrationBuilder.RenameColumn(
                name: "idLoaiNhanVien",
                table: "NHANVIEN",
                newName: "IdLoaiNhanVien");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "NHANVIEN",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "dienThoai",
                table: "NHANVIEN",
                newName: "DienThoai");

            migrationBuilder.RenameColumn(
                name: "idNhanVien",
                table: "NHANVIEN",
                newName: "IdNhanVien");

            migrationBuilder.RenameIndex(
                name: "IX_NHANVIEN_idTaiKhoan",
                table: "NHANVIEN",
                newName: "IX_NHANVIEN_IdTaiKhoan");

            migrationBuilder.RenameIndex(
                name: "IX_NHANVIEN_idLoaiNhanVien",
                table: "NHANVIEN",
                newName: "IX_NHANVIEN_IdLoaiNhanVien");

            migrationBuilder.RenameColumn(
                name: "tenNguoiDung",
                table: "NGUOIDUNG",
                newName: "TenNguoiDung");

            migrationBuilder.RenameColumn(
                name: "ngayDangKy",
                table: "NGUOIDUNG",
                newName: "NgayDangKy");

            migrationBuilder.RenameColumn(
                name: "idTaiKhoan",
                table: "NGUOIDUNG",
                newName: "IdTaiKhoan");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "NGUOIDUNG",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "diaChi",
                table: "NGUOIDUNG",
                newName: "DiaChi");

            migrationBuilder.RenameColumn(
                name: "idNguoiDung",
                table: "NGUOIDUNG",
                newName: "IdNguoiDung");

            migrationBuilder.RenameIndex(
                name: "IX_NGUOIDUNG_idTaiKhoan",
                table: "NGUOIDUNG",
                newName: "IX_NGUOIDUNG_IdTaiKhoan");

            migrationBuilder.RenameIndex(
                name: "IX_NGUOIDUNG_email",
                table: "NGUOIDUNG",
                newName: "IX_NGUOIDUNG_Email");

            migrationBuilder.RenameColumn(
                name: "tenLoaiNhanVien",
                table: "LOAINHANVIEN",
                newName: "TenLoaiNhanVien");

            migrationBuilder.RenameColumn(
                name: "idLoaiNhanVien",
                table: "LOAINHANVIEN",
                newName: "IdLoaiNhanVien");

            migrationBuilder.RenameColumn(
                name: "urlAnh",
                table: "HINHANHSANPHAM",
                newName: "UrlAnh");

            migrationBuilder.RenameColumn(
                name: "idSanPham",
                table: "HINHANHSANPHAM",
                newName: "IdSanPham");

            migrationBuilder.RenameColumn(
                name: "idHinhAnh",
                table: "HINHANHSANPHAM",
                newName: "IdHinhAnh");

            migrationBuilder.RenameIndex(
                name: "IX_HINHANHSANPHAM_idSanPham",
                table: "HINHANHSANPHAM",
                newName: "IX_HINHANHSANPHAM_IdSanPham");

            migrationBuilder.RenameColumn(
                name: "soLuong",
                table: "GIOHANG",
                newName: "SoLuong");

            migrationBuilder.RenameColumn(
                name: "idNguoiDung",
                table: "GIOHANG",
                newName: "IdNguoiDung");

            migrationBuilder.RenameColumn(
                name: "idSanPham",
                table: "GIOHANG",
                newName: "IdSanPham");

            migrationBuilder.RenameIndex(
                name: "IX_GIOHANG_idNguoiDung",
                table: "GIOHANG",
                newName: "IX_GIOHANG_IdNguoiDung");

            migrationBuilder.RenameColumn(
                name: "trangThaiDonHang",
                table: "DONHANG",
                newName: "TrangThaiDonHang");

            migrationBuilder.RenameColumn(
                name: "ngayThanhToan",
                table: "DONHANG",
                newName: "NgayThanhToan");

            migrationBuilder.RenameColumn(
                name: "ngayGiaoHang",
                table: "DONHANG",
                newName: "NgayGiaoHang");

            migrationBuilder.RenameColumn(
                name: "idPhieuDat",
                table: "DONHANG",
                newName: "IdPhieuDat");

            migrationBuilder.RenameColumn(
                name: "idNhanVien",
                table: "DONHANG",
                newName: "IdNhanVien");

            migrationBuilder.RenameColumn(
                name: "idDonHang",
                table: "DONHANG",
                newName: "IdDonHang");

            migrationBuilder.RenameIndex(
                name: "IX_DONHANG_idPhieuDat",
                table: "DONHANG",
                newName: "IX_DONHANG_IdPhieuDat");

            migrationBuilder.RenameColumn(
                name: "sdtGiaoHang",
                table: "DIACHIGIAOHANG",
                newName: "SdtGiaoHang");

            migrationBuilder.RenameColumn(
                name: "idNguoiDung",
                table: "DIACHIGIAOHANG",
                newName: "IdNguoiDung");

            migrationBuilder.RenameColumn(
                name: "hoVaTen",
                table: "DIACHIGIAOHANG",
                newName: "HoVaTen");

            migrationBuilder.RenameColumn(
                name: "diaChiGiaoHang",
                table: "DIACHIGIAOHANG",
                newName: "DiaChiGiaoHang");

            migrationBuilder.RenameColumn(
                name: "idDiaChi",
                table: "DIACHIGIAOHANG",
                newName: "IdDiaChi");

            migrationBuilder.RenameIndex(
                name: "IX_DIACHIGIAOHANG_idNguoiDung",
                table: "DIACHIGIAOHANG",
                newName: "IX_DIACHIGIAOHANG_IdNguoiDung");

            migrationBuilder.RenameColumn(
                name: "tenDanhMucCT",
                table: "DANHMUCCHITIET",
                newName: "TenDanhMucCT");

            migrationBuilder.RenameColumn(
                name: "idDanhMuc",
                table: "DANHMUCCHITIET",
                newName: "IdDanhMuc");

            migrationBuilder.RenameColumn(
                name: "idDanhMucCT",
                table: "DANHMUCCHITIET",
                newName: "IdDanhMucCT");

            migrationBuilder.RenameIndex(
                name: "IX_DANHMUCCHITIET_idDanhMuc",
                table: "DANHMUCCHITIET",
                newName: "IX_DANHMUCCHITIET_IdDanhMuc");

            migrationBuilder.RenameColumn(
                name: "thuTu",
                table: "DANHMUC",
                newName: "ThuTu");

            migrationBuilder.RenameColumn(
                name: "tenDanhMuc",
                table: "DANHMUC",
                newName: "TenDanhMuc");

            migrationBuilder.RenameColumn(
                name: "idDanhMuc",
                table: "DANHMUC",
                newName: "IdDanhMuc");

            migrationBuilder.RenameColumn(
                name: "noiDung",
                table: "DANHGIA",
                newName: "NoiDung");

            migrationBuilder.RenameColumn(
                name: "idSanPham",
                table: "DANHGIA",
                newName: "IdSanPham");

            migrationBuilder.RenameColumn(
                name: "idNguoiDung",
                table: "DANHGIA",
                newName: "IdNguoiDung");

            migrationBuilder.RenameColumn(
                name: "idDanhGia",
                table: "DANHGIA",
                newName: "IdDanhGia");

            migrationBuilder.RenameIndex(
                name: "IX_DANHGIA_idSanPham",
                table: "DANHGIA",
                newName: "IX_DANHGIA_IdSanPham");

            migrationBuilder.RenameIndex(
                name: "IX_DANHGIA_idNguoiDung",
                table: "DANHGIA",
                newName: "IX_DANHGIA_IdNguoiDung");

            migrationBuilder.RenameColumn(
                name: "thanhTien",
                table: "CHITIETPHIEUDAT",
                newName: "ThanhTien");

            migrationBuilder.RenameColumn(
                name: "soLuong",
                table: "CHITIETPHIEUDAT",
                newName: "SoLuong");

            migrationBuilder.RenameColumn(
                name: "idSanPham",
                table: "CHITIETPHIEUDAT",
                newName: "IdSanPham");

            migrationBuilder.RenameColumn(
                name: "idPhieuDat",
                table: "CHITIETPHIEUDAT",
                newName: "IdPhieuDat");

            migrationBuilder.RenameColumn(
                name: "idChiTietPhieuDat",
                table: "CHITIETPHIEUDAT",
                newName: "IdChiTietPhieuDat");

            migrationBuilder.RenameIndex(
                name: "IX_CHITIETPHIEUDAT_idSanPham",
                table: "CHITIETPHIEUDAT",
                newName: "IX_CHITIETPHIEUDAT_IdSanPham");

            migrationBuilder.RenameIndex(
                name: "IX_CHITIETPHIEUDAT_idPhieuDat",
                table: "CHITIETPHIEUDAT",
                newName: "IX_CHITIETPHIEUDAT_IdPhieuDat");

            migrationBuilder.AlterColumn<decimal>(
                name: "GiamGia",
                table: "SANPHAM",
                type: "decimal(10,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "TongTien",
                table: "PHIEUDAT",
                type: "decimal(10,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(12,2)");

            migrationBuilder.CreateIndex(
                name: "IX_DONHANG_IdNhanVien",
                table: "DONHANG",
                column: "IdNhanVien",
                unique: true,
                filter: "[IdNhanVien] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_CHITIETPHIEUDAT_PHIEUDAT_IdPhieuDat",
                table: "CHITIETPHIEUDAT",
                column: "IdPhieuDat",
                principalTable: "PHIEUDAT",
                principalColumn: "IdPhieuDat",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CHITIETPHIEUDAT_SANPHAM_IdSanPham",
                table: "CHITIETPHIEUDAT",
                column: "IdSanPham",
                principalTable: "SANPHAM",
                principalColumn: "IdSanPham",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DANHGIA_NGUOIDUNG_IdNguoiDung",
                table: "DANHGIA",
                column: "IdNguoiDung",
                principalTable: "NGUOIDUNG",
                principalColumn: "IdNguoiDung",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DANHGIA_SANPHAM_IdSanPham",
                table: "DANHGIA",
                column: "IdSanPham",
                principalTable: "SANPHAM",
                principalColumn: "IdSanPham",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DANHMUCCHITIET_DANHMUC_IdDanhMuc",
                table: "DANHMUCCHITIET",
                column: "IdDanhMuc",
                principalTable: "DANHMUC",
                principalColumn: "IdDanhMuc",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DIACHIGIAOHANG_NGUOIDUNG_IdNguoiDung",
                table: "DIACHIGIAOHANG",
                column: "IdNguoiDung",
                principalTable: "NGUOIDUNG",
                principalColumn: "IdNguoiDung",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DONHANG_NHANVIEN_IdNhanVien",
                table: "DONHANG",
                column: "IdNhanVien",
                principalTable: "NHANVIEN",
                principalColumn: "IdNhanVien",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DONHANG_PHIEUDAT_IdPhieuDat",
                table: "DONHANG",
                column: "IdPhieuDat",
                principalTable: "PHIEUDAT",
                principalColumn: "IdPhieuDat",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GIOHANG_NGUOIDUNG_IdNguoiDung",
                table: "GIOHANG",
                column: "IdNguoiDung",
                principalTable: "NGUOIDUNG",
                principalColumn: "IdNguoiDung",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GIOHANG_SANPHAM_IdSanPham",
                table: "GIOHANG",
                column: "IdSanPham",
                principalTable: "SANPHAM",
                principalColumn: "IdSanPham",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HINHANHSANPHAM_SANPHAM_IdSanPham",
                table: "HINHANHSANPHAM",
                column: "IdSanPham",
                principalTable: "SANPHAM",
                principalColumn: "IdSanPham",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NGUOIDUNG_TAIKHOAN_IdTaiKhoan",
                table: "NGUOIDUNG",
                column: "IdTaiKhoan",
                principalTable: "TAIKHOAN",
                principalColumn: "IdTaiKhoan",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NHANVIEN_LOAINHANVIEN_IdLoaiNhanVien",
                table: "NHANVIEN",
                column: "IdLoaiNhanVien",
                principalTable: "LOAINHANVIEN",
                principalColumn: "IdLoaiNhanVien",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NHANVIEN_TAIKHOAN_IdTaiKhoan",
                table: "NHANVIEN",
                column: "IdTaiKhoan",
                principalTable: "TAIKHOAN",
                principalColumn: "IdTaiKhoan",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PHIEUDAT_DIACHIGIAOHANG_IdDiaChi",
                table: "PHIEUDAT",
                column: "IdDiaChi",
                principalTable: "DIACHIGIAOHANG",
                principalColumn: "IdDiaChi");

            migrationBuilder.AddForeignKey(
                name: "FK_PHIEUDAT_NGUOIDUNG_IdNguoiDung",
                table: "PHIEUDAT",
                column: "IdNguoiDung",
                principalTable: "NGUOIDUNG",
                principalColumn: "IdNguoiDung");

            migrationBuilder.AddForeignKey(
                name: "FK_SANPHAM_DANHMUCCHITIET_IdDanhMucCT",
                table: "SANPHAM",
                column: "IdDanhMucCT",
                principalTable: "DANHMUCCHITIET",
                principalColumn: "IdDanhMucCT",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SANPHAM_TACGIA_SANPHAM_IdSanPham",
                table: "SANPHAM_TACGIA",
                column: "IdSanPham",
                principalTable: "SANPHAM",
                principalColumn: "IdSanPham",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SANPHAM_TACGIA_TACGIA_IdTacGia",
                table: "SANPHAM_TACGIA",
                column: "IdTacGia",
                principalTable: "TACGIA",
                principalColumn: "IdTacGia",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TAIKHOAN_VAITRO_IdVaiTro",
                table: "TAIKHOAN",
                column: "IdVaiTro",
                principalTable: "VAITRO",
                principalColumn: "IdVaiTro",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
