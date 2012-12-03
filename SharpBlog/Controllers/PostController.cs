using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SharpBlog.Controllers
{
    public class PostController : RavenController
    {
        //
        // GET: /Post/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Post/Details/5

        public ActionResult Details(int id)
        {
            return View();
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
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
