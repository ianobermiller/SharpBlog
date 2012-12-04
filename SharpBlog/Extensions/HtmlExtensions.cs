using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kiwi.Markdown;

namespace SharpBlog
{
    public static class HtmlExtensions
    {
        public static HtmlString FromMarkdown(this HtmlHelper html, string markdown)
        {
            return new HtmlString(new MarkdownService(null).ToHtml(markdown));
        }
    }
}