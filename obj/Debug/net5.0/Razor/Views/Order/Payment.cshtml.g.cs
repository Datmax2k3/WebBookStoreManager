#pragma checksum "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\Payment.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2d46071f549bd15a4acbb67d335a55acf584b6a6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Order_Payment), @"mvc.1.0.view", @"/Views/Order/Payment.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2d46071f549bd15a4acbb67d335a55acf584b6a6", @"/Views/Order/Payment.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"64d8f35278a37e92fb38f314442aaace3ec2b173", @"/Views/_ViewImports.cshtml")]
    public class Views_Order_Payment : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WebBookStoreManage.ViewModels.PaymentViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("placeholder", new global::Microsoft.AspNetCore.Html.HtmlString("Ghi chú cho Bookbuy"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "PlaceOrder", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_ValidationScriptsPartial", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.TextAreaTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_TextAreaTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\Payment.cshtml"
  
    ViewData["Title"] = "Thanh toán";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<!-- Header -->
<header class=""d-flex justify-content-between align-items-center py-3 border-bottom"">
    <div class=""logo"">
        <h3 style=""color: orange;"">Bookbuy.vn</h3>
    </div>
    <div class=""steps"">
        <span class=""step text-muted"">1. Điền thông tin</span>
        <span class=""step text-dark fw-bold"">2. Thanh toán & Hoàn tất</span>
    </div>
    <div class=""hotline"">
        <i class=""fa fa-phone"" style=""color: orange;""></i> 0933 109 009
    </div>
</header>

<div class=""container mt-4"">
    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2d46071f549bd15a4acbb67d335a55acf584b6a65910", async() => {
                WriteLiteral(@"
        <div class=""row"">
            <!-- Left Section -->
            <div class=""col-md-8"">
                <h2 class=""text-uppercase fw-bold"">Phương thức vận chuyển</h2>
                <div class=""form-group mb-3"">
                    <label class=""d-block"">
                        <input type=""radio"" name=""ShippingMethod"" value=""standard"" checked> Chuyển thường (25.000đ)
                    </label>
                    <label class=""d-block"">
                        <input type=""radio"" name=""ShippingMethod"" value=""express""> Chuyển nhanh (50.000đ)
                    </label>
                </div>

                <h2 class=""text-uppercase fw-bold"">Phương thức thanh toán</h2>
                <div class=""form-group mb-3"">
                    <label class=""d-block"">
                        <input type=""radio"" name=""PaymentMethod"" value=""cod"" checked> Ship COD
                    </label>
                    <label class=""d-block"">
                        <input type=""radio"" name=""Paym");
                WriteLiteral("entMethod\" value=\"bank\"> Chuyển khoản ngân hàng\r\n                    </label>\r\n                    <!-- Input ẩn để truyền ID địa chỉ -->\r\n                    <input type=\"hidden\" name=\"DeliveryAddress.IdDiaChi\"");
                BeginWriteAttribute("value", " value=\"", 1914, "\"", 1953, 1);
#nullable restore
#line 45 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\Payment.cshtml"
WriteAttributeValue("", 1922, Model.DeliveryAddress.IdDiaChi, 1922, 31, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                </div>\r\n\r\n                <h2 class=\"text-uppercase fw-bold\">Thông tin khác</h2>\r\n                <div class=\"form-group mb-3\">\r\n                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("textarea", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2d46071f549bd15a4acbb67d335a55acf584b6a68055", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_TextAreaTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.TextAreaTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_TextAreaTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
#nullable restore
#line 50 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\Payment.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_TextAreaTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Note);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_TextAreaTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                </div>\r\n            </div>\r\n\r\n            <!-- Right Section -->\r\n            <div class=\"col-md-4\">\r\n                <h2 class=\"fw-bold\">Giao hàng đến</h2>\r\n                <p>");
#nullable restore
#line 57 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\Payment.cshtml"
              Write(Model.DeliveryAddress.HoVaTen);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n                <p>");
#nullable restore
#line 58 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\Payment.cshtml"
              Write(Model.DeliveryAddress.DiaChiGiaoHang);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n                <p>");
#nullable restore
#line 59 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\Payment.cshtml"
              Write(Model.DeliveryAddress.SdtGiaoHang);

#line default
#line hidden
#nullable disable
                WriteLiteral(" - ");
#nullable restore
#line 59 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\Payment.cshtml"
                                                   Write(Model.Shoppers.Email);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n                <a");
                BeginWriteAttribute("href", " href=\"", 2609, "\"", 2648, 1);
#nullable restore
#line 60 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\Payment.cshtml"
WriteAttributeValue("", 2616, Url.Action("Checkout", "Order"), 2616, 32, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"text-primary\">Sửa</a>\r\n\r\n                <h2 class=\"fw-bold\">Đơn hàng (");
#nullable restore
#line 62 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\Payment.cshtml"
                                         Write(Model.CartItems.Count());

#line default
#line hidden
#nullable disable
                WriteLiteral(" sản phẩm)</h2>\r\n                <ul class=\"list-unstyled\">\r\n");
#nullable restore
#line 64 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\Payment.cshtml"
                     foreach (var item in Model.CartItems)
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <li>");
#nullable restore
#line 66 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\Payment.cshtml"
                       Write(item.SoLuong);

#line default
#line hidden
#nullable disable
                WriteLiteral(" x ");
#nullable restore
#line 66 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\Payment.cshtml"
                                       Write(item.SanPham.TenSanPham);

#line default
#line hidden
#nullable disable
                WriteLiteral(" - ");
#nullable restore
#line 66 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\Payment.cshtml"
                                                                   Write((item.SanPham.GiaBan ?? 0).ToString("N0"));

#line default
#line hidden
#nullable disable
                WriteLiteral("đ</li>\r\n");
#nullable restore
#line 67 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\Payment.cshtml"
                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("                </ul>\r\n                <p>Tiền hàng: ");
#nullable restore
#line 69 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\Payment.cshtml"
                         Write(Model.Subtotal.ToString("N0"));

#line default
#line hidden
#nullable disable
                WriteLiteral("đ</p>\r\n                <p>Phí vận chuyển: <span id=\"shippingFeeDisplay\">Chưa có</span></p>\r\n                <p class=\"fw-bold\" style=\"color: orange;\" id=\"totalDisplay\">Tổng cộng: ");
#nullable restore
#line 71 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\Payment.cshtml"
                                                                                  Write(Model.Total.ToString("N0"));

#line default
#line hidden
#nullable disable
                WriteLiteral("đ</p>\r\n            </div>\r\n        </div>\r\n\r\n        <div class=\"row mt-4\">\r\n            <div class=\"col-md-12 d-flex justify-content-between\">\r\n                <a");
                BeginWriteAttribute("href", " href=\"", 3494, "\"", 3533, 1);
#nullable restore
#line 77 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\Payment.cshtml"
WriteAttributeValue("", 3501, Url.Action("Checkout", "Order"), 3501, 32, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"btn btn-link text-muted\">QUAY LẠI</a>\r\n                <button type=\"submit\" class=\"btn btn-warning text-white\">ĐẶT MUA</button>\r\n            </div>\r\n        </div>\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "2d46071f549bd15a4acbb67d335a55acf584b6a616108", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"

    <script>
        // Hàm cập nhật phí vận chuyển và tổng tiền
        function updateFee() {
            var shippingMethod = document.querySelector('input[name=""ShippingMethod""]:checked').value;
            var shippingFee = (shippingMethod === ""standard"") ? 25000 : 50000;
            document.getElementById(""shippingFeeDisplay"").innerText = shippingFee.toLocaleString() + ""đ"";

            var subtotal = ");
#nullable restore
#line 94 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Order\Payment.cshtml"
                      Write(Model.Subtotal);

#line default
#line hidden
#nullable disable
                WriteLiteral(@";
            var total = subtotal + shippingFee;
            document.getElementById(""totalDisplay"").innerText = ""Tổng cộng: "" + total.toLocaleString() + ""đ"";
        }

        document.querySelectorAll('input[name=""ShippingMethod""]').forEach(function (elem) {
            elem.addEventListener(""change"", updateFee);
        });

        updateFee();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebBookStoreManage.ViewModels.PaymentViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
