using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebBookStoreManage.Models;

namespace WebBookStoreManage.Data
{
    public class WebBookStoreManageContext : DbContext
    {
        public WebBookStoreManageContext (DbContextOptions<WebBookStoreManageContext> options)
            : base(options)
        {
        }

        public DbSet<WebBookStoreManage.Models.LOAINHANVIEN> LOAINHANVIEN { get; set; }

        public DbSet<WebBookStoreManage.Models.NHANVIEN> NHANVIEN { get; set; }

        public DbSet<WebBookStoreManage.Models.NGUOIDUNG> NGUOIDUNG { get; set; }

        public DbSet<WebBookStoreManage.Models.VAITRO> VAITRO { get; set; }

        public DbSet<WebBookStoreManage.Models.TAIKHOAN> TAIKHOAN { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CHITIETPHIEUDAT>()
            .Property(c => c.ThanhTien)
            .HasColumnType("decimal(10,2)");

            modelBuilder.Entity<PHIEUDAT>()
                .Property(p => p.TongTien)
                .HasColumnType("decimal(12,2)");

            modelBuilder.Entity<SANPHAM>()
                .Property(s => s.GiaBan)
                .HasColumnType("decimal(12,2)");

            modelBuilder.Entity<SANPHAM>()
                .Property(s => s.GiaGoc)
                .HasColumnType("decimal(12,2)");

            modelBuilder.Entity<SANPHAM>()
                .Property(s => s.GiamGia)
                .HasColumnType("decimal(10,2)");
            // Cấu hình mối quan hệ 1-1 giữa TAIKHOAN và NGUOIDUNG
            modelBuilder.Entity<NGUOIDUNG>()
                .HasOne(n => n.TaiKhoan)
                .WithOne(t => t.NguoiDung)
                .HasForeignKey<NGUOIDUNG>(n => n.IdTaiKhoan);

            // Cấu hình mối quan hệ 1-1 giữa TAIKHOAN và NHANVIEN
            modelBuilder.Entity<NHANVIEN>()
                .HasOne(n => n.TaiKhoan)
                .WithOne(t => t.NhanVien)
                .HasForeignKey<NHANVIEN>(n => n.IdTaiKhoan);

            // Đảm bảo IdTaiKhoan là duy nhất trong cả NGUOIDUNG và NHANVIEN
            modelBuilder.Entity<NGUOIDUNG>()
                .HasIndex(n => n.IdTaiKhoan)
                .IsUnique();

            modelBuilder.Entity<NHANVIEN>()
                .HasIndex(n => n.IdTaiKhoan)
                .IsUnique();
            // Cấu hình khóa ghép cho bảng GIOHANG: khóa gồm cột IdSanPham và IdNguoiDung
            modelBuilder.Entity<GIOHANG>()
                .HasKey(g => new { g.IdSanPham, g.IdNguoiDung });

            // Cấu hình các quan hệ nếu cần (ví dụ, quan hệ giữa GIOHANG và SANPHAM, NGUOIDUNG)
            modelBuilder.Entity<GIOHANG>()
                .HasOne(g => g.SanPham)
                .WithMany(s => s.GioHangs)
                .HasForeignKey(g => g.IdSanPham);

            modelBuilder.Entity<GIOHANG>()
                .HasOne(g => g.NguoiDung)
                .WithMany(n => n.GioHangs)
                .HasForeignKey(g => g.IdNguoiDung);

            // Cấu hình quan hệ PHIEUDAT -> DIACHIGIAOHANG sử dụng cascade delete nếu cần
            modelBuilder.Entity<PHIEUDAT>()
                .HasOne(p => p.DiaChiGiaoHang)
                .WithMany() // Nếu DIACHIGIAOHANG không có navigation property cho PHIEUDAT
                .HasForeignKey(p => p.IdDiaChi)
                .OnDelete(DeleteBehavior.NoAction);

            // Cấu hình quan hệ PHIEUDAT -> NGUOIDUNG: không dùng cascade delete
            modelBuilder.Entity<PHIEUDAT>()
                .HasOne(p => p.NguoiDung)
                .WithMany(n => n.PhieuDats)
                .HasForeignKey(p => p.IdNguoiDung)
                .OnDelete(DeleteBehavior.NoAction); // hoặc DeleteBehavior.NoAction

            // Cấu hình khóa chính cho bảng trung gian
            modelBuilder.Entity<SANPHAM_TACGIA>()
                .HasKey(st => new { st.IdSanPham, st.IdTacGia });

            // Cấu hình quan hệ giữa SANPHAM và SANPHAM_TACGIA
            modelBuilder.Entity<SANPHAM_TACGIA>()
                .HasOne(st => st.SanPham)
                .WithMany(s => s.SanPhamTacGias)
                .HasForeignKey(st => st.IdSanPham);

            // Cấu hình quan hệ giữa TACGIA và SANPHAM_TACGIA
            modelBuilder.Entity<SANPHAM_TACGIA>()
                .HasOne(st => st.TacGia)
                .WithMany(t => t.SanPhamTacGias)
                .HasForeignKey(st => st.IdTacGia);

            modelBuilder.Entity<SANPHAM>()
                .Property(s => s.GiaBan)
                .HasComputedColumnSql("CASE WHEN GiamGia IS NULL OR GiamGia = 0 THEN GiaGoc ELSE GiaGoc - (GiaGoc * GiamGia / 100) END", stored: true);

            modelBuilder.Entity<NHANVIEN>()
                .HasMany(nv => nv.DonHangs)
                .WithOne(dh => dh.NhanVien)
                .HasForeignKey(dh => dh.IdNhanVien)
                .OnDelete(DeleteBehavior.NoAction);

        }

        public DbSet<WebBookStoreManage.Models.DANHMUC> DANHMUC { get; set; }

        public DbSet<WebBookStoreManage.Models.DANHMUCCHITIET> DANHMUCCHITIET { get; set; }

        public DbSet<WebBookStoreManage.Models.TACGIA> TACGIA { get; set; }

        public DbSet<WebBookStoreManage.Models.SANPHAM> SANPHAM { get; set; }

        public DbSet<WebBookStoreManage.Models.HINHANHSANPHAM> HINHANHSANPHAM { get; set; }

        public DbSet<WebBookStoreManage.Models.GIOHANG> GIOHANG { get; set; }

        public DbSet<WebBookStoreManage.Models.DANHGIA> DANHGIA { get; set; }

        public DbSet<WebBookStoreManage.Models.DIACHIGIAOHANG> DIACHIGIAOHANG { get; set; }

        public DbSet<WebBookStoreManage.Models.PHIEUDAT> PHIEUDAT { get; set; }

        public DbSet<WebBookStoreManage.Models.CHITIETPHIEUDAT> CHITIETPHIEUDAT { get; set; }

        public DbSet<WebBookStoreManage.Models.DONHANG> DONHANG { get; set; }

        public DbSet<WebBookStoreManage.Models.SANPHAM_TACGIA> SANPHAM_TACGIA { get; set; }

    }
}
