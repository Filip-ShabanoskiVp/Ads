#pragma checksum "C:\Users\FILIP\Desktop\najnovaVerzijaAplikacija\Oglasi\Oglasi\Views\Korisniks\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3c20c37fa0c037e895066fde8ed2975f9cf89d89"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Korisniks_Details), @"mvc.1.0.view", @"/Views/Korisniks/Details.cshtml")]
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
#line 1 "C:\Users\FILIP\Desktop\najnovaVerzijaAplikacija\Oglasi\Oglasi\Views\_ViewImports.cshtml"
using Oglasi;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\FILIP\Desktop\najnovaVerzijaAplikacija\Oglasi\Oglasi\Views\_ViewImports.cshtml"
using Oglasi.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3c20c37fa0c037e895066fde8ed2975f9cf89d89", @"/Views/Korisniks/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a51b085b35abdc0f07e6204b056768950d0294cd", @"/Views/_ViewImports.cshtml")]
    public class Views_Korisniks_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Oglasi.Models.UserOglasi>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\FILIP\Desktop\najnovaVerzijaAplikacija\Oglasi\Oglasi\Views\Korisniks\Details.cshtml"
  
    ViewData["Title"] = "Details";


#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<br />
<br />
<br />
<br />

<div class=""container"">
    <div class=""card mb-4"">
        <div class=""card-header"">
            <h1>Мој огласи</h1>
            </div>
        <div class=""card-body"">
                <table class=""table"" style=""border:1px solid gray"">
                    <thead style=""background-color:DarkCyan"">
                    <th><a id=""zacuvani"" href=""#"" style=""color:white;text-decoration:none"">Зачувани огласи</a></th>
                    <th><a id=""preporacani"" href=""#"" style=""color:white;text-decoration:none"">Препорачани огласи</a></th>
                    <th><a id=""kupeni"" href=""#"" style=""color:white;text-decoration:none"">Купени огласи</a></th>
                    </thead>
                    <tbody style=""background-color:white"">
                        <tr>
                            <td id=""zac"">
");
#nullable restore
#line 36 "C:\Users\FILIP\Desktop\najnovaVerzijaAplikacija\Oglasi\Oglasi\Views\Korisniks\Details.cshtml"
                                 foreach (var i in Model.Saved)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <p>");
#nullable restore
#line 38 "C:\Users\FILIP\Desktop\najnovaVerzijaAplikacija\Oglasi\Oglasi\Views\Korisniks\Details.cshtml"
                                  Write(i.ImeOglas);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 39 "C:\Users\FILIP\Desktop\najnovaVerzijaAplikacija\Oglasi\Oglasi\Views\Korisniks\Details.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </td>\r\n                            <td id=\"prep\">\r\n");
#nullable restore
#line 42 "C:\Users\FILIP\Desktop\najnovaVerzijaAplikacija\Oglasi\Oglasi\Views\Korisniks\Details.cshtml"
                                 foreach (var ind in Model.Recomended)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <p>");
#nullable restore
#line 44 "C:\Users\FILIP\Desktop\najnovaVerzijaAplikacija\Oglasi\Oglasi\Views\Korisniks\Details.cshtml"
                                  Write(ind.ImeOglas);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 45 "C:\Users\FILIP\Desktop\najnovaVerzijaAplikacija\Oglasi\Oglasi\Views\Korisniks\Details.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </td>\r\n                            <td id=\"kup\">\r\n");
#nullable restore
#line 48 "C:\Users\FILIP\Desktop\najnovaVerzijaAplikacija\Oglasi\Oglasi\Views\Korisniks\Details.cshtml"
                                 foreach (var inde in Model.Bought)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <p>");
#nullable restore
#line 50 "C:\Users\FILIP\Desktop\najnovaVerzijaAplikacija\Oglasi\Oglasi\Views\Korisniks\Details.cshtml"
                                  Write(inde.ImeOglas);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 51 "C:\Users\FILIP\Desktop\najnovaVerzijaAplikacija\Oglasi\Oglasi\Views\Korisniks\Details.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </td>\r\n                        </tr>\r\n                    </tbody>\r\n                </table>\r\n            </div>\r\n        </div>\r\n    </div>\r\n\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
                <script src=""https://code.jquery.com/ui/1.12.1/jquery-ui.min.js""
                        integrity=""sha256-VazP97ZCwtekAsvgPBSUwPFKdrwD3unUfSGVYrahUqU=""
                        crossorigin=""anonymous""></script>
                <script>

                </script>
            ");
            }
            );
            WriteLiteral("\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Oglasi.Models.UserOglasi> Html { get; private set; }
    }
}
#pragma warning restore 1591
