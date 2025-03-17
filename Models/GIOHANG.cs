using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebBookStoreManage.Models
{
    public class GIOHANG
    {
        [Key, Column("idSanPham", Order = 0)]
        [StringLength(7)]
        public string IdSanPham { get; set; }

        [Key, Column("idNguoiDung", Order = 1)]
        public int IdNguoiDung { get; set; }

        [Required]
        [Column("soLuong")]
        public int SoLuong { get; set; }

        [ForeignKey("IdSanPham")]
        public SANPHAM SanPham { get; set; }

        [ForeignKey("IdNguoiDung")]
        public NGUOIDUNG NguoiDung { get; set; }
    }
}
