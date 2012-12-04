using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SharpBlog.Models
{
    public class RavenModel
    {
        public string DocumentId { get; set; }

        public int Id
        {
            get
            {
                return int.Parse(DocumentId.Split('/').LastOrDefault());
            }
        }
    }
}