using System.Web.Mvc;
using SharpBlog.Models;

namespace SharpBlog
{
    public static class LinkTo
    {
        public static ActionResult Post(Post post)
        {
            return MVC.Posts.Get(post.CreatedAt.Year, post.CreatedAt.Month, post.CreatedAt.Day, post.Slug);
        }
    }
}