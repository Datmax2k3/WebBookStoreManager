using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBookStoreManage.Models;

namespace WebBookStoreManage.ViewModels
{
    public class OrderViewModel
    {
        public int IdPhieuDat => PHIEUDAT?.IdPhieuDat ?? 0;
        public DateTime NgayTaoPhieu => PHIEUDAT?.NgayTaoPhieu ?? DateTime.MinValue;
        public string GhiChu => PHIEUDAT?.GhiChu ?? "Không có ghi chú";
        public decimal TongTien => PHIEUDAT?.TongTien ?? 0;
        public string TrangThai => DONHANG?.TrangThaiDonHang.ToString() ?? "Chưa có trạng thái";

        public string HoTen => PHIEUDAT?.DiaChiGiaoHang?.HoVaTen ?? "Không có thông tin";
        public string DiaChi => PHIEUDAT?.DiaChiGiaoHang?.DiaChiGiaoHang ?? "Không có địa chỉ";
        public string SoDienThoai => PHIEUDAT?.DiaChiGiaoHang?.SdtGiaoHang ?? "Không có số điện thoại";

        public List<CHITIETPHIEUDAT> ChiTietPhieuDats => PHIEUDAT?.ChiTietPhieuDats?.ToList() ?? new List<CHITIETPHIEUDAT>();
        public PHIEUDAT PHIEUDAT { get; set; }
        public DONHANG DONHANG { get; set; }
    }
}
