#pragma checksum "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\PrintOrder.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "afb88fbcd7a0b1f60ab8382588fdf80de7a4f585"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Order_PrintOrder), @"mvc.1.0.view", @"/Views/Order/PrintOrder.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"afb88fbcd7a0b1f60ab8382588fdf80de7a4f585", @"/Views/Order/PrintOrder.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"64d8f35278a37e92fb38f314442aaace3ec2b173", @"/Views/_ViewImports.cshtml")]
    public class Views_Order_PrintOrder : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WebBookStoreManage.ViewModels.OrderViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/bootstrap/dist/css/bootstrap.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/jquery/dist/jquery.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/bootstrap/dist/js/bootstrap.bundle.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\PrintOrder.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<!DOCTYPE html>\r\n<html lang=\"vi\">\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "afb88fbcd7a0b1f60ab8382588fdf80de7a4f5855102", async() => {
                WriteLiteral("\r\n    <meta charset=\"utf-8\" />\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\" />\r\n    <title>In đơn hàng #");
#nullable restore
#line 11 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\PrintOrder.cshtml"
                   Write(Model.PHIEUDAT.IdPhieuDat);

#line default
#line hidden
#nullable disable
                WriteLiteral("</title>\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "afb88fbcd7a0b1f60ab8382588fdf80de7a4f5855757", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
    <style>
        body {
            font-family: Arial, sans-serif;
            line-height: 1.6;
            font-size: 14px;
            color: #333;
        }
        .invoice-header {
            text-align: center;
            margin-bottom: 30px;
        }
        .invoice-title {
            font-size: 24px;
            font-weight: bold;
            margin-bottom: 5px;
        }
        .invoice-number {
            font-size: 18px;
            margin-bottom: 10px;
        }
        .shop-info {
            margin-bottom: 20px;
        }
        .invoice-date {
            margin-bottom: 30px;
        }
        .section-title {
            font-weight: bold;
            font-size: 16px;
            margin-bottom: 10px;
            text-transform: uppercase;
            border-bottom: 1px solid #ddd;
            padding-bottom: 5px;
        }
        .table {
            width: 100%;
            border-collapse: collapse;
            margin-bottom: 20px;
     ");
                WriteLiteral(@"   }
        .table th, .table td {
            padding: 8px;
            border: 1px solid #ddd;
        }
        .table th {
            background-color: #f5f5f5;
            font-weight: bold;
            text-align: left;
        }
        .text-end {
            text-align: right;
        }
        .text-center {
            text-align: center;
        }
        .total-section {
            margin-top: 20px;
            text-align: right;
        }
        .footer {
            margin-top: 40px;
            text-align: center;
        }
        .signature-section {
            display: flex;
            justify-content: space-between;
            margin-top: 60px;
        }
        .signature-box {
            width: 40%;
            text-align: center;
        }
        .signature-line {
            border-top: 1px dashed #999;
            margin-top: 70px;
        }
        media print {
            page{
                size: A4;
                margin: 1cm;
");
                WriteLiteral("            }\r\n            .print-button {\r\n                display: none;\r\n            }\r\n        }\r\n    </style>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "afb88fbcd7a0b1f60ab8382588fdf80de7a4f5859883", async() => {
                WriteLiteral(@"
    <div class=""container mt-5"">
        <div class=""d-print-none text-end mb-3"">
            <button class=""btn btn-primary"" onclick=""window.print()"">
                <i class=""fas fa-print""></i> In đơn hàng
            </button>
            <button class=""btn btn-secondary"" onclick=""window.close()"">
                Đóng
            </button>
        </div>

        <div class=""invoice-header"">
            <div class=""invoice-title"">PHIẾU ĐẶT HÀNG</div>
            <div class=""invoice-number"">Số: #");
#nullable restore
#line 112 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\PrintOrder.cshtml"
                                        Write(Model.PHIEUDAT.IdPhieuDat);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</div>
        </div>

        <div class=""shop-info row"">
            <div class=""col-6"">
                <strong>CỬA HÀNG SÁCH XYZ</strong><br />
                Địa chỉ: 123 Đường ABC, Quận DEF, TP.HCM<br />
                Số điện thoại: 028.1234.5678<br />
                Email: bookstore@example.com
            </div>
            <div class=""col-6 text-end"">
                <div class=""invoice-date"">
                    Ngày: ");
#nullable restore
#line 124 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\PrintOrder.cshtml"
                     Write(DateTime.Now.ToString("dd/MM/yyyy"));

#line default
#line hidden
#nullable disable
                WriteLiteral("<br />\r\n                    Ngày đặt hàng: ");
#nullable restore
#line 125 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\PrintOrder.cshtml"
                              Write(Model.PHIEUDAT.NgayTaoPhieu.ToString("dd/MM/yyyy HH:mm"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n\r\n        <div class=\"row mb-4\">\r\n            <div class=\"col-6\">\r\n                <div class=\"section-title\">THÔNG TIN KHÁCH HÀNG</div>\r\n");
#nullable restore
#line 133 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\PrintOrder.cshtml"
                 if (Model.PHIEUDAT.NguoiDung != null)
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <p>\r\n                        <strong>Tên khách hàng:</strong> ");
#nullable restore
#line 136 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\PrintOrder.cshtml"
                                                    Write(Model.PHIEUDAT.NguoiDung.TenNguoiDung);

#line default
#line hidden
#nullable disable
                WriteLiteral("<br />\r\n                        <strong>Số điện thoại:</strong> ");
#nullable restore
#line 137 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\PrintOrder.cshtml"
                                                    Write(Model.PHIEUDAT.NguoiDung.soDienThoai ?? "Không có");

#line default
#line hidden
#nullable disable
                WriteLiteral("<br />\r\n                        <strong>Email:</strong> ");
#nullable restore
#line 138 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\PrintOrder.cshtml"
                                            Write(Model.PHIEUDAT.NguoiDung.Email ?? "Không có");

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </p>\r\n");
#nullable restore
#line 140 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\PrintOrder.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <p>Khách vãng lai - không có thông tin</p>\r\n");
#nullable restore
#line 144 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\PrintOrder.cshtml"
                }

#line default
#line hidden
#nullable disable
                WriteLiteral("            </div>\r\n\r\n            <div class=\"col-6\">\r\n                <div class=\"section-title\">ĐỊA CHỈ GIAO HÀNG</div>\r\n");
#nullable restore
#line 149 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\PrintOrder.cshtml"
                 if (Model.PHIEUDAT.DiaChiGiaoHang != null)
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <p>\r\n                        <strong>Người nhận:</strong> ");
#nullable restore
#line 152 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\PrintOrder.cshtml"
                                                Write(Model.PHIEUDAT.DiaChiGiaoHang.HoVaTen);

#line default
#line hidden
#nullable disable
                WriteLiteral("<br />\r\n                        <strong>Số điện thoại:</strong> ");
#nullable restore
#line 153 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\PrintOrder.cshtml"
                                                   Write(Model.PHIEUDAT.DiaChiGiaoHang.SdtGiaoHang);

#line default
#line hidden
#nullable disable
                WriteLiteral("<br />\r\n                        <strong>Địa chỉ:</strong> ");
#nullable restore
#line 154 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\PrintOrder.cshtml"
                                             Write(Model.PHIEUDAT.DiaChiGiaoHang.DiaChiGiaoHang);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </p>\r\n");
#nullable restore
#line 156 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\PrintOrder.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <p>Đơn hàng bán trực tiếp tại cửa hàng</p>\r\n");
#nullable restore
#line 160 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\PrintOrder.cshtml"
                }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"            </div>
        </div>

        <div class=""section-title"">CHI TIẾT ĐƠN HÀNG</div>
        <table class=""table"">
            <thead>
                <tr>
                    <th style=""width: 5%"">STT</th>
                    <th style=""width: 50%"">Sản phẩm</th>
                    <th class=""text-center"" style=""width: 15%"">Đơn giá</th>
                    <th class=""text-center"" style=""width: 10%"">SL</th>
                    <th class=""text-end"" style=""width: 20%"">Thành tiền</th>
                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 176 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\PrintOrder.cshtml"
                  
                    int stt = 1;
                    foreach (var item in Model.PHIEUDAT.ChiTietPhieuDats)
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <tr>\r\n                            <td>");
#nullable restore
#line 181 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\PrintOrder.cshtml"
                           Write(stt);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 183 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\PrintOrder.cshtml"
                           Write(item.SanPham.TenSanPham);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                <br />\r\n                                <small>Mã: ");
#nullable restore
#line 185 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\PrintOrder.cshtml"
                                      Write(item.SanPham.IdSanPham);

#line default
#line hidden
#nullable disable
                WriteLiteral("</small>\r\n                            </td>\r\n                            <td class=\"text-center\">");
#nullable restore
#line 187 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\PrintOrder.cshtml"
                                                Write((item.SanPham.GiaBan ?? 0).ToString("N0"));

#line default
#line hidden
#nullable disable
                WriteLiteral("đ</td>\r\n                            <td class=\"text-center\">");
#nullable restore
#line 188 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\PrintOrder.cshtml"
                                               Write(item.SoLuong);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                            <td class=\"text-end\">");
#nullable restore
#line 189 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\PrintOrder.cshtml"
                                            Write(item.ThanhTien.ToString("N0"));

#line default
#line hidden
#nullable disable
                WriteLiteral("đ</td>\r\n                        </tr>\r\n");
#nullable restore
#line 191 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\PrintOrder.cshtml"
                        stt++;
                    }
                

#line default
#line hidden
#nullable disable
                WriteLiteral("            </tbody>\r\n            <tfoot>\r\n                <tr>\r\n                    <td colspan=\"4\" class=\"text-end\"><strong>TỔNG TIỀN:</strong></td>\r\n                    <td class=\"text-end\"><strong>");
#nullable restore
#line 198 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\PrintOrder.cshtml"
                                            Write(Model.PHIEUDAT.TongTien.ToString("N0"));

#line default
#line hidden
#nullable disable
                WriteLiteral("đ</strong></td>\r\n                </tr>\r\n            </tfoot>\r\n        </table>\r\n\r\n        <div class=\"row\">\r\n            <div class=\"col-12\">\r\n                <div class=\"section-title\">GHI CHÚ</div>\r\n                <p>\r\n");
#nullable restore
#line 207 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\PrintOrder.cshtml"
                     if (string.IsNullOrEmpty(Model.PHIEUDAT.GhiChu))
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <span>Không có ghi chú</span>\r\n");
#nullable restore
#line 210 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\PrintOrder.cshtml"
                    }
                    else
                    {
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 213 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\PrintOrder.cshtml"
                   Write(Model.PHIEUDAT.GhiChu);

#line default
#line hidden
#nullable disable
#nullable restore
#line 213 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\PrintOrder.cshtml"
                                              
                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("                </p>\r\n            </div>\r\n        </div>\r\n\r\n        <div class=\"row\">\r\n            <div class=\"col-12\">\r\n                <div class=\"section-title\">TRẠNG THÁI ĐƠN HÀNG</div>\r\n                <p>\r\n");
#nullable restore
#line 223 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\PrintOrder.cshtml"
                      
                        var status = Model.DONHANG?.TrangThaiDonHang.ToString() switch
                        {
                            "dangXuLy" => "Đang xử lý",
                            "daDuyet" => "Đã duyệt",
                            "dangVanChuyen" => "Đang vận chuyển",
                            "hoanThanh" => "Hoàn thành",
                            "daHuy" => "Đã hủy",
                            _ => "N/A"
                        };
                    

#line default
#line hidden
#nullable disable
                WriteLiteral("                    ");
#nullable restore
#line 234 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\PrintOrder.cshtml"
               Write(status);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                </p>
            </div>
        </div>

        <div class=""signature-section"">
            <div class=""signature-box"">
                <p><strong>NGƯỜI MUA HÀNG</strong></p>
                <p><em>(Ký và ghi rõ họ tên)</em></p>
                <div class=""signature-line""></div>
            </div>

            <div class=""signature-box"">
                <p><strong>NGƯỜI BÁN HÀNG</strong></p>
                <p><em>(Ký và ghi rõ họ tên)</em></p>
                <div class=""signature-line""></div>
            </div>
        </div>

        <div class=""footer"">
            <p>Cảm ơn Quý khách đã mua hàng tại cửa hàng chúng tôi!</p>
            <p>Mọi thắc mắc xin vui lòng liên hệ: 028.1234.5678 (giờ hành chính)</p>
        </div>
    </div>

    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "afb88fbcd7a0b1f60ab8382588fdf80de7a4f58523081", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "afb88fbcd7a0b1f60ab8382588fdf80de7a4f58524181", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    <script>\r\n        $(document).ready(function() {\r\n            // Tự động in khi trang đã tải xong\r\n            setTimeout(function() {\r\n                window.print();\r\n            }, 500);\r\n        });\r\n    </script>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebBookStoreManage.ViewModels.OrderViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
