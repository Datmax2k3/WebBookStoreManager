#pragma checksum "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\PaymentSuccess.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e2d6705ed2884eb8b173130d7537f33c3348a172"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Order_PaymentSuccess), @"mvc.1.0.view", @"/Views/Order/PaymentSuccess.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\_ViewImports.cshtml"
using WebBookStoreManage;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\_ViewImports.cshtml"
using WebBookStoreManage.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e2d6705ed2884eb8b173130d7537f33c3348a172", @"/Views/Order/PaymentSuccess.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"64d8f35278a37e92fb38f314442aaace3ec2b173", @"/Views/_ViewImports.cshtml")]
    public class Views_Order_PaymentSuccess : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WebBookStoreManage.Models.DONHANG>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\PaymentSuccess.cshtml"
  
    ViewData["Title"] = "Đặt hàng thành công";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<!-- Header -->
<header class=""d-flex justify-content-between align-items-center py-3 border-bottom"">
    <div class=""logo"">
    </div>
    <div class=""steps"">
        <span class=""step text-muted"">1. Điền thông tin</span>
        <span class=""step text-muted"">2. Thanh toán</span>
        <span class=""step text-dark fw-bold"">3. Hoàn tất</span>
    </div>
    <div class=""hotline"">
    </div>
</header>

<div class=""container mt-5"">
    <div class=""row justify-content-center"">
        <div class=""col-md-8"">
            <div class=""card shadow-sm"">
                <div class=""card-body text-center"">
                    <div class=""mb-4"">
                        <i class=""bi bi-check-circle-fill text-success"" style=""font-size: 5rem;""></i>
                    </div>
                    <h2 class=""text-success"">Đặt hàng thành công!</h2>
                    <p class=""lead mb-4"">Cảm ơn bạn đã mua sách tại Thành Tâm</p>

                    <div class=""order-details mb-4"">
                   ");
            WriteLiteral("     <h4>Thông tin đơn hàng #");
#nullable restore
#line 32 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\PaymentSuccess.cshtml"
                                           Write(Model.IdDonHang);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n                        <div class=\"row mt-3\">\r\n                            <div class=\"col-md-6 text-start\">\r\n                                <h5>Thông tin giao hàng</h5>\r\n                                <p>");
#nullable restore
#line 36 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\PaymentSuccess.cshtml"
                              Write(Model.PhieuDat.DiaChiGiaoHang.HoVaTen);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                <p>");
#nullable restore
#line 37 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\PaymentSuccess.cshtml"
                              Write(Model.PhieuDat.DiaChiGiaoHang.SdtGiaoHang);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                <p>");
#nullable restore
#line 38 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\PaymentSuccess.cshtml"
                              Write(Model.PhieuDat.DiaChiGiaoHang.DiaChiGiaoHang);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            </div>\r\n                            <div class=\"col-md-6 text-start\">\r\n                                <h5>Thông tin thanh toán</h5>\r\n                                <p>\r\n                                    Phương thức:\r\n");
#nullable restore
#line 44 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\PaymentSuccess.cshtml"
                                     if (Model.NgayThanhToan != null)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <span class=\"badge bg-success\">MoMo (Đã thanh toán)</span>\r\n");
#nullable restore
#line 47 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\PaymentSuccess.cshtml"
                                    }
                                    else
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <span class=\"badge bg-primary\">COD (Thanh toán khi nhận hàng)</span>\r\n");
#nullable restore
#line 51 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\PaymentSuccess.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                </p>\r\n");
#nullable restore
#line 53 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\PaymentSuccess.cshtml"
                                 if (Model.NgayThanhToan != null)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <p>Ngày thanh toán: ");
#nullable restore
#line 55 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\PaymentSuccess.cshtml"
                                                   Write(Model.NgayThanhToan.Value.ToString("dd/MM/yyyy HH:mm:ss"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 56 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\PaymentSuccess.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <p>\r\n                                    Trạng thái:\r\n");
#nullable restore
#line 59 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\PaymentSuccess.cshtml"
                                     switch (Model.TrangThaiDonHang)
                                    {
                                        case TrangThaiDonHang.dangXuLy:

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <span class=\"badge bg-warning text-dark\">Đang xử lý</span>\r\n");
#nullable restore
#line 63 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\PaymentSuccess.cshtml"
                                            break;
                                        case TrangThaiDonHang.daDuyet:

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <span class=\"badge bg-info\">Đã duyệt</span>\r\n");
#nullable restore
#line 66 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\PaymentSuccess.cshtml"
                                            break;
                                        case TrangThaiDonHang.dangVanChuyen:

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <span class=\"badge bg-primary\">Đang vận chuyển</span>\r\n");
#nullable restore
#line 69 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\PaymentSuccess.cshtml"
                                            break;
                                        case TrangThaiDonHang.hoanThanh:

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <span class=\"badge bg-success\">Hoàn thành</span>\r\n");
#nullable restore
#line 72 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\PaymentSuccess.cshtml"
                                            break;
                                        case TrangThaiDonHang.daHuy:

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <span class=\"badge bg-danger\">Đã hủy</span>\r\n");
#nullable restore
#line 75 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\PaymentSuccess.cshtml"
                                            break;
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                </p>
                            </div>
                        </div>
                    </div>

                    <div class=""order-items mb-4"">
                        <h5>Sản phẩm đã đặt</h5>
                        <div class=""table-responsive"">
                            <table class=""table"">
                                <thead>
                                    <tr>
                                        <th>Sản phẩm</th>
                                        <th>Số lượng</th>
                                        <th>Đơn giá</th>
                                        <th>Thành tiền</th>
                                    </tr>
                                </thead>
                                <tbody>
");
#nullable restore
#line 95 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\PaymentSuccess.cshtml"
                                     foreach (var item in Model.PhieuDat.ChiTietPhieuDats)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <tr>\r\n                                            <td>");
#nullable restore
#line 98 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\PaymentSuccess.cshtml"
                                           Write(item.SanPham.TenSanPham);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td>");
#nullable restore
#line 99 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\PaymentSuccess.cshtml"
                                           Write(item.SoLuong);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td>");
#nullable restore
#line 100 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\PaymentSuccess.cshtml"
                                           Write(item.SanPham.GiaBan?.ToString("N0"));

#line default
#line hidden
#nullable disable
            WriteLiteral("đ</td>\r\n                                            <td>");
#nullable restore
#line 101 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\PaymentSuccess.cshtml"
                                           Write(item.ThanhTien.ToString("N0"));

#line default
#line hidden
#nullable disable
            WriteLiteral("đ</td>\r\n                                        </tr>\r\n");
#nullable restore
#line 103 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\PaymentSuccess.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                </tbody>
                                <tfoot>
                                    <tr>
                                        <td colspan=""3"" class=""text-end fw-bold"">Tổng tiền:</td>
                                        <td class=""fw-bold"">");
#nullable restore
#line 108 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\PaymentSuccess.cshtml"
                                                       Write(Model.PhieuDat.TongTien.ToString("N0"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"đ</td>
                                    </tr>
                                </tfoot>
                            </table>
                        </div>
                    </div>

                    <div class=""text-center mt-4"">
                        <a");
            BeginWriteAttribute("href", " href=\"", 5927, "\"", 5962, 1);
#nullable restore
#line 116 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\PaymentSuccess.cshtml"
WriteAttributeValue("", 5934, Url.Action("Index", "Home"), 5934, 28, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-primary\">Tiếp tục mua sắm</a>\r\n                        <a");
            BeginWriteAttribute("href", " href=\"", 6036, "\"", 6082, 1);
#nullable restore
#line 117 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\PaymentSuccess.cshtml"
WriteAttributeValue("", 6043, Url.Action("OrderManagement", "Order"), 6043, 39, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-outline-secondary\">Xem lịch sử đơn hàng</a>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebBookStoreManage.Models.DONHANG> Html { get; private set; }
    }
}
#pragma warning restore 1591
