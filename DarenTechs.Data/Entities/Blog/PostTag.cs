using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DarenTechs.Data.Entities.Blog
{
    [Table("PostTags")]
    public class PostTag
    {
        public long PostId { get; set; }
        public Post Post { get; set; }

        public long TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
