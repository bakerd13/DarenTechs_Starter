using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DarenTechs.Data.Entities.Blog
{
    [Table("Comments")]
    public class Comment : BaseEntity
    {
        public Post Post { get; set; }

        [Required(ErrorMessage = "Name required")]
        public string AuthorName { get; set; }

        [Required(ErrorMessage = "Comment text required")]
        public string Body { get; set; }

        public DateTimeOffset DatePublished { get; set; } = DateTimeOffset.Now;

        public bool IsPublic { get; set; }

        public ICollection<Comment> Replies { get; set; }

    }
}
