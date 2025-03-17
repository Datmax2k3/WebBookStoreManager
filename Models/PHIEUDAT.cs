using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebBookStoreManage.Models
{
    public class PHIEUDAT
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("idPhieuDat")]
        public int IdPhieuDat { get; set; }

        [Required]
        [Column("ngayTaoPhieu")]
        public DateTime NgayTaoPhieu { get; set; }

        [Column("ghiChu")]
        public string GhiChu { get; set; }

        [Required]
        [Column("idDiaChi")]
        public int IdDiaChi { get; set; }

        [ForeignKey("IdDiaChi")]
        public DIACHIGIAOHANG DiaChiGiaoHang { get; set; }

        [Required]
        [Column("idNguoiDung")]
        public int IdNguoiDung { get; set; }

        [ForeignKey("IdNguoiDung")]
        public NGUOIDUNG NguoiDung { get; set; }

        [Required]
        [Column("tongTien")]
        public decimal TongTien { get; set; }

        public ICollection<CHITIETPHIEUDAT> ChiTietPhieuDats { get; set; }
        public ICollection<DONHANG> DonHangs { get; set; }
    }
}
