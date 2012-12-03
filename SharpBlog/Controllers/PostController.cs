using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SharpBlog.Models;

namespace SharpBlog.Controllers
{
    public class PostController : RavenController
    {
        //
        // GET: /Post/

        public ActionResult Index()
        {
            var posts = RavenSession.Query<Post>().ToList();
            return View(posts);
        }

        //
        // GET: /Post/Details/5

        public ActionResult Details(int id)
        {
            var post = RavenSession.Load<Post>(id);
            return View(post);
        }

        //
        // GET: /Post/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Post/Create

        [HttpPost]
        public ActionResult Create(Post post)
        {
            if (ModelState.IsValid)
            {
                RavenSession.Store(post);
            }

            return View();
        }
    }
}
