#pragma checksum "C:\Users\ahmet\Desktop\Projem\0-files\CoreDemo\CoreDemo\Views\Blog\BlogListByWriter.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "da0733afae1dc55494733c911397845c16708d8e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Blog_BlogListByWriter), @"mvc.1.0.view", @"/Views/Blog/BlogListByWriter.cshtml")]
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
#line 1 "C:\Users\ahmet\Desktop\Projem\0-files\CoreDemo\CoreDemo\Views\_ViewImports.cshtml"
using CoreDemo;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ahmet\Desktop\Projem\0-files\CoreDemo\CoreDemo\Views\_ViewImports.cshtml"
using CoreDemo.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\ahmet\Desktop\Projem\0-files\CoreDemo\CoreDemo\Views\Blog\BlogListByWriter.cshtml"
using EntityLayer.Concrete;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"da0733afae1dc55494733c911397845c16708d8e", @"/Views/Blog/BlogListByWriter.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c0e2cbebe4b7cca4b09168dd159f601192fafdf0", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Blog_BlogListByWriter : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Blog>>
    #nullable disable
    {
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\ahmet\Desktop\Projem\0-files\CoreDemo\CoreDemo\Views\Blog\BlogListByWriter.cshtml"
  
    ViewData["Title"] = "BlogListByWriter";
    Layout = "~/Views/Shared/WriterLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("<!DOCTYPE html>\r\n<html lang=\"en\">\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "da0733afae1dc55494733c911397845c16708d8e3688", async() => {
                WriteLiteral(@"
            <div class=""row"">
                <div class=""col-lg-12 grid-margin stretch-card"">
                    <div class=""card"">
                        <div class=""card-body"">
                            <h1 class=""card-title"">Yazarın Blogları</h1>
                            <br />
                            <table class=""table table-hover"">
                                <thead>
                                    <tr>
                                        <th>#</th>
                                        <th>Blog Başlığı</th>
                                        <th>Oluşturma Tarihi</th>
                                        <th>Kategori</th>
                                        <th>Durum</th>
                                        <th>Sil</th>
                                        <th>Düzenle</th>
                                    </tr>
                                </thead>
                                <tbody>
");
#nullable restore
#line 30 "C:\Users\ahmet\Desktop\Projem\0-files\CoreDemo\CoreDemo\Views\Blog\BlogListByWriter.cshtml"
                                         foreach (var item in Model)
                                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                        <tr>\r\n                                            <th>");
#nullable restore
#line 33 "C:\Users\ahmet\Desktop\Projem\0-files\CoreDemo\CoreDemo\Views\Blog\BlogListByWriter.cshtml"
                                           Write(item.BlogID);

#line default
#line hidden
#nullable disable
                WriteLiteral("</th>\r\n                                            <td>");
#nullable restore
#line 34 "C:\Users\ahmet\Desktop\Projem\0-files\CoreDemo\CoreDemo\Views\Blog\BlogListByWriter.cshtml"
                                           Write(item.BlogTitle);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                            <td> ");
#nullable restore
#line 35 "C:\Users\ahmet\Desktop\Projem\0-files\CoreDemo\CoreDemo\Views\Blog\BlogListByWriter.cshtml"
                                             Write(((DateTime)item.BlogCreateDate).ToString("dd-MMM-yyyy"));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                            <td>");
#nullable restore
#line 36 "C:\Users\ahmet\Desktop\Projem\0-files\CoreDemo\CoreDemo\Views\Blog\BlogListByWriter.cshtml"
                                           Write(item.Category.CategoryName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                            <td>");
#nullable restore
#line 37 "C:\Users\ahmet\Desktop\Projem\0-files\CoreDemo\CoreDemo\Views\Blog\BlogListByWriter.cshtml"
                                           Write(item.BlogStatus);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                            <td><a");
                BeginWriteAttribute("href", " href=\"", 1787, "\"", 1823, 2);
                WriteAttributeValue("", 1794, "/Blog/DeleteBlog/", 1794, 17, true);
#nullable restore
#line 38 "C:\Users\ahmet\Desktop\Projem\0-files\CoreDemo\CoreDemo\Views\Blog\BlogListByWriter.cshtml"
WriteAttributeValue("", 1811, item.BlogID, 1811, 12, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"btn btn-danger\">Sil</a></td>\r\n                                            <td><a");
                BeginWriteAttribute("href", " href=\"", 1912, "\"", 1946, 2);
                WriteAttributeValue("", 1919, "/Blog/EditBlog/", 1919, 15, true);
#nullable restore
#line 39 "C:\Users\ahmet\Desktop\Projem\0-files\CoreDemo\CoreDemo\Views\Blog\BlogListByWriter.cshtml"
WriteAttributeValue("", 1934, item.BlogID, 1934, 12, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"btn btn-warning\">Düzenle</a></td>\r\n                                        </tr>\r\n");
#nullable restore
#line 41 "C:\Users\ahmet\Desktop\Projem\0-files\CoreDemo\CoreDemo\Views\Blog\BlogListByWriter.cshtml"
                                        }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                                </tbody>
                            </table>
                            <a href=""/Blog/BlogAdd/"" class=""btn btn-primary"">Yeni Blog Oluştur</a>
                        </div>
                    </div>
                </div>

            </div>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>\r\n\r\n\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Blog>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
