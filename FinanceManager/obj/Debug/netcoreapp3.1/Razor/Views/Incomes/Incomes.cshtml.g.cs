#pragma checksum "C:\Users\Matthew Almeida\Source\Repos\FinanceManager\FinanceManager\Views\Incomes\Incomes.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "41d8978d6fcce7ffc61e5b88359357a211eaed08"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Incomes_Incomes), @"mvc.1.0.view", @"/Views/Incomes/Incomes.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"41d8978d6fcce7ffc61e5b88359357a211eaed08", @"/Views/Incomes/Incomes.cshtml")]
    public class Views_Incomes_Incomes : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<FinanceManager.Models.ViewModels.IncomesViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"

<br>
<br>
<br>
<br>
<br>
<br>
<div class=""container"">
    <a href=""/Incomes/NewIncome"" class=""btn btn-primary"">New</a>
    <br>
    <br>
    <table class=""table"">
        <thead>
            <tr>
                <th scope=""col"">Id</th>
                <th scope=""col"">User</th>
                <th scope=""col"">Description</th>
                <th scope=""col"">Value</th>
                <th scope=""col""></th>
            </tr>
        </thead>
        <tbody>

");
#nullable restore
#line 26 "C:\Users\Matthew Almeida\Source\Repos\FinanceManager\FinanceManager\Views\Incomes\Incomes.cshtml"
             foreach (var income in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <th scope=\"row\">");
#nullable restore
#line 29 "C:\Users\Matthew Almeida\Source\Repos\FinanceManager\FinanceManager\Views\Incomes\Incomes.cshtml"
                               Write(income.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                    <td>");
#nullable restore
#line 30 "C:\Users\Matthew Almeida\Source\Repos\FinanceManager\FinanceManager\Views\Incomes\Incomes.cshtml"
                   Write(income.Username);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 31 "C:\Users\Matthew Almeida\Source\Repos\FinanceManager\FinanceManager\Views\Incomes\Incomes.cshtml"
                   Write(income.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 32 "C:\Users\Matthew Almeida\Source\Repos\FinanceManager\FinanceManager\Views\Incomes\Incomes.cshtml"
                   Write(income.Value);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td><a");
            BeginWriteAttribute("href", " href=\"", 851, "\"", 892, 2);
            WriteAttributeValue("", 858, "/Incomes/EditIncome/?id=", 858, 24, true);
#nullable restore
#line 33 "C:\Users\Matthew Almeida\Source\Repos\FinanceManager\FinanceManager\Views\Incomes\Incomes.cshtml"
WriteAttributeValue("", 882, income.Id, 882, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-primary\">Edit</a></td>\r\n                </tr>\r\n");
#nullable restore
#line 35 "C:\Users\Matthew Almeida\Source\Repos\FinanceManager\FinanceManager\Views\Incomes\Incomes.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<FinanceManager.Models.ViewModels.IncomesViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591