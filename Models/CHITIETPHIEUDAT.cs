using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebBookStoreManage.Models
{
    public class CHITIETPHIEUDAT
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("idChiTietPhieuDat")]
        public int IdChiTietPhieuDat { get; set; }

        [Required]
        [Column("soLuong")]
        public int SoLuong { get; set; }

        [Column("idPhieuDat")]
        public int? IdPhieuDat { get; set; }

        [ForeignKey("IdPhieuDat")]
        public PHIEUDAT PhieuDat { get; set; }

        [Required]
        [StringLength(7)]
        [Column("idSanPham")]
        public string IdSanPham { get; set; }

        [ForeignKey("IdSanPham")]
        public SANPHAM SanPham { get; set; }

        [Required]
        [Column("thanhTien")]
        public decimal ThanhTien { get; set; }
    }
}
