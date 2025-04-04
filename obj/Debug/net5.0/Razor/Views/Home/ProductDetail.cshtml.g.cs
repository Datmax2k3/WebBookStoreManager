#pragma checksum "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Home\ProductDetail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ff15c906c4dd350bfecf6ac3771130207713cf91"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_ProductDetail), @"mvc.1.0.view", @"/Views/Home/ProductDetail.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ff15c906c4dd350bfecf6ac3771130207713cf91", @"/Views/Home/ProductDetail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"64d8f35278a37e92fb38f314442aaace3ec2b173", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_ProductDetail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WebBookStoreManage.Models.SANPHAM>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<div class=""container p-5"">
    <div class=""product-detail"">
        <div class=""row"">
            <!-- Phần bên trái: Hình ảnh sản phẩm -->
            <div class=""col-md-6 product-images"">
                <figure class=""product-style"">
                    <!-- Ảnh chính -->
                    <img");
            BeginWriteAttribute("src", " src=\"", 352, "\"", 407, 1);
#nullable restore
#line 10 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Home\ProductDetail.cshtml"
WriteAttributeValue("", 358, Url.Content("~/images/product/" + Model.hinhAnh), 358, 49, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", "\r\n                         alt=\"", 408, "\"", 457, 1);
#nullable restore
#line 11 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Home\ProductDetail.cshtml"
WriteAttributeValue("", 440, Model.TenSanPham, 440, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("\r\n                         class=\"main-image img-fluid mb-3\" />\r\n\r\n                    <!-- Gallery ảnh phụ -->\r\n");
#nullable restore
#line 15 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Home\ProductDetail.cshtml"
                     if (Model.HinhAnhSanPhams != null && Model.HinhAnhSanPhams.Any())
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"image-gallery d-flex flex-wrap\">\r\n");
#nullable restore
#line 18 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Home\ProductDetail.cshtml"
                             foreach (var hinhAnh in Model.HinhAnhSanPhams)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <img");
            BeginWriteAttribute("src", " src=\"", 896, "\"", 952, 1);
#nullable restore
#line 20 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Home\ProductDetail.cshtml"
WriteAttributeValue("", 902, Url.Content("~/images/product/" + hinhAnh.UrlAnh), 902, 50, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("\r\n                                     alt=\"Additional Image\"\r\n                                     class=\"thumbnail img-thumbnail mr-2\"\r\n                                     style=\"width:80px;height:80px;object-fit:cover;cursor:pointer;\" />\r\n");
#nullable restore
#line 24 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Home\ProductDetail.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </div>\r\n");
#nullable restore
#line 26 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Home\ProductDetail.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </figure>\r\n            </div>\r\n\r\n            <!-- Phần bên phải: Thông tin chi tiết sản phẩm -->\r\n            <div class=\"col-md-6 product-info\">\r\n                <h1 class=\"product-title\">");
#nullable restore
#line 32 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Home\ProductDetail.cshtml"
                                     Write(Model.TenSanPham);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n\r\n                <div class=\"product-category text-muted mb-2\">\n");
#nullable restore
#line 35 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Home\ProductDetail.cshtml"
                     if (Model.SanPhamTacGias != null && Model.SanPhamTacGias.Any())
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <span>Tác giả: </span>\n");
#nullable restore
#line 38 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Home\ProductDetail.cshtml"
                         foreach (var tacGia in Model.SanPhamTacGias)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <span>");
#nullable restore
#line 40 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Home\ProductDetail.cshtml"
                             Write(tacGia.TacGia.TenTacGia);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\n");
#nullable restore
#line 41 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Home\ProductDetail.cshtml"
                            if (tacGia != Model.SanPhamTacGias.Last())
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <span>, </span>\n");
#nullable restore
#line 44 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Home\ProductDetail.cshtml"
                            }
                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 45 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Home\ProductDetail.cshtml"
                         
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <span>Không có thông tin tác giả</span>\n");
#nullable restore
#line 50 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Home\ProductDetail.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\r\n\r\n                <!-- Hiển thị giá -->\r\n                <div class=\"product-price mb-3\">\r\n                    <!-- Giá gốc -->\r\n                    <span class=\"original-price\">\r\n                        ");
#nullable restore
#line 57 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Home\ProductDetail.cshtml"
                   Write(Model.GiaGoc.ToString("N0"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" đ\r\n                    </span>\r\n\r\n");
#nullable restore
#line 60 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Home\ProductDetail.cshtml"
                     if (Model.GiamGia > 0 && Model.GiaBan.HasValue)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <!-- Giá đã giảm -->\r\n                        <span class=\"discounted-price text-danger ml-3\">\r\n                            ");
#nullable restore
#line 64 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Home\ProductDetail.cshtml"
                       Write(Model.GiaBan.Value.ToString("N0"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" đ\r\n                        </span>\r\n");
            WriteLiteral("                        <div class=\"item-discount small text-muted\">\r\n                            Tiết kiệm:\r\n                            ");
#nullable restore
#line 69 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Home\ProductDetail.cshtml"
                        Write((Model.GiaGoc - Model.GiaBan.Value).ToString("N0"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" đ\r\n                            (");
#nullable restore
#line 70 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Home\ProductDetail.cshtml"
                         Write(Model.GiamGia.ToString("N0"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" %)\r\n                        </div>\r\n");
#nullable restore
#line 72 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Home\ProductDetail.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\r\n\r\n                <!-- Tình trạng sản phẩm -->\r\n                <div class=\"product-status mb-2\">\r\n                    <strong>Tình trạng:</strong>\r\n");
#nullable restore
#line 78 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Home\ProductDetail.cshtml"
                     if (!string.IsNullOrEmpty(Model.TrangThai)
                        && Model.TrangThai.Equals("Còn Hàng", StringComparison.OrdinalIgnoreCase))
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <span class=\"text-success ml-1\">Còn hàng</span>\r\n");
#nullable restore
#line 82 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Home\ProductDetail.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <span class=\"text-danger ml-1\">Hết hàng</span>\r\n");
#nullable restore
#line 86 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Home\ProductDetail.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\r\n\r\n                <!-- Thông tin số lượng, đã bán -->\r\n                <div class=\"product-meta mb-3\">\r\n                    <p>Số lượng còn: <strong>");
#nullable restore
#line 91 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Home\ProductDetail.cshtml"
                                        Write(Model.SoLuongCon);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong></p>\r\n                    <p>Đã bán: <strong>");
#nullable restore
#line 92 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Home\ProductDetail.cshtml"
                                  Write(Model.SoLuongDaBan);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong></p>\r\n                </div>\r\n\r\n                <!-- Chọn số lượng nếu còn hàng -->\r\n");
#nullable restore
#line 96 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Home\ProductDetail.cshtml"
                 if (!string.IsNullOrEmpty(Model.TrangThai)
                    && Model.TrangThai.Equals("Còn Hàng", StringComparison.OrdinalIgnoreCase))
                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    <div class=""quantity-selector d-flex align-items-center mb-3"">
                        <label class=""mr-2 mb-0"">Số lượng:</label>
                        <button class=""btn btn-outline-secondary minus"">-</button>
                        <input type=""number""
                               class=""form-control mx-1""
                               value=""1""
                               min=""1""");
            BeginWriteAttribute("max", "\r\n                               max=\"", 4730, "\"", 4785, 1);
#nullable restore
#line 106 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Home\ProductDetail.cshtml"
WriteAttributeValue("", 4768, Model.SoLuongCon, 4768, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("\r\n                               style=\"width: 60px; margin: 10px 0;\" />\r\n                        <button class=\"btn btn-outline-secondary plus\">+</button>\r\n                    </div>\r\n");
#nullable restore
#line 110 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Home\ProductDetail.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <!-- Nút Thêm vào giỏ & Mua ngay -->\r\n                <div class=\"product-actions mb-3\">\r\n");
#nullable restore
#line 114 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Home\ProductDetail.cshtml"
                     if (!string.IsNullOrEmpty(Model.TrangThai)
                        && Model.TrangThai.Equals("Còn Hàng", StringComparison.OrdinalIgnoreCase))
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <button type=\"button\" class=\"btn btn-primary mr-2 add-to-cart\" data-product-id=\"");
#nullable restore
#line 117 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Home\ProductDetail.cshtml"
                                                                                                   Write(Model.IdSanPham);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n                            Thêm vào giỏ\r\n                        </button>\r\n                        <button type=\"button\" class=\"btn btn-danger buy-now\" data-product-id=\"");
#nullable restore
#line 120 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Home\ProductDetail.cshtml"
                                                                                         Write(Model.IdSanPham);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n                            Mua ngay\r\n                        </button>\r\n");
#nullable restore
#line 123 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Home\ProductDetail.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <button type=\"button\" class=\"btn btn-secondary\" disabled>Hết hàng</button>\r\n");
#nullable restore
#line 127 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Home\ProductDetail.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                </div>

                <!-- Thông tin liên hệ, khuyến mãi -->
                <div class=""contact-info mt-4"">
                    <p>Gọi đặt hàng: <strong>(028) 3820 7153</strong> hoặc <strong>0933 109 009</strong></p>
                    <p><strong>Thông tin & Khuyến mãi</strong></p>
                    <ul class=""list-unstyled"">
                        <li>Đổi trả hàng trong vòng 7 ngày</li>
                        <li>Freeship nội thành Đà Nẵng từ 150.000đ</li>
                        <li>Freeship toàn quốc từ 250.000đ</li>
                    </ul>
                </div>
            </div>
        </div>

        <!-- Mô tả chi tiết sản phẩm -->
        <div class=""row mt-4"">
            <div class=""col-md-12"">
                <h3>Giới thiệu sản phẩm</h3>
                <p>");
#nullable restore
#line 147 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Home\ProductDetail.cshtml"
              Write(Model.MoTaChiTiet);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebBookStoreManage.Models.SANPHAM> Html { get; private set; }
    }
}
#pragma warning restore 1591
