using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebBookStoreManage.Models
{
    public class SANPHAM
    {
        [Key]
        [StringLength(7)]
        [Column("idSanPham")]
        public string IdSanPham { get; set; }

        [Required]
        [Column("idDanhMucCT")]
        public int IdDanhMucCT { get; set; }

        [ForeignKey("IdDanhMucCT")]
        public DANHMUCCHITIET DanhMucChiTiet { get; set; }

        [Required]
        [StringLength(500)]
        [Column("tenSanPham")]
        public string TenSanPham { get; set; }

        [Required]
        [Column("giaGoc")]
        public decimal GiaGoc { get; set; }

        [Column("giamGia")]
        public decimal GiamGia { get; set; } = 0.00m;

        [Column("giaBan")]
        public decimal? GiaBan { get; set; }

        [Column("ngayXuatBan")]
        public DateTime? NgayXuatBan { get; set; }

        [Column("soLuotXem")]
        public int SoLuotXem { get; set; } = 0;

        [Column("soLuongCon")]
        public int SoLuongCon { get; set; } = 0;

        [Column("soLuongDaBan")]
        public int SoLuongDaBan { get; set; } = 0;

        [Column("moTaChiTiet")]
        public string MoTaChiTiet { get; set; }

        [Required]
        [Column("trangThai")]
        public string TrangThai { get; set; } = "conHang";

        [StringLength(500)]
        [Column("hinhAnh")]
        public string hinhAnh { get; set; }

        public ICollection<HINHANHSANPHAM> HinhAnhSanPhams { get; set; }
        public ICollection<CHITIETPHIEUDAT> ChiTietPhieuDats { get; set; }
        public ICollection<DANHGIA> DanhGias { get; set; }
        public ICollection<GIOHANG> GioHangs { get; set; }
        public ICollection<SANPHAM_TACGIA> SanPhamTacGias { get; set; }
    }
}
