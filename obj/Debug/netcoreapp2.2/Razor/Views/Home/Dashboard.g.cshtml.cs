#pragma checksum "/Users/kushalgurung/Desktop/ProjectX/C#/belt_prep/test/belt/Views/Home/Dashboard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f9d1b7705e4d3cd0fd63a6c0c7942795bb87a122"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Dashboard), @"mvc.1.0.view", @"/Views/Home/Dashboard.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Dashboard.cshtml", typeof(AspNetCore.Views_Home_Dashboard))]
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
#line 1 "/Users/kushalgurung/Desktop/ProjectX/C#/belt_prep/test/belt/Views/_ViewImports.cshtml"
using belt;

#line default
#line hidden
#line 2 "/Users/kushalgurung/Desktop/ProjectX/C#/belt_prep/test/belt/Views/_ViewImports.cshtml"
using belt.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f9d1b7705e4d3cd0fd63a6c0c7942795bb87a122", @"/Views/Home/Dashboard.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9b81c1a527ba141949545bc68b686b4250f1080a", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Dashboard : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 632, true);
            WriteLiteral(@"
<p class=""h2 mb-5"">
    <span >
        Dashboard
    </span>
    <span  >
       <a href=""newProduct"" class=""ml-2"">Products</a> 
    </span>
    <span >
       <a href=""newOrder"" class=""ml-2"">Orders</a> 
    </span>
    <span >
       <a href=""newCustomer"" class=""ml-2"">Customers</a> 
    </span>
    <span >
       <a href=""#"" class=""ml-2"">Settings</a> 
    </span>
    <span class=""float-right"">
        <a href=""logout"" class=""h4 ml-5"">Logout</a>
    </span>
</p>

<div class=""row"">
    <div class=""col-2"">
        <input type=""text"" name=""search"">
        <input type=""submit"" value=""Filter"">
    </div>
    <div class=""col"">
");
            EndContext();
#line 29 "/Users/kushalgurung/Desktop/ProjectX/C#/belt_prep/test/belt/Views/Home/Dashboard.cshtml"
         foreach(Product one in ViewBag.someProducts)
        { 

#line default
#line hidden
            BeginContext(697, 106, true);
            WriteLiteral("        <div class=\"d-inline-block\">\n            <div class=\"card\" style=\"width: 12rem;\">\n            <img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 803, "\"", 820, 1);
#line 33 "/Users/kushalgurung/Desktop/ProjectX/C#/belt_prep/test/belt/Views/Home/Dashboard.cshtml"
WriteAttributeValue("", 809, one.ImgUrl, 809, 11, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(821, 108, true);
            WriteLiteral(" class=\"card-img-top\" alt=\"...\">\n            <div class=\"card-body\">\n                <h5 class=\"card-title\">");
            EndContext();
            BeginContext(930, 8, false);
#line 35 "/Users/kushalgurung/Desktop/ProjectX/C#/belt_prep/test/belt/Views/Home/Dashboard.cshtml"
                                  Write(one.Name);

#line default
#line hidden
            EndContext();
            BeginContext(938, 44, true);
            WriteLiteral("</h5>\n                <p class=\"card-text\">(");
            EndContext();
            BeginContext(983, 13, false);
#line 36 "/Users/kushalgurung/Desktop/ProjectX/C#/belt_prep/test/belt/Views/Home/Dashboard.cshtml"
                                 Write(one.Inventory);

#line default
#line hidden
            EndContext();
            BeginContext(996, 65, true);
            WriteLiteral(" left)</p>\n            </div>\n            </div>\n\n        </div>\n");
            EndContext();
#line 41 "/Users/kushalgurung/Desktop/ProjectX/C#/belt_prep/test/belt/Views/Home/Dashboard.cshtml"
        }

#line default
#line hidden
            BeginContext(1071, 72, true);
            WriteLiteral("\n        <div class=\"mt-5\">\n            <p class=\"h3\">Recent Orders</p>\n");
            EndContext();
#line 45 "/Users/kushalgurung/Desktop/ProjectX/C#/belt_prep/test/belt/Views/Home/Dashboard.cshtml"
             foreach(Order two in ViewBag.someOrders)
            {

#line default
#line hidden
            BeginContext(1211, 32, true);
            WriteLiteral("                <p class=\"ml-3\">");
            EndContext();
            BeginContext(1244, 17, false);
#line 47 "/Users/kushalgurung/Desktop/ProjectX/C#/belt_prep/test/belt/Views/Home/Dashboard.cshtml"
                           Write(two.Customer.Name);

#line default
#line hidden
            EndContext();
            BeginContext(1261, 11, true);
            WriteLiteral(" purchased ");
            EndContext();
            BeginContext(1273, 12, false);
#line 47 "/Users/kushalgurung/Desktop/ProjectX/C#/belt_prep/test/belt/Views/Home/Dashboard.cshtml"
                                                        Write(two.Quantity);

#line default
#line hidden
            EndContext();
            BeginContext(1285, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(1287, 16, false);
#line 47 "/Users/kushalgurung/Desktop/ProjectX/C#/belt_prep/test/belt/Views/Home/Dashboard.cshtml"
                                                                      Write(two.Product.Name);

#line default
#line hidden
            EndContext();
            BeginContext(1303, 5, true);
            WriteLiteral("</p>\n");
            EndContext();
#line 48 "/Users/kushalgurung/Desktop/ProjectX/C#/belt_prep/test/belt/Views/Home/Dashboard.cshtml"
            }

#line default
#line hidden
            BeginContext(1322, 87, true);
            WriteLiteral("        </div>\n\n        <div class=\"mt-5\">\n            <p class=\"h3\">New Customers</p>\n");
            EndContext();
#line 53 "/Users/kushalgurung/Desktop/ProjectX/C#/belt_prep/test/belt/Views/Home/Dashboard.cshtml"
             foreach(Customer three in ViewBag.someCustomers)
            {

#line default
#line hidden
            BeginContext(1485, 32, true);
            WriteLiteral("                <p class=\"ml-3\">");
            EndContext();
            BeginContext(1518, 10, false);
#line 55 "/Users/kushalgurung/Desktop/ProjectX/C#/belt_prep/test/belt/Views/Home/Dashboard.cshtml"
                           Write(three.Name);

#line default
#line hidden
            EndContext();
            BeginContext(1528, 22, true);
            WriteLiteral(" joined the store</p>\n");
            EndContext();
#line 56 "/Users/kushalgurung/Desktop/ProjectX/C#/belt_prep/test/belt/Views/Home/Dashboard.cshtml"
            }

#line default
#line hidden
            BeginContext(1564, 35, true);
            WriteLiteral("        </div>\n\n\n    </div>\n\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
