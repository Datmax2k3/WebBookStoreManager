#pragma checksum "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Cart\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "965de2da464efa825d8962fc2af5bdf6790783cf"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cart_Index), @"mvc.1.0.view", @"/Views/Cart/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"965de2da464efa825d8962fc2af5bdf6790783cf", @"/Views/Cart/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"64d8f35278a37e92fb38f314442aaace3ec2b173", @"/Views/_ViewImports.cshtml")]
    public class Views_Cart_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WebBookStoreManage.ViewModels.CartViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"container p-5\" style=\"background-color: #F5F5F5; min-height: 50rem;\">\r\n    <h1 class=\"mb-4\" style=\"font-size: 28px; font-weight: 700;\">Giỏ hàng</h1>\r\n\r\n");
#nullable restore
#line 6 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Cart\Index.cshtml"
     if (Model.CartItems.Any())
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"row\">\r\n            <!-- Danh sách sản phẩm trong giỏ hàng -->\r\n            <div class=\"col-md-9\">\r\n");
#nullable restore
#line 11 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Cart\Index.cshtml"
                 foreach (var item in Model.CartItems)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    <div class=""cart-item d-flex justify-content-between align-items-center mb-3 p-3"" style=""background-color: #FFF; border: 1px solid #DDD;"">
                        <!-- Hình ảnh sản phẩm -->
                        <div class=""product-image"">
                            <img");
            BeginWriteAttribute("src", " src=\"", 749, "\"", 811, 1);
#nullable restore
#line 16 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Cart\Index.cshtml"
WriteAttributeValue("", 755, Url.Content("~/images/product/" + item.SanPham.hinhAnh), 755, 56, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", "\r\n                                 alt=\"", 812, "\"", 876, 1);
#nullable restore
#line 17 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Cart\Index.cshtml"
WriteAttributeValue("", 852, item.SanPham.TenSanPham, 852, 24, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@"
                                 style=""width: 200px; object-fit: cover; border: 1px solid #DDD;"" />
                        </div>

                        <!-- Thông tin sản phẩm -->
                        <div class=""product-details"" style=""flex-grow: 1; margin-left: 15px;"">
                            <h5 style=""font-size: 18px; font-weight: bold;"">");
#nullable restore
#line 23 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Cart\Index.cshtml"
                                                                       Write(item.SanPham.TenSanPham);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                            <p style=\"font-size: 14px; color: #666;\">Tác giả: ");
#nullable restore
#line 24 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Cart\Index.cshtml"
                                                                          Write(item.SanPham.SanPhamTacGias.FirstOrDefault()?.TacGia.TenTacGia ?? "Không xác định");

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            <p style=\"font-size: 14px; color: #666;\">Loại: ");
#nullable restore
#line 25 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Cart\Index.cshtml"
                                                                       Write(item.SanPham.DanhMucChiTiet.TenDanhMucCT ?? "Không xác định");

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                        </div>\r\n\r\n                        <!-- Giá -->\r\n                        <div class=\"product-price\" style=\"font-size: 18px; font-weight: bold;\">\r\n                            ");
#nullable restore
#line 30 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Cart\Index.cshtml"
                        Write((item.SanPham.GiaBan ?? 0).ToString("N0"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@" đ
                        </div>

                        <!-- Bộ chọn số lượng -->
                        <div class=""quantity-selector d-flex align-items-center mx-3"">
                            <button class=""minus-cart btn"" style=""width: 30px; height: 30px; background-color: #E0E0E0; border: none;"">-</button>
                            <input type=""number""");
            BeginWriteAttribute("value", "\r\n                                   value=\"", 2197, "\"", 2254, 1);
#nullable restore
#line 37 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Cart\Index.cshtml"
WriteAttributeValue("", 2241, item.SoLuong, 2241, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("\r\n                                   min=\"1\"");
            BeginWriteAttribute("max", "\r\n                                   max=\"", 2299, "\"", 2365, 1);
#nullable restore
#line 39 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Cart\Index.cshtml"
WriteAttributeValue("", 2341, item.SanPham.SoLuongCon, 2341, 24, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("\r\n                                   data-product-id=\"");
#nullable restore
#line 40 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Cart\Index.cshtml"
                                               Write(item.IdSanPham);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"""
                                   style="" text-align: center; margin: 0 5px; border: 1px solid #CCC; padding:0;"" />
                            <button class=""plus-cart btn"" style=""width: 30px; height: 30px; background-color: #E0E0E0; border: none;"">+</button>
                        </div>

                        <!-- Nút xóa -->
                        <div class=""delete-option"">
                            <a href=""#"" class=""text-danger"" data-product-id=""");
#nullable restore
#line 47 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Cart\Index.cshtml"
                                                                        Write(item.IdSanPham);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" style=\"font-size: 14px;\">Xóa</a>\r\n                        </div>\r\n                    </div>\r\n");
#nullable restore
#line 50 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Cart\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            </div>



            <!-- Tóm tắt giỏ hàng -->
            <div class=""col-md-3"">
                <div class=""summary-box p-4"" style=""background-color: #FFF; border: 1px solid #DDD; text-align: center;"">
                    <p style=""font-size: 16px;"">");
#nullable restore
#line 58 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Cart\Index.cshtml"
                                           Write(Model.TotalQuantity);

#line default
#line hidden
#nullable disable
            WriteLiteral(" sản phẩm</p>\r\n                    <p style=\"font-size: 18px; font-weight: bold;\">\r\n                        Tổng cộng: ");
#nullable restore
#line 60 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Cart\Index.cshtml"
                              Write(Model.TotalCost.ToString("N0"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" đ\r\n                        <span style=\"font-size: 12px; color: #666;\">(Chưa có cước vận chuyển)</span>\r\n                    </p>\r\n                    <a");
            BeginWriteAttribute("href", " href=\"", 3634, "\"", 3673, 1);
#nullable restore
#line 63 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Cart\Index.cshtml"
WriteAttributeValue("", 3641, Url.Action("Checkout", "Order"), 3641, 32, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@"
                       class=""btn btn-orange""
                       style=""background-color: #FF6200; color: #FFF; padding: 10px 20px; border-radius: 5px; width: 100%;"">
                        Tiến hành đặt hàng
                    </a>
                </div>
            </div>
        </div>
");
#nullable restore
#line 71 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Cart\Index.cshtml"
    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <p style=\"font-size: 16px;\">Giỏ hàng của bạn đang trống</p>\r\n");
#nullable restore
#line 75 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Cart\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebBookStoreManage.ViewModels.CartViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
