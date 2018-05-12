using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DarenTechs.Data.Entities.Article
{
    [Table("Articles")]
    public class Article
    {
        [Key]
        public long Id { get; set; }

        [Display(Description = "Text")]
        [Required(ErrorMessage = "Title required")]
        public string Title { get; set; }

        [Display(Description = "Short Description")]
        public string ShortDescription { get; set; }

        [Display(Description = "Body")]
        [Required(ErrorMessage = "Post text required")]
        public string Body { get; set; }

        public DateTimeOffset DatePublished { get; set; } = DateTimeOffset.Now;

        public DateTimeOffset LastModified { get; set; }

        public bool IsPublic { get; set; }

        public bool IsPublished { get; set; }

        public bool IsDeleted { get; set; }

        public ArticleType ArticleType { get; set; }

        public ICollection<ArticleCategory> Categories { get; set; }

    }
}
