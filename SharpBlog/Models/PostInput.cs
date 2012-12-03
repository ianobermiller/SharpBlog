using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SharpBlog.Models
{
    public class PostInput
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [AllowHtml]
        [Required]
        [DataType(DataType.MultilineText)]
        public string Body { get; set; }

        [Display(Name = "Created At")]
        [DataType(DataType.DateTime)]
        public DateTimeOffset CreatedAt { get; set; }

        public bool IsNewPost()
        {
            return Id == 0;
        }
    }
}