using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SharpBlog.ViewModels
{
    public class PostAdd
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Slug { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Body { get; set; }

        public bool IsNewPost()
        {
            return Id == 0;
        }
    }
}