using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SharpBlog.Models;

namespace SharpBlog.Controllers
{
    public partial class PostsController : RavenController
    {
        public virtual ActionResult Index()
        {
            var posts = RavenSession.Query<Post>().ToList();
            return View(posts);
        }

        public virtual ActionResult Get(string id)
        {
            var post = RavenSession.Load<Post>(id);
            return View(post);
        }

        public virtual ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public virtual ActionResult Add(Post post)
        {
            if (ModelState.IsValid)
            {
                RavenSession.Store(post);
            }

            return View(MVC.Post.Get(post.Id));
        }
    }
}
