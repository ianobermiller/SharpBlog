using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using SharpBlog.Models;
using SharpBlog.ViewModels;

namespace SharpBlog.Controllers
{
    public partial class PostsController : RavenController
    {
        public virtual ActionResult Index()
        {
            var posts = RavenSession.Query<Post>().ToList();
            return View(posts);
        }

        public virtual ActionResult Get(int year, int month, int day, int id)
        {
            var post = RavenSession.Load<Post>(id);
            return View(post);
        }

        public virtual ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public virtual ActionResult Add(PostAdd postAdd)
        {
            if (ModelState.IsValid)
            {
                var post = new Post();
                Mapper.Map(postAdd, post);
                post.CreatedAt = DateTime.UtcNow;
                RavenSession.Store(post);
                return RedirectToAction(MVC.Posts.Get(post.CreatedAt.Year, post.CreatedAt.Month, post.CreatedAt.Day, post.Id));
            }

            return View();
        }
    }
}
