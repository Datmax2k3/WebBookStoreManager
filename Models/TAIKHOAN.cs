using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebBookStoreManage.Models
{
    public class TAIKHOAN
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("idTaiKhoan")]
        public int IdTaiKhoan { get; set; }

        [Required]
        [StringLength(100)]
        [Column("tenDangNhap")]
        public string TenDangNhap { get; set; }

        [Required]
        [StringLength(255)]
        [Column("matKhau")]
        public string MatKhau { get; set; }

        [Required]
        [ForeignKey("VaiTro")]
        [Column("idVaiTro")]
        public int IdVaiTro { get; set; }
        public VAITRO VaiTro { get; set; }

        public NGUOIDUNG? NguoiDung { get; set; }
        public NHANVIEN? NhanVien { get; set; }
    }
}