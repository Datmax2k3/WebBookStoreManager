#pragma checksum "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Shared\Navbar\_ProductFilter.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "84df4243ce82488c4d53e7a3e9493ac719424042"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Navbar__ProductFilter), @"mvc.1.0.view", @"/Views/Shared/Navbar/_ProductFilter.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"84df4243ce82488c4d53e7a3e9493ac719424042", @"/Views/Shared/Navbar/_ProductFilter.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"64d8f35278a37e92fb38f314442aaace3ec2b173", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Navbar__ProductFilter : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WebBookStoreManage.ViewModels.ProductViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("filterForm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"filter-block card p-3 mb-3\">\r\n    <h3 class=\"card-title\">Lọc theo danh mục</h3>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "84df4243ce82488c4d53e7a3e9493ac7194240423763", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 6 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Shared\Navbar\_ProductFilter.cshtml"
         foreach (var dm in Model.DanhMucs)
        {

#line default
#line hidden
#nullable disable
                WriteLiteral("            <div class=\"category mb-3\">\r\n                <div class=\"form-check\">\r\n                    <!-- Gắn data-category-id để dễ thao tác -->\r\n                    <input class=\"form-check-input category-checkbox\" type=\"checkbox\" name=\"danhmuc\"");
                BeginWriteAttribute("value", " value=\"", 483, "\"", 504, 1);
#nullable restore
#line 11 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Shared\Navbar\_ProductFilter.cshtml"
WriteAttributeValue("", 491, dm.IdDanhMuc, 491, 13, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                BeginWriteAttribute("id", " id=\"", 505, "\"", 531, 2);
                WriteAttributeValue("", 510, "danhmuc_", 510, 8, true);
#nullable restore
#line 11 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Shared\Navbar\_ProductFilter.cshtml"
WriteAttributeValue("", 518, dm.IdDanhMuc, 518, 13, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("\r\n                           data-category-id=\"");
#nullable restore
#line 12 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Shared\Navbar\_ProductFilter.cshtml"
                                        Write(dm.IdDanhMuc);

#line default
#line hidden
#nullable disable
                WriteLiteral("\"\r\n                           ");
#nullable restore
#line 13 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Shared\Navbar\_ProductFilter.cshtml"
                       Write(Model.SelectedDanhMuc?.Split(',').Contains(dm.IdDanhMuc.ToString()) == true ? "checked" : "");

#line default
#line hidden
#nullable disable
                WriteLiteral(">\r\n                    <label class=\"form-check-label\"");
                BeginWriteAttribute("for", " for=\"", 771, "\"", 798, 2);
                WriteAttributeValue("", 777, "danhmuc_", 777, 8, true);
#nullable restore
#line 14 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Shared\Navbar\_ProductFilter.cshtml"
WriteAttributeValue("", 785, dm.IdDanhMuc, 785, 13, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n                        ");
#nullable restore
#line 15 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Shared\Navbar\_ProductFilter.cshtml"
                   Write(dm.TenDanhMuc);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </label>\r\n                </div>\r\n");
#nullable restore
#line 18 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Shared\Navbar\_ProductFilter.cshtml"
                 if (dm.DanhMucChiTiets != null && dm.DanhMucChiTiets.Any())
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <!-- Gói DANHMUCCHITIET trong 1 div có data-parent-category tương ứng -->\r\n                    <div class=\"sub-category ml-4 mt-2\" data-parent-category=\"");
#nullable restore
#line 21 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Shared\Navbar\_ProductFilter.cshtml"
                                                                         Write(dm.IdDanhMuc);

#line default
#line hidden
#nullable disable
                WriteLiteral("\" style=\"display: none;\">\r\n                        <div class=\"font-weight-bold mb-1\">Chi tiết:</div>\r\n");
#nullable restore
#line 23 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Shared\Navbar\_ProductFilter.cshtml"
                         foreach (var dmc in dm.DanhMucChiTiets)
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <div class=\"form-check\">\r\n                                <input class=\"form-check-input\" type=\"checkbox\" name=\"danhmucchitiet\"");
                BeginWriteAttribute("value", " value=\"", 1530, "\"", 1554, 1);
#nullable restore
#line 26 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Shared\Navbar\_ProductFilter.cshtml"
WriteAttributeValue("", 1538, dmc.IdDanhMucCT, 1538, 16, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                BeginWriteAttribute("id", " id=\"", 1555, "\"", 1591, 2);
                WriteAttributeValue("", 1560, "danhmucchitiet_", 1560, 15, true);
#nullable restore
#line 26 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Shared\Navbar\_ProductFilter.cshtml"
WriteAttributeValue("", 1575, dmc.IdDanhMucCT, 1575, 16, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("\r\n                                       ");
#nullable restore
#line 27 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Shared\Navbar\_ProductFilter.cshtml"
                                   Write(Model.SelectedDanhMucChiTiet?.Split(',').Contains(dmc.IdDanhMucCT.ToString()) == true ? "checked" : "");

#line default
#line hidden
#nullable disable
                WriteLiteral(">\r\n                                <label class=\"form-check-label\"");
                BeginWriteAttribute("for", " for=\"", 1804, "\"", 1841, 2);
                WriteAttributeValue("", 1810, "danhmucchitiet_", 1810, 15, true);
#nullable restore
#line 28 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Shared\Navbar\_ProductFilter.cshtml"
WriteAttributeValue("", 1825, dmc.IdDanhMucCT, 1825, 16, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n                                    ");
#nullable restore
#line 29 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Shared\Navbar\_ProductFilter.cshtml"
                               Write(dmc.TenDanhMucCT);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                </label>\r\n                            </div>\r\n");
#nullable restore
#line 32 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Shared\Navbar\_ProductFilter.cshtml"
                        }

#line default
#line hidden
#nullable disable
                WriteLiteral("                    </div>\r\n");
#nullable restore
#line 34 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Shared\Navbar\_ProductFilter.cshtml"
                }

#line default
#line hidden
#nullable disable
                WriteLiteral("            </div>\r\n");
#nullable restore
#line 36 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Shared\Navbar\_ProductFilter.cshtml"
        }

#line default
#line hidden
#nullable disable
                WriteLiteral("        <button type=\"submit\" class=\"btn btn-primary mt-3\">Lọc</button>\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebBookStoreManage.ViewModels.ProductViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
