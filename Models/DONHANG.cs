using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebBookStoreManage.Models
{
    public enum TrangThaiDonHang
    {
        dangXuLy,
        daDuyet,
        dangVanChuyen,
        hoanThanh,
        daHuy
    }

    public class DONHANG
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("idDonHang")]
        public int IdDonHang { get; set; }

        [Required]
        [Column("trangThaiDonHang")]
        public TrangThaiDonHang TrangThaiDonHang { get; set; } = TrangThaiDonHang.dangXuLy;

        [Column("ngayThanhToan")]
        public DateTime? NgayThanhToan { get; set; }

        [Column("ngayGiaoHang")]
        public DateTime? NgayGiaoHang { get; set; }

        [Required]
        [Column("idPhieuDat")]
        public int IdPhieuDat { get; set; }

        [ForeignKey("IdPhieuDat")]
        public PHIEUDAT PhieuDat { get; set; }

        [Column("idNhanVien")]
        public int? IdNhanVien { get; set; }

        [ForeignKey("IdNhanVien")]
        public NHANVIEN? NhanVien { get; set; }
    }
}
