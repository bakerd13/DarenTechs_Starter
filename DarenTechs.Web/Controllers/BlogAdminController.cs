using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DarenTechs.Data.Data;
using DarenTechs.Data.Entities.Blog;
using DarenTechs.Data.Interfaces;
using DarenTechs.UI.Components.Modal;
using DarenTechs.Blog.ViewModels;
using DarenTechs.Web.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DarenTechs.Web.Controllers
{
    public class BlogAdminController : Controller
    {
        private IBlogService _service;

        public BlogAdminController(IBlogService service)
        {
            _service = service;
        }

        public ActionResult Index() => View(_service.GetLatestBlog());

        [HttpGet]
        public ActionResult BlogPagedPublishedList(int page, int pageSize, bool isPublished) 
            => PartialView("_BlogAdminPosts", _service.BlogPagedPublishedList(page, pageSize, isPublished));


        // GET: BlogAdmin/Create
        [HttpGet]
        public ActionResult Designer()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddParagraph([ModelBinder(BinderType = typeof(BootstrapModalBinder))] BootstrapModal bootstrapmodal) 
            => PartialView("_ParagraphModal", bootstrapmodal);
        
    }
}
