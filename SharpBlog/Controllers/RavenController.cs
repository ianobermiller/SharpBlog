using Raven.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SharpBlog.Controllers
{
    public class RavenController : Controller
    {
        public static IDocumentStore DocumentStore { get; set; }

        public IDocumentSession RavenSession { get; set; }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            RavenSession = (IDocumentSession)HttpContext.Items["CurrentRequestRavenSession"];
        }

        protected HttpStatusCodeResult HttpNotModified()
        {
            return new HttpStatusCodeResult(304);
        }
    }
}
