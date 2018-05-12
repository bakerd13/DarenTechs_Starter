using System;
using System.Collections.Generic;
using System.Text;

namespace DarenTechs.Blog.ViewModels
{
    public class BlogCommentViewModel
    {
        public long PostId { get; set; }

        public string AuthorName { get; set; }

        public string Body { get; set; }

    }
}
