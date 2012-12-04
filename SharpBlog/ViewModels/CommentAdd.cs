using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SharpBlog.ViewModels
{
    public class CommentAdd
    {
        [HiddenInput]
        public string PostDocumentId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Email { get; set; }

        [Url]
        public string Url { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Body { get; set; }

        [Url]
        public string ReturnUrl { get; set; }
    }
}