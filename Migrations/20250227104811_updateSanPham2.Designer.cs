﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebBookStoreManage.Data;

namespace WebBookStoreManage.Migrations
{
    [DbContext(typeof(WebBookStoreManageContext))]
    [Migration("20250227104811_updateSanPham2")]
    partial class updateSanPham2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebBookStoreManage.Models.CHITIETPHIEUDAT", b =>
                {
                    b.Property<int>("IdChiTietPhieuDat")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdPhieuDat")
                        .HasColumnType("int");

                    b.Property<string>("IdSanPham")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.Property<decimal>("ThanhTien")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("IdChiTietPhieuDat");

                    b.HasIndex("IdPhieuDat");

                    b.HasIndex("IdSanPham");

                    b.ToTable("CHITIETPHIEUDAT");
                });

            modelBuilder.Entity("WebBookStoreManage.Models.DANHGIA", b =>
                {
                    b.Property<int>("IdDanhGia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdNguoiDung")
                        .HasColumnType("int");

                    b.Property<string>("IdSanPham")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.Property<string>("NoiDung")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdDanhGia");

                    b.HasIndex("IdNguoiDung");

                    b.HasIndex("IdSanPham");

                    b.ToTable("DANHGIA");
                });

            modelBuilder.Entity("WebBookStoreManage.Models.DANHMUC", b =>
                {
                    b.Property<int>("IdDanhMuc")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TenDanhMuc")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("ThuTu")
                        .HasColumnType("int");

                    b.HasKey("IdDanhMuc");

                    b.ToTable("DANHMUC");
                });

            modelBuilder.Entity("WebBookStoreManage.Models.DANHMUCCHITIET", b =>
                {
                    b.Property<int>("IdDanhMucCT")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("IdDanhMuc")
                        .HasColumnType("int");

                    b.Property<string>("TenDanhMucCT")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdDanhMucCT");

                    b.HasIndex("IdDanhMuc");

                    b.ToTable("DANHMUCCHITIET");
                });

            modelBuilder.Entity("WebBookStoreManage.Models.DIACHIGIAOHANG", b =>
                {
                    b.Property<int>("IdDiaChi")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DiaChiGiaoHang")
                        .HasMaxLength(225)
                        .HasColumnType("nvarchar(225)");

                    b.Property<string>("HoVaTen")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("IdNguoiDung")
                        .HasColumnType("int");

                    b.Property<string>("SdtGiaoHang")
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.HasKey("IdDiaChi");

                    b.HasIndex("IdNguoiDung");

                    b.ToTable("DIACHIGIAOHANG");
                });

            modelBuilder.Entity("WebBookStoreManage.Models.DONHANG", b =>
                {
                    b.Property<int>("IdDonHang")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("IdNhanVien")
                        .HasColumnType("int");

                    b.Property<int>("IdPhieuDat")
                        .HasColumnType("int");

                    b.Property<DateTime?>("NgayGiaoHang")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgayThanhToan")
                        .HasColumnType("datetime2");

                    b.Property<int>("TrangThaiDonHang")
                        .HasColumnType("int");

                    b.HasKey("IdDonHang");

                    b.HasIndex("IdNhanVien")
                        .IsUnique()
                        .HasFilter("[IdNhanVien] IS NOT NULL");

                    b.HasIndex("IdPhieuDat");

                    b.ToTable("DONHANG");
                });

            modelBuilder.Entity("WebBookStoreManage.Models.GIOHANG", b =>
                {
                    b.Property<string>("IdSanPham")
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.Property<int>("IdNguoiDung")
                        .HasColumnType("int");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.HasKey("IdSanPham", "IdNguoiDung");

                    b.HasIndex("IdNguoiDung");

                    b.ToTable("GIOHANG");
                });

            modelBuilder.Entity("WebBookStoreManage.Models.HINHANHSANPHAM", b =>
                {
                    b.Property<string>("IdHinhAnh")
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.Property<string>("IdSanPham")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.Property<string>("UrlAnh")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdHinhAnh");

                    b.HasIndex("IdSanPham");

                    b.ToTable("HINHANHSANPHAM");
                });

            modelBuilder.Entity("WebBookStoreManage.Models.LOAINHANVIEN", b =>
                {
                    b.Property<int>("IdLoaiNhanVien")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TenLoaiNhanVien")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdLoaiNhanVien");

                    b.ToTable("LOAINHANVIEN");
                });

            modelBuilder.Entity("WebBookStoreManage.Models.NGUOIDUNG", b =>
                {
                    b.Property<int>("IdNguoiDung")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DiaChi")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("NgayDangKy")
                        .HasColumnType("datetime2");

                    b.Property<string>("TenNguoiDung")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdNguoiDung");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("NGUOIDUNG");
                });

            modelBuilder.Entity("WebBookStoreManage.Models.NHANVIEN", b =>
                {
                    b.Property<int>("IdNhanVien")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DienThoai")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("IdLoaiNhanVien")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayVaoLam")
                        .HasColumnType("datetime2");

                    b.Property<string>("TenNhanVien")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdNhanVien");

                    b.HasIndex("IdLoaiNhanVien");

                    b.ToTable("NHANVIEN");
                });

            modelBuilder.Entity("WebBookStoreManage.Models.PHIEUDAT", b =>
                {
                    b.Property<int>("IdPhieuDat")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GhiChu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdDiaChi")
                        .HasColumnType("int");

                    b.Property<int>("IdNguoiDung")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayTaoPhieu")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("TongTien")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("IdPhieuDat");

                    b.HasIndex("IdDiaChi");

                    b.HasIndex("IdNguoiDung");

                    b.ToTable("PHIEUDAT");
                });

            modelBuilder.Entity("WebBookStoreManage.Models.SANPHAM", b =>
                {
                    b.Property<string>("IdSanPham")
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.Property<decimal>("GiaGoc")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("GiamGia")
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("IdDanhMucCT")
                        .HasColumnType("int");

                    b.Property<string>("MoTaChiTiet")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("NgayXuatBan")
                        .HasColumnType("datetime2");

                    b.Property<int>("SoLuongCon")
                        .HasColumnType("int");

                    b.Property<int>("SoLuongDaBan")
                        .HasColumnType("int");

                    b.Property<int>("SoLuotXem")
                        .HasColumnType("int");

                    b.Property<string>("TenSanPham")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("TrangThai")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("hinhAnh")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdSanPham");

                    b.HasIndex("IdDanhMucCT");

                    b.ToTable("SANPHAM");
                });

            modelBuilder.Entity("WebBookStoreManage.Models.SANPHAM_TACGIA", b =>
                {
                    b.Property<string>("IdSanPham")
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.Property<string>("IdTacGia")
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.HasKey("IdSanPham", "IdTacGia");

                    b.HasIndex("IdTacGia");

                    b.ToTable("SANPHAM_TACGIA");
                });

            modelBuilder.Entity("WebBookStoreManage.Models.TACGIA", b =>
                {
                    b.Property<string>("IdTacGia")
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.Property<string>("TenTacGia")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdTacGia");

                    b.ToTable("TACGIA");
                });

            modelBuilder.Entity("WebBookStoreManage.Models.TAIKHOAN", b =>
                {
                    b.Property<int>("IdTaiKhoan")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("IdNguoiDung")
                        .HasColumnType("int");

                    b.Property<int?>("IdNhanVien")
                        .HasColumnType("int");

                    b.Property<int>("IdVaiTro")
                        .HasColumnType("int");

                    b.Property<string>("MatKhau")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("TenDangNhap")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdTaiKhoan");

                    b.HasIndex("IdNguoiDung")
                        .IsUnique()
                        .HasFilter("[IdNguoiDung] IS NOT NULL");

                    b.HasIndex("IdNhanVien")
                        .IsUnique()
                        .HasFilter("[IdNhanVien] IS NOT NULL");

                    b.HasIndex("IdVaiTro");

                    b.ToTable("TAIKHOAN");
                });

            modelBuilder.Entity("WebBookStoreManage.Models.VAITRO", b =>
                {
                    b.Property<int>("IdVaiTro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TenVaiTro")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdVaiTro");

                    b.ToTable("VAITRO");
                });

            modelBuilder.Entity("WebBookStoreManage.Models.CHITIETPHIEUDAT", b =>
                {
                    b.HasOne("WebBookStoreManage.Models.PHIEUDAT", "PhieuDat")
                        .WithMany("ChiTietPhieuDats")
                        .HasForeignKey("IdPhieuDat")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebBookStoreManage.Models.SANPHAM", "SanPham")
                        .WithMany("ChiTietPhieuDats")
                        .HasForeignKey("IdSanPham")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PhieuDat");

                    b.Navigation("SanPham");
                });

            modelBuilder.Entity("WebBookStoreManage.Models.DANHGIA", b =>
                {
                    b.HasOne("WebBookStoreManage.Models.NGUOIDUNG", "NguoiDung")
                        .WithMany("DanhGias")
                        .HasForeignKey("IdNguoiDung")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebBookStoreManage.Models.SANPHAM", "SanPham")
                        .WithMany("DanhGias")
                        .HasForeignKey("IdSanPham")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NguoiDung");

                    b.Navigation("SanPham");
                });

            modelBuilder.Entity("WebBookStoreManage.Models.DANHMUCCHITIET", b =>
                {
                    b.HasOne("WebBookStoreManage.Models.DANHMUC", "DanhMuc")
                        .WithMany("DanhMucChiTiets")
                        .HasForeignKey("IdDanhMuc");

                    b.Navigation("DanhMuc");
                });

            modelBuilder.Entity("WebBookStoreManage.Models.DIACHIGIAOHANG", b =>
                {
                    b.HasOne("WebBookStoreManage.Models.NGUOIDUNG", "NguoiDung")
                        .WithMany("DiaChiGiaoHangs")
                        .HasForeignKey("IdNguoiDung")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NguoiDung");
                });

            modelBuilder.Entity("WebBookStoreManage.Models.DONHANG", b =>
                {
                    b.HasOne("WebBookStoreManage.Models.NHANVIEN", "NhanVien")
                        .WithOne("DonHang")
                        .HasForeignKey("WebBookStoreManage.Models.DONHANG", "IdNhanVien");

                    b.HasOne("WebBookStoreManage.Models.PHIEUDAT", "PhieuDat")
                        .WithMany("DonHangs")
                        .HasForeignKey("IdPhieuDat")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NhanVien");

                    b.Navigation("PhieuDat");
                });

            modelBuilder.Entity("WebBookStoreManage.Models.GIOHANG", b =>
                {
                    b.HasOne("WebBookStoreManage.Models.NGUOIDUNG", "NguoiDung")
                        .WithMany("GioHangs")
                        .HasForeignKey("IdNguoiDung")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebBookStoreManage.Models.SANPHAM", "SanPham")
                        .WithMany("GioHangs")
                        .HasForeignKey("IdSanPham")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NguoiDung");

                    b.Navigation("SanPham");
                });

            modelBuilder.Entity("WebBookStoreManage.Models.HINHANHSANPHAM", b =>
                {
                    b.HasOne("WebBookStoreManage.Models.SANPHAM", "SanPham")
                        .WithMany("HinhAnhSanPhams")
                        .HasForeignKey("IdSanPham")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SanPham");
                });

            modelBuilder.Entity("WebBookStoreManage.Models.NHANVIEN", b =>
                {
                    b.HasOne("WebBookStoreManage.Models.LOAINHANVIEN", "LoaiNhanVien")
                        .WithMany("NhanViens")
                        .HasForeignKey("IdLoaiNhanVien")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LoaiNhanVien");
                });

            modelBuilder.Entity("WebBookStoreManage.Models.PHIEUDAT", b =>
                {
                    b.HasOne("WebBookStoreManage.Models.DIACHIGIAOHANG", "DiaChiGiaoHang")
                        .WithMany()
                        .HasForeignKey("IdDiaChi")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("WebBookStoreManage.Models.NGUOIDUNG", "NguoiDung")
                        .WithMany("PhieuDats")
                        .HasForeignKey("IdNguoiDung")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("DiaChiGiaoHang");

                    b.Navigation("NguoiDung");
                });

            modelBuilder.Entity("WebBookStoreManage.Models.SANPHAM", b =>
                {
                    b.HasOne("WebBookStoreManage.Models.DANHMUCCHITIET", "DanhMucChiTiet")
                        .WithMany("SanPhams")
                        .HasForeignKey("IdDanhMucCT")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DanhMucChiTiet");
                });

            modelBuilder.Entity("WebBookStoreManage.Models.SANPHAM_TACGIA", b =>
                {
                    b.HasOne("WebBookStoreManage.Models.SANPHAM", "SanPham")
                        .WithMany("SanPhamTacGias")
                        .HasForeignKey("IdSanPham")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebBookStoreManage.Models.TACGIA", "TacGia")
                        .WithMany("SanPhamTacGias")
                        .HasForeignKey("IdTacGia")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SanPham");

                    b.Navigation("TacGia");
                });

            modelBuilder.Entity("WebBookStoreManage.Models.TAIKHOAN", b =>
                {
                    b.HasOne("WebBookStoreManage.Models.NGUOIDUNG", "NguoiDung")
                        .WithOne("TaiKhoan")
                        .HasForeignKey("WebBookStoreManage.Models.TAIKHOAN", "IdNguoiDung");

                    b.HasOne("WebBookStoreManage.Models.NHANVIEN", "NhanVien")
                        .WithOne("TaiKhoan")
                        .HasForeignKey("WebBookStoreManage.Models.TAIKHOAN", "IdNhanVien");

                    b.HasOne("WebBookStoreManage.Models.VAITRO", "VaiTro")
                        .WithMany("TaiKhoans")
                        .HasForeignKey("IdVaiTro")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NguoiDung");

                    b.Navigation("NhanVien");

                    b.Navigation("VaiTro");
                });

            modelBuilder.Entity("WebBookStoreManage.Models.DANHMUC", b =>
                {
                    b.Navigation("DanhMucChiTiets");
                });

            modelBuilder.Entity("WebBookStoreManage.Models.DANHMUCCHITIET", b =>
                {
                    b.Navigation("SanPhams");
                });

            modelBuilder.Entity("WebBookStoreManage.Models.LOAINHANVIEN", b =>
                {
                    b.Navigation("NhanViens");
                });

            modelBuilder.Entity("WebBookStoreManage.Models.NGUOIDUNG", b =>
                {
                    b.Navigation("DanhGias");

                    b.Navigation("DiaChiGiaoHangs");

                    b.Navigation("GioHangs");

                    b.Navigation("PhieuDats");

                    b.Navigation("TaiKhoan");
                });

            modelBuilder.Entity("WebBookStoreManage.Models.NHANVIEN", b =>
                {
                    b.Navigation("DonHang");

                    b.Navigation("TaiKhoan");
                });

            modelBuilder.Entity("WebBookStoreManage.Models.PHIEUDAT", b =>
                {
                    b.Navigation("ChiTietPhieuDats");

                    b.Navigation("DonHangs");
                });

            modelBuilder.Entity("WebBookStoreManage.Models.SANPHAM", b =>
                {
                    b.Navigation("ChiTietPhieuDats");

                    b.Navigation("DanhGias");

                    b.Navigation("GioHangs");

                    b.Navigation("HinhAnhSanPhams");

                    b.Navigation("SanPhamTacGias");
                });

            modelBuilder.Entity("WebBookStoreManage.Models.TACGIA", b =>
                {
                    b.Navigation("SanPhamTacGias");
                });

            modelBuilder.Entity("WebBookStoreManage.Models.VAITRO", b =>
                {
                    b.Navigation("TaiKhoans");
                });
#pragma warning restore 612, 618
        }
    }
}
