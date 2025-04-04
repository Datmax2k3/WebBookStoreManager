using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBookStoreManage.Data;
using WebBookStoreManage.Models;
using WebBookStoreManage.ViewModels;

namespace WebBookStoreManage.Controllers
{
    public class DirectOrderController : Controller
    {
        private readonly WebBookStoreManageContext _context;

        public DirectOrderController(WebBookStoreManageContext context)
        {
            _context = context;
        }

        // GET: DirectOrder/Create
        public async Task<IActionResult> Create()
        {
            // Lấy danh sách sản phẩm có trong kho
            var products = await _context.SANPHAM
                .Where(p => p.SoLuongCon > 0)
                .OrderBy(p => p.TenSanPham)
                .ToListAsync();

            // Lấy danh sách nhân viên
            var staffList = await _context.NHANVIEN
                .Select(s => new SelectListItem
                {
                    Value = s.IdNhanVien.ToString(),
                    Text = s.TenNhanVien
                })
                .ToListAsync();

            ViewBag.Products = products;
            ViewBag.StaffList = new SelectList(staffList, "Value", "Text");

            return View(new DirectOrderViewModel());
        }

        // POST: DirectOrder/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateDirectOrder(DirectOrderViewModel model)
        {
            if (ModelState.IsValid)
            {
                using var transaction = await _context.Database.BeginTransactionAsync();
                try
                {
                    // Kiểm tra sản phẩm và số lượng
                    foreach (var item in model.OrderItems)
                    {
                        var product = await _context.SANPHAM.FindAsync(item.ProductId);
                        if (product == null)
                        {
                            ModelState.AddModelError("", $"Sản phẩm không tồn tại: {item.ProductId}");
                            return await RedirectToCreateWithError();
                        }

                        if (product.SoLuongCon < item.Quantity)
                        {
                            ModelState.AddModelError("", $"Sản phẩm '{product.TenSanPham}' chỉ còn {product.SoLuongCon} trong kho");
                            return await RedirectToCreateWithError();
                        }
                    }

                    // Tạo phiếu đặt mới
                    var phieuDat = new PHIEUDAT
                    {
                        NgayTaoPhieu = model.OrderDate,
                        GhiChu = model.Note,
                        TongTien = model.TotalAmount,
                    };

                    _context.PHIEUDAT.Add(phieuDat);
                    await _context.SaveChangesAsync();

                    // Tạo chi tiết phiếu đặt
                    foreach (var item in model.OrderItems)
                    {
                        var product = await _context.SANPHAM.FindAsync(item.ProductId);

                        var chiTietPhieuDat = new CHITIETPHIEUDAT
                        {
                            IdPhieuDat = phieuDat.IdPhieuDat,
                            IdSanPham = item.ProductId,
                            SoLuong = item.Quantity,
                            ThanhTien = item.Amount
                        };

                        _context.CHITIETPHIEUDAT.Add(chiTietPhieuDat);

                        // Cập nhật số lượng sản phẩm
                        product.SoLuongCon -= item.Quantity;
                        product.SoLuongDaBan += item.Quantity;
                        _context.SANPHAM.Update(product);
                    }

                    // Tạo đơn hàng
                    var donHang = new DONHANG
                    {
                        IdPhieuDat = phieuDat.IdPhieuDat,
                        TrangThaiDonHang = TrangThaiDonHang.hoanThanh, // Đơn hàng trực tiếp nên mặc định đã duyệt
                        IdNhanVien = model.StaffId,
                        NgayThanhToan = DateTime.Now // Đơn hàng trực tiếp nên mặc định đã thanh toán
                    };

                    _context.DONHANG.Add(donHang);
                    await _context.SaveChangesAsync();

                    await transaction.CommitAsync();

                    // Chuyển hướng đến trang xác nhận hoặc trang chi tiết đơn hàng
                    return RedirectToAction("EmployeeOrderDetails", "Order", new { id = donHang.IdDonHang + 1 });
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    ModelState.AddModelError("", $"Lỗi: {ex.Message}");
                    return await RedirectToCreateWithError();
                }
            }

            return await RedirectToCreateWithError();
        }

        private async Task<IActionResult> RedirectToCreateWithError()
        {
            // Lấy lại danh sách sản phẩm và nhân viên khi có lỗi
            ViewBag.Products = await _context.SANPHAM
                .Where(p => p.SoLuongCon > 0)
                .OrderBy(p => p.TenSanPham)
                .ToListAsync();

            ViewBag.StaffList = new SelectList(await _context.NHANVIEN
                .Select(s => new SelectListItem
                {
                    Value = s.IdNhanVien.ToString(),
                    Text = s.TenNhanVien
                })
                .ToListAsync(), "Value", "Text");

            return View("Create");
        }
    }
}