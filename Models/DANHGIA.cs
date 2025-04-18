using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebBookStoreManage.Models
{
    public class DANHGIA
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("idDanhGia")]
        public int IdDanhGia { get; set; }

        [Column("noiDung")]
        public string NoiDung { get; set; }

        [Required]
        [StringLength(7)]
        [Column("idSanPham")]
        public string IdSanPham { get; set; }

        [Required]
        [Column("idNguoiDung")]
        public int IdNguoiDung { get; set; }

        [Column("thoiGian")]
        public DateTime ThoiGian { get; set; } = DateTime.Now;

        [ForeignKey("IdSanPham")]
        public SANPHAM SanPham { get; set; }

        [ForeignKey("IdNguoiDung")]
        public NGUOIDUNG NguoiDung { get; set; }
    }
}
