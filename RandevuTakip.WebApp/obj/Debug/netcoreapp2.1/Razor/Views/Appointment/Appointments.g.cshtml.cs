#pragma checksum "C:\MR\Çalışma\Büşra Durna\RandevuTakip\RandevuTakip.WebApp\Views\Appointment\Appointments.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "96246a6c34b62aea7b1fa9da54c04d49111fa96b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Appointment_Appointments), @"mvc.1.0.view", @"/Views/Appointment/Appointments.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Appointment/Appointments.cshtml", typeof(AspNetCore.Views_Appointment_Appointments))]
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
#line 1 "C:\MR\Çalışma\Büşra Durna\RandevuTakip\RandevuTakip.WebApp\Views\_ViewImports.cshtml"
using RandevuTakip.Models;

#line default
#line hidden
#line 2 "C:\MR\Çalışma\Büşra Durna\RandevuTakip\RandevuTakip.WebApp\Views\_ViewImports.cshtml"
using RandevuTakip.Entities;

#line default
#line hidden
#line 3 "C:\MR\Çalışma\Büşra Durna\RandevuTakip\RandevuTakip.WebApp\Views\_ViewImports.cshtml"
using RandevuTakip.Entities.Identity;

#line default
#line hidden
#line 5 "C:\MR\Çalışma\Büşra Durna\RandevuTakip\RandevuTakip.WebApp\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"96246a6c34b62aea7b1fa9da54c04d49111fa96b", @"/Views/Appointment/Appointments.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c31cc499b5f7e815e8bc7dc84449ab191c2746d3", @"/Views/_ViewImports.cshtml")]
    public class Views_Appointment_Appointments : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Appointment>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(26, 66, true);
            WriteLiteral("\r\n<div class=\"row\">\r\n    <div class=\"listed\" style=\"width:100%\">\r\n");
            EndContext();
#line 5 "C:\MR\Çalışma\Büşra Durna\RandevuTakip\RandevuTakip.WebApp\Views\Appointment\Appointments.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
            BeginContext(141, 231, true);
            WriteLiteral("            <div class=\"row\">\r\n                <div class=\"col-lg-12\">\r\n                    <div class=\"item-meeting\">\r\n                        <div class=\"avatar-doctor\">\r\n\r\n                            <div class=\"avatar-image\">\r\n");
            EndContext();
            BeginContext(453, 183, true);
            WriteLiteral("                                <h4>\r\n                                    <i class=\"fa fa-user-md\" aria-hidden=\"true\"></i>\r\n                                    <a title=\"See Profile\">");
            EndContext();
            BeginContext(637, 17, false);
#line 16 "C:\MR\Çalışma\Büşra Durna\RandevuTakip\RandevuTakip.WebApp\Views\Appointment\Appointments.cshtml"
                                                      Write(item.Patient.Name);

#line default
#line hidden
            EndContext();
            BeginContext(654, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(656, 20, false);
#line 16 "C:\MR\Çalışma\Büşra Durna\RandevuTakip\RandevuTakip.WebApp\Views\Appointment\Appointments.cshtml"
                                                                         Write(item.Patient.Surname);

#line default
#line hidden
            EndContext();
            BeginContext(676, 292, true);
            WriteLiteral(@"</a>
                                </h4>

                            </div>
                        </div>
                        <div class=""data-meeting"">
                            <ul class=""list-unstyled info-meet"">
                                <li><p>Doğum Tarihi: <span>");
            EndContext();
            BeginContext(969, 42, false);
#line 23 "C:\MR\Çalışma\Büşra Durna\RandevuTakip\RandevuTakip.WebApp\Views\Appointment\Appointments.cshtml"
                                                      Write(item.Patient.BirthDate.ToShortDateString());

#line default
#line hidden
            EndContext();
            BeginContext(1011, 70, true);
            WriteLiteral("</span></p></li>\r\n                                <li><p>Tarih: <span>");
            EndContext();
            BeginContext(1082, 34, false);
#line 24 "C:\MR\Çalışma\Büşra Durna\RandevuTakip\RandevuTakip.WebApp\Views\Appointment\Appointments.cshtml"
                                               Write(item.Timestamp.ToShortDateString());

#line default
#line hidden
            EndContext();
            BeginContext(1116, 82, true);
            WriteLiteral("</span></p></li>\r\n                                <li><p class=\"time\">Saat: <span>");
            EndContext();
            BeginContext(1199, 34, false);
#line 25 "C:\MR\Çalışma\Büşra Durna\RandevuTakip\RandevuTakip.WebApp\Views\Appointment\Appointments.cshtml"
                                                           Write(item.Timestamp.ToShortTimeString());

#line default
#line hidden
            EndContext();
            BeginContext(1233, 86, true);
            WriteLiteral("</span></p></li>\r\n                                <li><p class=\"phone\">Telefon: <span>");
            EndContext();
            BeginContext(1320, 18, false);
#line 26 "C:\MR\Çalışma\Büşra Durna\RandevuTakip\RandevuTakip.WebApp\Views\Appointment\Appointments.cshtml"
                                                               Write(item.Patient.Phone);

#line default
#line hidden
            EndContext();
            BeginContext(1338, 18, true);
            WriteLiteral("</span></p></li>\r\n");
            EndContext();
            BeginContext(1634, 526, true);
            WriteLiteral(@"                            </ul>
                            <ul class=""list-unstyled btns"">
                                <li><button class=""btn btn-red btn-xsmall confirm""><i class=""fa fa-times"" aria-hidden=""true""></i> İptal</button></li>
                                <li><a class=""btn btn-xsmall"" href=""#""><i class=""fa fa-arrow-down"" aria-hidden=""true""></i> Yazdır</a></li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
");
            EndContext();
#line 39 "C:\MR\Çalışma\Büşra Durna\RandevuTakip\RandevuTakip.WebApp\Views\Appointment\Appointments.cshtml"
        }

#line default
#line hidden
            BeginContext(2171, 24, true);
            WriteLiteral("    </div>\r\n    </div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Appointment>> Html { get; private set; }
    }
}
#pragma warning restore 1591