using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DarenTechs.Data.Entities.Blog
{
    [Table("Tags")]
    public class Tag : BaseEntity
    {
        public string Name { get; set; }

        public string Slug { get; set; }

        public string Description { get; set; }

        public ICollection<PostTag> PostTags { get; set; } = new List<PostTag>();

    }
}
