#pragma checksum "C:\Users\Matthew Almeida\source\repos\FinanceManager\FinanceManager\Views\Login\Login.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9a88c95eb4ba841266260bf2941ec9311aea2a45"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Login_Login), @"mvc.1.0.razor-page", @"/Views/Login/Login.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9a88c95eb4ba841266260bf2941ec9311aea2a45", @"/Views/Login/Login.cshtml")]
    public class Views_Login_Login : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 5 "C:\Users\Matthew Almeida\source\repos\FinanceManager\FinanceManager\Views\Login\Login.cshtml"
 if ((bool)ViewBag.IsFirstAccess)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <br>\r\n    <div class=\"container\">\r\n        <div class=\"alert alert-primary\" role=\"alert\">\r\n            Click here to register. <a class=\"btn btn-primary\" href=\"/Login/RegisterUser\">Register</a>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 13 "C:\Users\Matthew Almeida\source\repos\FinanceManager\FinanceManager\Views\Login\Login.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div style=""position: fixed; top: 50%; left: 50%; transform: translate(-50%, -50%);"">
    <div class=""container"">
        <form action=""/Login/SubmitLogin"">
            <div class=""form-group"">
                <label>Username</label>
                <input type=""text"" class=""form-control"" id=""Username"" placeholder=""Enter email"">
            </div>
            <div class=""form-group"">
                <label>Password</label>
                <input type=""password"" class=""form-control"" id=""Password"" placeholder=""Password"">
            </div>
            <button type=""submit"" class=""btn btn-primary"">Submit</button>
        </form>
    </div>
</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<FinanceManager.Models.ViewModels.LoginViewModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<FinanceManager.Models.ViewModels.LoginViewModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<FinanceManager.Models.ViewModels.LoginViewModel>)PageContext?.ViewData;
        public FinanceManager.Models.ViewModels.LoginViewModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591