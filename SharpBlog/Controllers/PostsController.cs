using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Raven.Abstractions.Data;
using Raven.Json.Linq;
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

        public virtual ActionResult Get(int year, int month, int day, string slug)
        {
            var post = RavenSession.Query<Post>().Where(p => p.Slug.Equals(slug, StringComparison.InvariantCultureIgnoreCase)).SingleOrDefault();
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
                return RedirectToAction(LinkTo.Post(post));
            }

            return View();
        }

        [HttpPost]
        public virtual ActionResult Comment(CommentAdd commentAdd)
        {
            if (ModelState.IsValid)
            {
                var comment = new Comment();
                Mapper.Map(commentAdd, comment);
                comment.CreatedAt = DateTime.UtcNow;
                RavenSession.Advanced.DocumentStore.DatabaseCommands.Patch(
                    commentAdd.PostDocumentId,
                    new[] {
                        new PatchRequest {
                            Type = PatchCommandType.Add,
                            Name = Reflect.GetName<Post>(p => p.Comments),
                            Value = RavenJObject.FromObject(comment)
                        }
                    });
                return RedirectToAction(commentAdd.ReturnUrl);
            }

            return View();
        }
    }
}
