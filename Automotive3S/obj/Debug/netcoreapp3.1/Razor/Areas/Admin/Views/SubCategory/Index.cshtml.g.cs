#pragma checksum "F:\codeoffyp\Prroject\Automotive3S\Automotive3S\Areas\Admin\Views\SubCategory\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2d09ffda20a6dca41bfe8fa5233edcaeeba45348"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_SubCategory_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/SubCategory/Index.cshtml")]
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
#line 1 "F:\codeoffyp\Prroject\Automotive3S\Automotive3S\Areas\Admin\Views\_ViewImports.cshtml"
using Automotive3S;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\codeoffyp\Prroject\Automotive3S\Automotive3S\Areas\Admin\Views\_ViewImports.cshtml"
using Automotive3S.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "F:\codeoffyp\Prroject\Automotive3S\Automotive3S\Areas\Admin\Views\_ViewImports.cshtml"
using Automotive3S.Models.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2d09ffda20a6dca41bfe8fa5233edcaeeba45348", @"/Areas/Admin/Views/SubCategory/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b490533e6cf5207f0c3bc43cca45d3cba6c3b073", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_SubCategory_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Automotive3S.Models.SubCategory>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Upsert", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-info"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "F:\codeoffyp\Prroject\Automotive3S\Automotive3S\Areas\Admin\Views\SubCategory\Index.cshtml"
   ViewData["Title"] = "SubCategory";
    Layout = "~/Views/Shared/_AdminLTE.cshtml";


#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<br />\r\n<br />\r\n\r\n<div class=\"row\">\r\n    <div class=\"col-6\">\r\n        <h2 class=\"text-info\">Sub Categories</h2>\r\n    </div>\r\n    <div class=\"col-6 text-right\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2d09ffda20a6dca41bfe8fa5233edcaeeba453484562", async() => {
                WriteLiteral("<i class=\"fas fa-plus\"></i>&nbsp; New Sub Category");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n</div>\r\n\r\n<br />\r\n<div>\r\n    <table class=\"table table-striped border\">\r\n        <tr class=\"table-info\">\r\n            <th>\r\n                ");
#nullable restore
#line 25 "F:\codeoffyp\Prroject\Automotive3S\Automotive3S\Areas\Admin\Views\SubCategory\Index.cshtml"
           Write(Html.DisplayNameFor(m => m.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 28 "F:\codeoffyp\Prroject\Automotive3S\Automotive3S\Areas\Admin\Views\SubCategory\Index.cshtml"
           Write(Html.DisplayNameFor(m => m.Category.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n\r\n");
#nullable restore
#line 33 "F:\codeoffyp\Prroject\Automotive3S\Automotive3S\Areas\Admin\Views\SubCategory\Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 37 "F:\codeoffyp\Prroject\Automotive3S\Automotive3S\Areas\Admin\Views\SubCategory\Index.cshtml"
               Write(Html.DisplayFor(m => item.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 40 "F:\codeoffyp\Prroject\Automotive3S\Automotive3S\Areas\Admin\Views\SubCategory\Index.cshtml"
               Write(Html.DisplayFor(m => item.Category.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n\r\n                <td>\r\n                    <div class=\"text-center\">\r\n                        <a");
            BeginWriteAttribute("href", " href=\"", 1133, "\"", 1171, 2);
            WriteAttributeValue("", 1140, "/Admin/Category/Upsert/", 1140, 23, true);
#nullable restore
#line 45 "F:\codeoffyp\Prroject\Automotive3S\Automotive3S\Areas\Admin\Views\SubCategory\Index.cshtml"
WriteAttributeValue("", 1163, item.Id, 1163, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""btn btn-success text-white""
                           style=""cursor:pointer"">
                            <i class=""fas fa-edit""></i>
                        </a>
                        &nbsp;
                        <button onclick=Delete(""/Admin/Category/Delete/");
#nullable restore
#line 50 "F:\codeoffyp\Prroject\Automotive3S\Automotive3S\Areas\Admin\Views\SubCategory\Index.cshtml"
                                                                  Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral(@""")
                                class=""btn btn-danger text-white"" style=""cursor:pointer"">
                            <i class=""fas fa-trash-alt""></i>
                        </button>
                    </div>
                </td>

            </tr>
");
#nullable restore
#line 58 "F:\codeoffyp\Prroject\Automotive3S\Automotive3S\Areas\Admin\Views\SubCategory\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </table>\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"

    <script>
function Delete(url) {
            $.ajax({
                type: 'DELETE',
                url: url,
                success: function (data) {
                    location.reload();
                }
            });
        }</script>

");
            }
            );
            WriteLiteral("\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Automotive3S.Models.SubCategory>> Html { get; private set; }
    }
}
#pragma warning restore 1591
