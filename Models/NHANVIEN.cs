using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebBookStoreManage.Models
{
    public class NHANVIEN
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("idNhanVien")]
        public int IdNhanVien { get; set; }

        [Required]
        [StringLength(100)]
        [Column("tenNhanVien")]
        public string TenNhanVien { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        [Column("email")]
        public string Email { get; set; }

        [Required]
        [Phone]
        [StringLength(20)]
        [Column("dienThoai")]
        public string DienThoai { get; set; }

        [Required]
        [Column("ngayVaoLam")]
        public DateTime NgayVaoLam { get; set; } = DateTime.UtcNow;

        [Required]
        [ForeignKey("LoaiNhanVien")]
        [Column("idLoaiNhanVien")]
        public int IdLoaiNhanVien { get; set; }
        public LOAINHANVIEN? LoaiNhanVien { get; set; }

        [ForeignKey("TaiKhoan")]
        [Column("idTaiKhoan")]
        public int IdTaiKhoan { get; set; }
        public TAIKHOAN TaiKhoan { get; set; }

        public DONHANG? DonHang { get; set; }
    }
}