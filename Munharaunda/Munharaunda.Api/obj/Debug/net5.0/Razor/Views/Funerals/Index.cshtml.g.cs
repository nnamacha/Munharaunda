#pragma checksum "C:\Users\NB181916\source\repos\munharaunda\Munharaunda\Munharaunda.Api\Views\Funerals\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "abe73996910609dff452a1ceed9f76e537d215e4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Funerals_Index), @"mvc.1.0.view", @"/Views/Funerals/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"abe73996910609dff452a1ceed9f76e537d215e4", @"/Views/Funerals/Index.cshtml")]
    public class Views_Funerals_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Munharaunda.Domain.Models.Funeral>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\NB181916\source\repos\munharaunda\Munharaunda\Munharaunda.Api\Views\Funerals\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Index</h1>\r\n\r\n<p>\r\n    <a asp-action=\"Create\">Create New</a>\r\n</p>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 16 "C:\Users\NB181916\source\repos\munharaunda\Munharaunda\Munharaunda.Api\Views\Funerals\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.DeceasedsProfileNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 19 "C:\Users\NB181916\source\repos\munharaunda\Munharaunda\Munharaunda.Api\Views\Funerals\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.AddressForFuneral));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 22 "C:\Users\NB181916\source\repos\munharaunda\Munharaunda\Munharaunda.Api\Views\Funerals\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.StatusId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 25 "C:\Users\NB181916\source\repos\munharaunda\Munharaunda\Munharaunda.Api\Views\Funerals\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Comment));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 28 "C:\Users\NB181916\source\repos\munharaunda\Munharaunda\Munharaunda.Api\Views\Funerals\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Created));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 31 "C:\Users\NB181916\source\repos\munharaunda\Munharaunda\Munharaunda.Api\Views\Funerals\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.CreatedBy));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 34 "C:\Users\NB181916\source\repos\munharaunda\Munharaunda\Munharaunda.Api\Views\Funerals\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Updated));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 37 "C:\Users\NB181916\source\repos\munharaunda\Munharaunda\Munharaunda.Api\Views\Funerals\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.UpdatedBy));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 43 "C:\Users\NB181916\source\repos\munharaunda\Munharaunda\Munharaunda.Api\Views\Funerals\Index.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 46 "C:\Users\NB181916\source\repos\munharaunda\Munharaunda\Munharaunda.Api\Views\Funerals\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.DeceasedsProfileNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 49 "C:\Users\NB181916\source\repos\munharaunda\Munharaunda\Munharaunda.Api\Views\Funerals\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.AddressForFuneral));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 52 "C:\Users\NB181916\source\repos\munharaunda\Munharaunda\Munharaunda.Api\Views\Funerals\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.StatusId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 55 "C:\Users\NB181916\source\repos\munharaunda\Munharaunda\Munharaunda.Api\Views\Funerals\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Comment));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 58 "C:\Users\NB181916\source\repos\munharaunda\Munharaunda\Munharaunda.Api\Views\Funerals\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Created));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 61 "C:\Users\NB181916\source\repos\munharaunda\Munharaunda\Munharaunda.Api\Views\Funerals\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.CreatedBy));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 64 "C:\Users\NB181916\source\repos\munharaunda\Munharaunda\Munharaunda.Api\Views\Funerals\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Updated));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 67 "C:\Users\NB181916\source\repos\munharaunda\Munharaunda\Munharaunda.Api\Views\Funerals\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.UpdatedBy));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                <a asp-action=\"Edit\"");
            BeginWriteAttribute("asp-route-id", " asp-route-id=\"", 2023, "\"", 2053, 1);
#nullable restore
#line 70 "C:\Users\NB181916\source\repos\munharaunda\Munharaunda\Munharaunda.Api\Views\Funerals\Index.cshtml"
WriteAttributeValue("", 2038, item.FuneralId, 2038, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Edit</a> |\r\n                <a asp-action=\"Details\"");
            BeginWriteAttribute("asp-route-id", " asp-route-id=\"", 2106, "\"", 2136, 1);
#nullable restore
#line 71 "C:\Users\NB181916\source\repos\munharaunda\Munharaunda\Munharaunda.Api\Views\Funerals\Index.cshtml"
WriteAttributeValue("", 2121, item.FuneralId, 2121, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Details</a> |\r\n                <a asp-action=\"Delete\"");
            BeginWriteAttribute("asp-route-id", " asp-route-id=\"", 2191, "\"", 2221, 1);
#nullable restore
#line 72 "C:\Users\NB181916\source\repos\munharaunda\Munharaunda\Munharaunda.Api\Views\Funerals\Index.cshtml"
WriteAttributeValue("", 2206, item.FuneralId, 2206, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Delete</a>\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 75 "C:\Users\NB181916\source\repos\munharaunda\Munharaunda\Munharaunda.Api\Views\Funerals\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Munharaunda.Domain.Models.Funeral>> Html { get; private set; }
    }
}
#pragma warning restore 1591