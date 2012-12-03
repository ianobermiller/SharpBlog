using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SharpBlog.Models
{
    public class Post
    {
        public DateTime DatePublished { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}