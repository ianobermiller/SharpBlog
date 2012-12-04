using System.Web;
using System.Web.Mvc;
using Kiwi.Markdown;
using SharpBlog.Models;

namespace SharpBlog
{
    public static class HtmlExtensions
    {
        public static HtmlString FromMarkdown(this HtmlHelper html, string markdown)
        {
            return new HtmlString(new MarkdownService(null).ToHtml(markdown));
        }

        public static HtmlString PostLink(this HtmlHelper html, Post post, string linkText = null)
        {
            linkText = linkText ?? post.Title;
            return html.ActionLink(linkText, LinkTo.Post(post));
        }
    }
}