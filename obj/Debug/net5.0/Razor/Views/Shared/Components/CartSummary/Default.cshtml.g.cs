#pragma checksum "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Shared\Components\CartSummary\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "63d1a8cf1533df60c2ddadb6faa310fd0a2e8503"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_CartSummary_Default), @"mvc.1.0.view", @"/Views/Shared/Components/CartSummary/Default.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"63d1a8cf1533df60c2ddadb6faa310fd0a2e8503", @"/Views/Shared/Components/CartSummary/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"64d8f35278a37e92fb38f314442aaace3ec2b173", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_CartSummary_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WebBookStoreManage.ViewModels.CartViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<a");
            BeginWriteAttribute("href", " href=\"", 54, "\"", 89, 1);
#nullable restore
#line 2 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Shared\Components\CartSummary\Default.cshtml"
WriteAttributeValue("", 61, Url.Action("Index", "Cart"), 61, 28, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"cart for-buy\" id=\"cart-icon\">\r\n    <i class=\"fas fa-clipboard\"></i>\r\n    <span>Giỏ hàng <span id=\"cart-quantity\">(");
#nullable restore
#line 4 "D:\Workspace\N4_HK2\WebBookStoreManage\Views\Shared\Components\CartSummary\Default.cshtml"
                                        Write(Model.TotalQuantity);

#line default
#line hidden
#nullable disable
            WriteLiteral(@")</span></span>
</a>



<script>
    document.addEventListener('click', function (e) {
        var btn = e.target.closest('.add-to-cart');
        if (!btn) return;
        e.preventDefault();

        var productId = btn.getAttribute('data-product-id');
        var quantity = 1; // hoặc lấy từ input

        fetch('/Cart/AddToCart', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ productId, quantity })
        })
            .then(r => r.json())
            .then(data => {
                if (data.success) {
                    // Cập nhật badge số lượng
                    document.getElementById('cart-quantity').innerText = data.totalQuantity;
                    // Hiển thị toast nếu muốn
                    showCartToast(`Đã thêm ${data.productName}`);
                } else if (data.redirectTo) {
                    window.location = data.redirectTo;
                } else {
                    sho");
            WriteLiteral("wCartToast(data.message, \'error\');\r\n                }\r\n            });\r\n    });\r\n\r\n</script>");
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
