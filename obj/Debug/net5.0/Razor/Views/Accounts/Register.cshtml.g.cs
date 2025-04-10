#pragma checksum "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Accounts\Register.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "10baaf16729042ddfb84d7401ee6979fb8971bde"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Accounts_Register), @"mvc.1.0.view", @"/Views/Accounts/Register.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"10baaf16729042ddfb84d7401ee6979fb8971bde", @"/Views/Accounts/Register.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"64d8f35278a37e92fb38f314442aaace3ec2b173", @"/Views/_ViewImports.cshtml")]
    public class Views_Accounts_Register : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("h-screen font-sans login bg-cover"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Accounts\Register.cshtml"
  
    ViewData["Title"] = "Register";
    Layout = "~/Views/Shared/_AccountLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "10baaf16729042ddfb84d7401ee6979fb8971bde3728", async() => {
                WriteLiteral("\r\n    <div class=\"container mx-auto h-full flex flex-1 justify-center items-center\">\r\n        <div class=\"w-full max-w-lg\">\r\n            <div class=\"leading-loose\">\r\n");
#nullable restore
#line 11 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Accounts\Register.cshtml"
                 using (Html.BeginForm("Register", "Accounts", FormMethod.Post, new { @class = "max-w-xl m-4 p-10 bg-white rounded shadow-xl" }))
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Accounts\Register.cshtml"
               Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <p class=\"text-gray-800 font-medium text-center text-lg font-bold\">Đăng ký</p>\r\n");
                WriteLiteral("                    <div");
                BeginWriteAttribute("class", " class=\"", 654, "\"", 662, 0);
                EndWriteAttribute();
                WriteLiteral(">\r\n                        <label class=\"block text-sm text-gray-00\" for=\"TenDangNhap\">Username</label>\r\n                        ");
#nullable restore
#line 18 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Accounts\Register.cshtml"
                   Write(Html.TextBox("TenDangNhap", ViewData["TenDangNhap"] as string ?? "", new
                        {
                            @class = "w-full px-5 py-1 text-gray-700 bg-gray-200 rounded",
                            placeholder = "User Name",
                            required = "required",
                            aria_label = "TenDangNhap"
                        }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </div>\r\n");
                WriteLiteral("                    <div class=\"mt-2\">\r\n                        <label class=\"block text-sm text-gray-600\" for=\"MatKhau\">Password</label>\r\n                        ");
#nullable restore
#line 29 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Accounts\Register.cshtml"
                   Write(Html.Password("MatKhau", null, new
                        {
                            @class = "w-full px-5 py-1 text-gray-700 bg-gray-200 rounded",
                            placeholder = "*******",
                            required = "required",
                            aria_label = "MatKhau"
                        }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </div>\r\n");
                WriteLiteral("                    <div class=\"mt-2\">\r\n                        <label class=\"block text-sm text-gray-600\" for=\"ConfirmMatKhau\">Xác nhận mật khẩu</label>\r\n                        ");
#nullable restore
#line 40 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Accounts\Register.cshtml"
                   Write(Html.Password("ConfirmMatKhau", null, new
                        {
                            @class = "w-full px-5 py-1 text-gray-700 bg-gray-200 rounded",
                            placeholder = "*******",
                            required = "required",
                            aria_label = "ConfirmMatKhau"
                        }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </div>\r\n");
                WriteLiteral("                    <!-- Thẻ span hiển thị lỗi nếu mật khẩu nhập lại không khớp -->\r\n                    <span class=\"text-danger\">\r\n");
#nullable restore
#line 51 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Accounts\Register.cshtml"
                         if (TempData["RegisterError"] != null)
                        {
                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 53 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Accounts\Register.cshtml"
                       Write(TempData["RegisterError"]);

#line default
#line hidden
#nullable disable
#nullable restore
#line 53 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Accounts\Register.cshtml"
                                                      
                        }

#line default
#line hidden
#nullable disable
                WriteLiteral("                    </span>\r\n");
                WriteLiteral("                    <!-- Trường hidden gán cố định IdVaiTro = 3 -->\r\n");
#nullable restore
#line 58 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Accounts\Register.cshtml"
               Write(Html.Hidden("IdVaiTro", 3));

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <div class=\"mt-4 items-center justify-between\">\r\n                        <button class=\"px-4 py-1 text-white font-light tracking-wider bg-gray-900 rounded\" type=\"submit\">Đăng ký</button>\r\n                    </div>\r\n");
                WriteLiteral("                    <a class=\"inline-block right-0 align-baseline font-bold text-sm text-500 hover:text-blue-800\"");
                BeginWriteAttribute("href", " href=\"", 3118, "\"", 3157, 1);
#nullable restore
#line 64 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Accounts\Register.cshtml"
WriteAttributeValue("", 3125, Url.Action("Login", "Accounts"), 3125, 32, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n                        Đăng nhập\r\n                    </a>\r\n");
#nullable restore
#line 67 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Accounts\Register.cshtml"
                }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n\r\n\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
