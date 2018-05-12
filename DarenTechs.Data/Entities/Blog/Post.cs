using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DarenTechs.Data.Entities.Blog
{
    [Table("Posts")]
    public class Post : BaseEntity
    {

        [Display(Description = "Text")]
        [Required(ErrorMessage = "Title required")]
        public string Title { get; set; }

        [Display(Description = "Short Description")]
        public string ShortDescription { get; set; }

        [Display(Description = "Body")]
        [Required(ErrorMessage = "Post text required")]
        public string Body { get; set; }

        public string Slug { get; set; }

        // Need to change this for logon user
        public string AuthorName { get; set; }

        public DateTimeOffset DatePublished { get; set; } = DateTimeOffset.Now;

        public DateTimeOffset LastModified { get; set; }

        public bool IsPublic { get; set; }

        public bool IsPublished { get; set; }

        public bool IsDeleted { get; set; }

        public ICollection<Category> Categories { get; set; }

        public ICollection<Comment> Comments { get; set; } = new List<Comment>();

        public ICollection<PostTag> PostTags { get; set; } = new List<PostTag>();
    }
}
