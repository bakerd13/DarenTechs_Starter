using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DarenTechs.Data.Data;
using DarenTechs.Data.Entities.Blog;
using DarenTechs.Data.Interfaces;
using DarenTechs.Blog.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DarenTechs.Web.Controllers
{
    public class BlogController : Controller
    {

        private IRepository<Post> _repository;

        public BlogController(IRepository<Post> repository)
        {
            _repository = repository;
        }

        // GET: Blog
        public ActionResult Index()
        {
            var post = new BlogViewModel(_repository.GetAll().OrderByDescending(o => o).FirstOrDefault());

            return View(post);
        }

        [Route("Blog/Navigation/{id:long}")]
        public ActionResult Navigation(long id)
        {
            var post = new BlogViewModel(_repository.GetById(id));

            return View("Index",post);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddComment(BlogCommentViewModel blogcomment)
        {
            if (ModelState.IsValid)
            {
                var comments = new List<Comment>();

                var comment = new Comment
                {
                    Body = blogcomment.Body
                };

                comments.Add(comment);

                var post = new Post
                {
                    Id = blogcomment.PostId,
                    Comments = comments
                };

                _repository.Update(post);
                return View("Index", post);
            }

            return View("Index");
        }

       
    }
}
