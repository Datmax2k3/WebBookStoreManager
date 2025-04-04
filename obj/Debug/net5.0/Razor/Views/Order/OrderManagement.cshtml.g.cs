#pragma checksum "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\OrderManagement.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "318519c1c513c93513d6b5c3a34b56fb48ed6563"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Order_OrderManagement), @"mvc.1.0.view", @"/Views/Order/OrderManagement.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"318519c1c513c93513d6b5c3a34b56fb48ed6563", @"/Views/Order/OrderManagement.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"64d8f35278a37e92fb38f314442aaace3ec2b173", @"/Views/_ViewImports.cshtml")]
    public class Views_Order_OrderManagement : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<WebBookStoreManage.ViewModels.OrderViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "dangXuLy", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "daDuyet", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "dangVanChuyen", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "hoanThanh", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "daHuy", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "OrderDetails", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-sm btn-outline-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\OrderManagement.cshtml"
  
    ViewData["Title"] = "Quản lý bán hàng";

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"container my-5\">\r\n    <div class=\"row mb-4\">\r\n        <div class=\"col-md-8\">\r\n            <h1 class=\"mb-0\">Quản lý bán hàng</h1>\r\n            <p class=\"text-muted\">Quản lý đơn hàng trực tiếp tại cửa hàng</p>\r\n        </div>\r\n    </div>\r\n\r\n");
#nullable restore
#line 13 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\OrderManagement.cshtml"
     if (TempData["Message"] != null)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"alert alert-success alert-dismissible fade show mb-4\" role=\"alert\">\r\n            ");
#nullable restore
#line 16 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\OrderManagement.cshtml"
       Write(TempData["Message"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <button type=\"button\" class=\"btn-close\" data-bs-dismiss=\"alert\" aria-label=\"Close\"></button>\r\n        </div>\r\n");
#nullable restore
#line 19 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\OrderManagement.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
    <div class=""card"">
        <div class=""card-header bg-light"">
            <div class=""row"">
                <div class=""col-md-8"">
                    <div class=""input-group"">
                        <input type=""text"" id=""searchInput"" style=""margin:0;"" class=""form-control"" placeholder=""Tìm kiếm đơn hàng..."" />
                        <button class=""btn btn-outline-secondary"" style=""margin:0;"" type=""button"">
                            <i class=""fas fa-search""></i>
                        </button>
                    </div>
                </div>
                <div class=""col-md-4"">
                    <select id=""statusFilter"" class=""form-select"">
                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "318519c1c513c93513d6b5c3a34b56fb48ed65637835", async() => {
                WriteLiteral("Tất cả trạng thái");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "318519c1c513c93513d6b5c3a34b56fb48ed65639029", async() => {
                WriteLiteral("Đang xử lý");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "318519c1c513c93513d6b5c3a34b56fb48ed656310216", async() => {
                WriteLiteral("Đã duyệt");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "318519c1c513c93513d6b5c3a34b56fb48ed656311402", async() => {
                WriteLiteral("Đang vận chuyển");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "318519c1c513c93513d6b5c3a34b56fb48ed656312595", async() => {
                WriteLiteral("Hoàn thành");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "318519c1c513c93513d6b5c3a34b56fb48ed656313783", async() => {
                WriteLiteral("Đã hủy");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </select>\r\n                </div>\r\n            </div>\r\n        </div>\r\n        <div class=\"card-body p-0\">\r\n");
#nullable restore
#line 45 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\OrderManagement.cshtml"
             if (Model != null && Model.Any())
            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                <div class=""table-responsive"">
                    <table class=""table table-hover mb-0"" id=""orderTable"">
                        <thead class=""table-light"">
                            <tr>
                                <th>Mã đơn</th>
                                <th>Ngày đặt</th>
                                <th>Tên khách hàng</th>
                                <th>Địa chỉ giao hàng</th>
                                <th>Tổng tiền</th>
                                <th>Trạng thái</th>
                                <th>Hành động</th>
                            </tr>
                        </thead>
                        <tbody>
");
#nullable restore
#line 61 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\OrderManagement.cshtml"
                             foreach (var order in Model)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr class=\"order-row\" data-status=\"");
#nullable restore
#line 63 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\OrderManagement.cshtml"
                                                               Write(order.DONHANG?.TrangThaiDonHang.ToString() ?? "");

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n                                    <td>");
#nullable restore
#line 64 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\OrderManagement.cshtml"
                                   Write(order.PHIEUDAT.IdPhieuDat);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 65 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\OrderManagement.cshtml"
                                   Write(order.PHIEUDAT.NgayTaoPhieu.ToString("dd/MM/yyyy HH:mm"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 66 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\OrderManagement.cshtml"
                                    Write(order.PHIEUDAT.NguoiDung?.TenNguoiDung ?? "Khách vãng lai");

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>\r\n");
#nullable restore
#line 68 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\OrderManagement.cshtml"
                                         if (order.PHIEUDAT.DiaChiGiaoHang != null)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <span");
            BeginWriteAttribute("title", " title=\"", 3361, "\"", 3414, 1);
#nullable restore
#line 70 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\OrderManagement.cshtml"
WriteAttributeValue("", 3369, order.PHIEUDAT.DiaChiGiaoHang.DiaChiGiaoHang, 3369, 45, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                                ");
#nullable restore
#line 71 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\OrderManagement.cshtml"
                                            Write(order.PHIEUDAT.DiaChiGiaoHang.DiaChiGiaoHang?.Length > 25
                                                  ? order.PHIEUDAT.DiaChiGiaoHang.DiaChiGiaoHang.Substring(0, 25) + "..."
                                                  : order.PHIEUDAT.DiaChiGiaoHang.DiaChiGiaoHang);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </span>\r\n");
#nullable restore
#line 75 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\OrderManagement.cshtml"
                                        }
                                        else
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <span>Mua tại quầy</span>\r\n");
#nullable restore
#line 79 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\OrderManagement.cshtml"
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    </td>\r\n                                    <td>");
#nullable restore
#line 81 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\OrderManagement.cshtml"
                                   Write(order.PHIEUDAT.TongTien.ToString("N0"));

#line default
#line hidden
#nullable disable
            WriteLiteral("đ</td>\r\n                                    <td>\r\n");
#nullable restore
#line 83 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\OrderManagement.cshtml"
                                          
                                            var status = order.DONHANG?.TrangThaiDonHang.ToString() ?? "N/A";
                                            var statusClass = status switch
                                            {
                                                "dangXuLy" => "bg-warning",
                                                "daDuyet" => "bg-info",
                                                "dangVanChuyen" => "bg-primary",
                                                "hoanThanh" => "bg-success",
                                                "daHuy" => "bg-danger",
                                                _ => "bg-secondary"
                                            };
                                            var statusText = status switch
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
            WriteLiteral("                                        <span");
            BeginWriteAttribute("class", " class=\"", 5704, "\"", 5730, 2);
            WriteAttributeValue("", 5712, "badge", 5712, 5, true);
#nullable restore
#line 104 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\OrderManagement.cshtml"
WriteAttributeValue(" ", 5717, statusClass, 5718, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 104 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\OrderManagement.cshtml"
                                                                    Write(statusText);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "318519c1c513c93513d6b5c3a34b56fb48ed656322639", async() => {
                WriteLiteral("\r\n                                            <i class=\"fas fa-eye\"></i> Chi tiết\r\n                                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 107 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\OrderManagement.cshtml"
                                                                       WriteLiteral(order.PHIEUDAT.IdPhieuDat);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                    </td>\r\n                                </tr>\r\n");
#nullable restore
#line 113 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\OrderManagement.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </tbody>\r\n                    </table>\r\n                </div>\r\n");
#nullable restore
#line 117 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\OrderManagement.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"text-center py-5\">\r\n                    <i class=\"fas fa-shopping-cart fa-3x mb-3 text-muted\"></i>\r\n                    <h5>Chưa có đơn hàng nào</h5>\r\n                </div>\r\n");
#nullable restore
#line 124 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\OrderManagement.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
        $(document).ready(function() {
            // Lọc đơn hàng theo trạng thái
            $(""#statusFilter"").change(function() {
                var status = $(this).val();

                if (status === """") {
                    $("".order-row"").show();
                } else {
                    $("".order-row"").hide();
                    $(`.order-row[data-status=""${status}""]`).show();
                }
            });

            // Tìm kiếm đơn hàng
            $(""#searchInput"").on(""keyup"", function() {
                var value = $(this).val().toLowerCase();
                $(""#orderTable tbody tr"").filter(function() {
                    $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1);
                });
            });
        });
    </script>
");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<WebBookStoreManage.ViewModels.OrderViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
