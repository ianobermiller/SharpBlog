using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SharpBlog.Models
{
    public class Post : RavenModel
    {
        public DateTime CreatedAt { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Body { get; set; }
    }
}