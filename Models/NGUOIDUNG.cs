using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebBookStoreManage.Models
{
    [Index(nameof(Email), IsUnique = true)]
    public class NGUOIDUNG
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("idNguoiDung")]
        public int IdNguoiDung { get; set; }

        [Required]
        [StringLength(100)]
        [Column("tenNguoiDung")]
        public string TenNguoiDung { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        [Column("email")]
        public string Email { get; set; }

        [StringLength(255)]
        [Column("diaChi")]
        public string? DiaChi { get; set; }

        [Required]
        [Column("ngayDangKy")]
        public DateTime NgayDangKy { get; set; } = DateTime.Now;

        [ForeignKey("TaiKhoan")]
        [Column("idTaiKhoan")]
        public int IdTaiKhoan { get; set; }
        public TAIKHOAN TaiKhoan { get; set; }

        public ICollection<GIOHANG> GioHangs { get; set; }
        public ICollection<DANHGIA> DanhGias { get; set; }
        public ICollection<DIACHIGIAOHANG> DiaChiGiaoHangs { get; set; }
        public ICollection<PHIEUDAT> PhieuDats { get; set; }
    }
}