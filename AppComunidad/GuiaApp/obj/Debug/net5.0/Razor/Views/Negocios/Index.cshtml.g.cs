#pragma checksum "C:\Users\Usuario\Desktop\DSD\DSDTrabajoFinal\AppComunidad\GuiaApp\Views\Negocios\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9fe7c71e15a404aee52fd98a54c0283ceac91bf9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Negocios_Index), @"mvc.1.0.view", @"/Views/Negocios/Index.cshtml")]
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
#line 1 "C:\Users\Usuario\Desktop\DSD\DSDTrabajoFinal\AppComunidad\GuiaApp\Views\_ViewImports.cshtml"
using GuiaApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Usuario\Desktop\DSD\DSDTrabajoFinal\AppComunidad\GuiaApp\Views\_ViewImports.cshtml"
using GuiaApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9fe7c71e15a404aee52fd98a54c0283ceac91bf9", @"/Views/Negocios/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"79a67a9d98bb48a5924d5bcae120651fe375a375", @"/Views/_ViewImports.cshtml")]
    public class Views_Negocios_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<GuiaApp.Models.NegocioIndexModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Usuario\Desktop\DSD\DSDTrabajoFinal\AppComunidad\GuiaApp\Views\Negocios\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_LayoutCliente.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n");
#nullable restore
#line 10 "C:\Users\Usuario\Desktop\DSD\DSDTrabajoFinal\AppComunidad\GuiaApp\Views\Negocios\Index.cshtml"
 if (Model != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div class=""container"">
        <div class=""row"">
            <div class=""col-lg-12"">
                <div class=""section-title"">
                    <h2>Categorias</h2>
                </div>
                <div class=""featured__controls"">
                    <ul>
                        <li class=""active"" data-filter=""*"">Todas</li>
");
#nullable restore
#line 21 "C:\Users\Usuario\Desktop\DSD\DSDTrabajoFinal\AppComunidad\GuiaApp\Views\Negocios\Index.cshtml"
                         foreach (var item in Model.categorias)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <li data-filter=\"");
#nullable restore
#line 23 "C:\Users\Usuario\Desktop\DSD\DSDTrabajoFinal\AppComunidad\GuiaApp\Views\Negocios\Index.cshtml"
                                        Write(item.CategoriaFilter);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">");
#nullable restore
#line 23 "C:\Users\Usuario\Desktop\DSD\DSDTrabajoFinal\AppComunidad\GuiaApp\Views\Negocios\Index.cshtml"
                                                               Write(item.CategoriaNombre);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n");
#nullable restore
#line 24 "C:\Users\Usuario\Desktop\DSD\DSDTrabajoFinal\AppComunidad\GuiaApp\Views\Negocios\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </ul>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
            WriteLiteral("    <div class=\"row featured__filter\">\r\n");
#nullable restore
#line 32 "C:\Users\Usuario\Desktop\DSD\DSDTrabajoFinal\AppComunidad\GuiaApp\Views\Negocios\Index.cshtml"
         foreach (var item in Model.negocios)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div");
            BeginWriteAttribute("class", " class=\"", 948, "\"", 1010, 6);
            WriteAttributeValue("", 956, "col-lg-3", 956, 8, true);
            WriteAttributeValue(" ", 964, "col-md-4", 965, 9, true);
            WriteAttributeValue(" ", 973, "col-sm-6", 974, 9, true);
            WriteAttributeValue(" ", 982, "mix", 983, 4, true);
#nullable restore
#line 34 "C:\Users\Usuario\Desktop\DSD\DSDTrabajoFinal\AppComunidad\GuiaApp\Views\Negocios\Index.cshtml"
WriteAttributeValue(" ", 986, item.Filter, 987, 12, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 999, "fresh-meat", 1000, 11, true);
            EndWriteAttribute();
            WriteLiteral(@">
                <div class=""featured__item"">
                    <div class=""featured__item__pic set-bg"" data-setbg=""../img/Negocios/KaiNikkei.jpeg"">
                        <ul class=""featured__item__pic__hover"">
                            <li><a href=""#""><i class=""fa fa-heart""></i></a></li>
                            <li><a href=""#""><i class=""fa fa-retweet""></i></a></li>
                            <li><a href=""#""><i class=""fa fa-shopping-cart""></i></a></li>
                        </ul>
                    </div>
                    <div class=""featured__item__text"">
                        <h6><a href=""#"">");
#nullable restore
#line 44 "C:\Users\Usuario\Desktop\DSD\DSDTrabajoFinal\AppComunidad\GuiaApp\Views\Negocios\Index.cshtml"
                                   Write(item.Nombre);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></h6>\r\n                        <h5>$30.00</h5>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 49 "C:\Users\Usuario\Desktop\DSD\DSDTrabajoFinal\AppComunidad\GuiaApp\Views\Negocios\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n");
#nullable restore
#line 51 "C:\Users\Usuario\Desktop\DSD\DSDTrabajoFinal\AppComunidad\GuiaApp\Views\Negocios\Index.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<GuiaApp.Models.NegocioIndexModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
