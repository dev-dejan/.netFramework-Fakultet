#pragma checksum "D:\Luka\ITS\Seminarski\PPP\LatkovicStanicRentACar\Rent a car\RentACar\RentACar\Views\Home\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a6e694b5790b9f181c670e7c938f2f0a9f52f97c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Details), @"mvc.1.0.view", @"/Views/Home/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Details.cshtml", typeof(AspNetCore.Views_Home_Details))]
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
#line 1 "D:\Luka\ITS\Seminarski\PPP\LatkovicStanicRentACar\Rent a car\RentACar\RentACar\Views\_ViewImports.cshtml"
using RentACar;

#line default
#line hidden
#line 2 "D:\Luka\ITS\Seminarski\PPP\LatkovicStanicRentACar\Rent a car\RentACar\RentACar\Views\_ViewImports.cshtml"
using RentACar.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a6e694b5790b9f181c670e7c938f2f0a9f52f97c", @"/Views/Home/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0eb15c43ca34d0757bf544ad01cf9e6fac7aec62", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DetailsViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "D:\Luka\ITS\Seminarski\PPP\LatkovicStanicRentACar\Rent a car\RentACar\RentACar\Views\Home\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
            BeginContext(68, 155, true);
            WriteLiteral("\r\n<main class=\"container\">\r\n    <div class=\"form-group\" align=\"center\">\r\n        <div>\r\n            <label><strong>Marka</strong></label>\r\n            <h1>");
            EndContext();
            BeginContext(224, 21, false);
#line 10 "D:\Luka\ITS\Seminarski\PPP\LatkovicStanicRentACar\Rent a car\RentACar\RentACar\Views\Home\Details.cshtml"
           Write(Model.Automobil.Marka);

#line default
#line hidden
            EndContext();
            BeginContext(245, 136, true);
            WriteLiteral("</h1>\r\n        </div>\r\n        <hr />\r\n        <br />\r\n        <div>\r\n            <label><strong>Naziv</strong></label>\r\n            <p>");
            EndContext();
            BeginContext(382, 21, false);
#line 16 "D:\Luka\ITS\Seminarski\PPP\LatkovicStanicRentACar\Rent a car\RentACar\RentACar\Views\Home\Details.cshtml"
          Write(Model.Automobil.Naziv);

#line default
#line hidden
            EndContext();
            BeginContext(403, 121, true);
            WriteLiteral("</p>\r\n        </div>\r\n        <br />\r\n        <div>\r\n            <label><strong>Godiste</strong></label>\r\n            <p>");
            EndContext();
            BeginContext(525, 22, false);
#line 21 "D:\Luka\ITS\Seminarski\PPP\LatkovicStanicRentACar\Rent a car\RentACar\RentACar\Views\Home\Details.cshtml"
          Write(Model.Automobil.Godina);

#line default
#line hidden
            EndContext();
            BeginContext(547, 118, true);
            WriteLiteral("</p>\r\n        </div>\r\n        <br />\r\n        <div>\r\n            <label><strong>Cena</strong></label>\r\n            <p>");
            EndContext();
            BeginContext(666, 20, false);
#line 26 "D:\Luka\ITS\Seminarski\PPP\LatkovicStanicRentACar\Rent a car\RentACar\RentACar\Views\Home\Details.cshtml"
          Write(Model.Automobil.Cena);

#line default
#line hidden
            EndContext();
            BeginContext(686, 110, true);
            WriteLiteral("</p>\r\n        </div>\r\n        <br />\r\n        <div>\r\n            <label><strong>Iznajmljen?</strong></label>\r\n");
            EndContext();
#line 31 "D:\Luka\ITS\Seminarski\PPP\LatkovicStanicRentACar\Rent a car\RentACar\RentACar\Views\Home\Details.cshtml"
             if (Model.Automobil.IsIznajmljeno == 0)
            {

#line default
#line hidden
            BeginContext(865, 40, true);
            WriteLiteral("                <p>Nije iznajmljen</p>\r\n");
            EndContext();
#line 34 "D:\Luka\ITS\Seminarski\PPP\LatkovicStanicRentACar\Rent a car\RentACar\RentACar\Views\Home\Details.cshtml"
            }
            else
            {

#line default
#line hidden
            BeginContext(953, 35, true);
            WriteLiteral("                <p>Iznajmljen</p>\r\n");
            EndContext();
#line 38 "D:\Luka\ITS\Seminarski\PPP\LatkovicStanicRentACar\Rent a car\RentACar\RentACar\Views\Home\Details.cshtml"
            }

#line default
#line hidden
            BeginContext(1003, 118, true);
            WriteLiteral("        </div>\r\n        <br />\r\n        <div>\r\n            <label><strong>Osiguranje</strong></label>\r\n            <p>");
            EndContext();
            BeginContext(1122, 28, false);
#line 43 "D:\Luka\ITS\Seminarski\PPP\LatkovicStanicRentACar\Rent a car\RentACar\RentACar\Views\Home\Details.cshtml"
          Write(Model.Automobil.IdOsiguranja);

#line default
#line hidden
            EndContext();
            BeginContext(1150, 41, true);
            WriteLiteral("</p>\r\n        </div>\r\n    </div>\r\n</main>");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DetailsViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
