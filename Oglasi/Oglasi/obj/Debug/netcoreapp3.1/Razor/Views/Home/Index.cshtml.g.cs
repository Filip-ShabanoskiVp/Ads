#pragma checksum "C:\Users\FILIP\Desktop\najnovaVerzijaAplikacija\Oglasi\Oglasi\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "26d02585b520c1d2546e0e17908e0403b24dce9e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"26d02585b520c1d2546e0e17908e0403b24dce9e", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a51b085b35abdc0f07e6204b056768950d0294cd", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Oglasi.Models.Kategorija>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/jquery/dist/jquery.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"



<style>
</style>

<br />
<br />
<br />
<br />

<div id=""carouselExampleIndicators"" class=""carousel slide"" data-ride=""carousel"">
    <ol class=""carousel-indicators"">
        <li data-target=""#carouselExampleIndicators"" data-slide-to=""0"" class=""active""></li>
        <li data-target=""#carouselExampleIndicators"" data-slide-to=""1""></li>
        <li data-target=""#carouselExampleIndicators"" data-slide-to=""2""></li>
        <li data-target=""#carouselExampleIndicators"" data-slide-to=""3""></li>
        <li data-target=""#carouselExampleIndicators"" data-slide-to=""4""></li>
        <li data-target=""#carouselExampleIndicators"" data-slide-to=""5""></li>
    </ol>
    <div class=""carousel-inner"">
");
#nullable restore
#line 27 "C:\Users\FILIP\Desktop\najnovaVerzijaAplikacija\Oglasi\Oglasi\Views\Home\Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"carousel-item text-center p-2\">\r\n                <h2>");
#nullable restore
#line 30 "C:\Users\FILIP\Desktop\najnovaVerzijaAplikacija\Oglasi\Oglasi\Views\Home\Index.cshtml"
               Write(item.ImeKat);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n                <span>\r\n                    ");
#nullable restore
#line 32 "C:\Users\FILIP\Desktop\najnovaVerzijaAplikacija\Oglasi\Oglasi\Views\Home\Index.cshtml"
               Write(item.BrojNaOglasi);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </span>\r\n            </div>\r\n            <br />\r\n");
#nullable restore
#line 36 "C:\Users\FILIP\Desktop\najnovaVerzijaAplikacija\Oglasi\Oglasi\Views\Home\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    </div>
    <a class=""carousel-control-prev"" href=""#carouselExampleIndicators"" role=""button"" data-slide=""prev"">
        <span class=""carousel-control-prev-icon"" aria-hidden=""true""></span>
        <span class=""sr-only"">Previous</span>
    </a>
    <a class=""carousel-control-next"" href=""#carouselExampleIndicators"" role=""button"" data-slide=""next"">
        <span class=""carousel-control-next-icon"" aria-hidden=""true""></span>
        <span class=""sr-only"">Next</span>
    </a>
</div>
<input type=""button"" id=""open_ad"" value=""Отвори огласи"" class=""btn btn-info"" ");
            WriteLiteral(" />\r\n<input type=\"button\" value=\"Додади оглас\" class=\"btn btn-info\"");
            BeginWriteAttribute("onclick", " onclick=\'", 1843, "\'", 1908, 5);
            WriteAttributeValue("", 1853, "window.location.href", 1853, 20, true);
            WriteAttributeValue(" ", 1873, "=", 1874, 2, true);
            WriteAttributeValue(" ", 1875, "\"", 1876, 2, true);
#nullable restore
#line 48 "C:\Users\FILIP\Desktop\najnovaVerzijaAplikacija\Oglasi\Oglasi\Views\Home\Index.cshtml"
WriteAttributeValue("", 1877, Url.Action("Create", "Oglas"), 1877, 30, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1907, "\"", 1907, 1, true);
            EndWriteAttribute();
            WriteLiteral(" />\r\n<input type=\"button\" id=\"open_all\" value=\"Отвори ги сите огласи\" class=\"btn btn-info\"");
            BeginWriteAttribute("onclick", " onclick=\'", 1999, "\'", 2063, 5);
            WriteAttributeValue("", 2009, "window.location.href", 2009, 20, true);
            WriteAttributeValue(" ", 2029, "=", 2030, 2, true);
            WriteAttributeValue(" ", 2031, "\"", 2032, 2, true);
#nullable restore
#line 49 "C:\Users\FILIP\Desktop\najnovaVerzijaAplikacija\Oglasi\Oglasi\Views\Home\Index.cshtml"
WriteAttributeValue("", 2033, Url.Action("Index", "Oglas"), 2033, 29, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2062, "\"", 2062, 1, true);
            EndWriteAttribute();
            WriteLiteral(" />\r\n\r\n\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "26d02585b520c1d2546e0e17908e0403b24dce9e7565", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

<script>
    $(function () {
        $("".carousel-inner"").children("":first"").toggleClass(""active"");
    });
    $(""#open_ad"").on(""click"", () => {
        let ImeKat = $("".carousel-item.active>h2"").html();
        //if ImeKat
        //alert(ImeKat);
        if (ImeKat == ""Возила"") {
            var url = '");
#nullable restore
#line 64 "C:\Users\FILIP\Desktop\najnovaVerzijaAplikacija\Oglasi\Oglasi\Views\Home\Index.cshtml"
                  Write(Url.Action("Index", "Oglas", new { id = 1 }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\';\r\n            window.location.href = url;\r\n        }\r\n        else if (ImeKat == \"Литература\") {\r\n            var url = \'");
#nullable restore
#line 68 "C:\Users\FILIP\Desktop\najnovaVerzijaAplikacija\Oglasi\Oglasi\Views\Home\Index.cshtml"
                  Write(Url.Action("Index", "Oglas", new { id = 2 }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\';\r\n            window.location.href = url;\r\n        }\r\n        else if (ImeKat == \"Недвижнини\") {\r\n            var url = \'");
#nullable restore
#line 72 "C:\Users\FILIP\Desktop\najnovaVerzijaAplikacija\Oglasi\Oglasi\Views\Home\Index.cshtml"
                  Write(Url.Action("Index", "Oglas", new { id = 3 }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\';\r\n            window.location.href = url;\r\n        }\r\n        else if (ImeKat == \"За дом\") {\r\n            var url = \'");
#nullable restore
#line 76 "C:\Users\FILIP\Desktop\najnovaVerzijaAplikacija\Oglasi\Oglasi\Views\Home\Index.cshtml"
                  Write(Url.Action("Index", "Oglas", new { id = 4 }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\';\r\n            window.location.href = url;\r\n        }\r\n        else if (ImeKat == \"Технологија\") {\r\n            var url = \'");
#nullable restore
#line 80 "C:\Users\FILIP\Desktop\najnovaVerzijaAplikacija\Oglasi\Oglasi\Views\Home\Index.cshtml"
                  Write(Url.Action("Index", "Oglas", new { id = 5 }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\';\r\n            window.location.href = url;\r\n        }\r\n        else if (ImeKat == \"Спорт и спортска опрема\") {\r\n            var url = \'");
#nullable restore
#line 84 "C:\Users\FILIP\Desktop\najnovaVerzijaAplikacija\Oglasi\Oglasi\Views\Home\Index.cshtml"
                  Write(Url.Action("Index", "Oglas", new { id = 6 }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\';\r\n            window.location.href = url;\r\n        }\r\n    });\r\n\r\n</script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Oglasi.Models.Kategorija>> Html { get; private set; }
    }
}
#pragma warning restore 1591