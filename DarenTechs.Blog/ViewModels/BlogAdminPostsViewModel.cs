using DarenTechs.Data.Entities;
using DarenTechs.Data.Entities.Blog;
using DarenTechs.Data.Interfaces;
using DarenTechs.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DarenTechs.Blog.ViewModels
{
    public class BlogAdminPostsViewModel : BaseEntity
    {
        public bool IsPublished { get; set; }

        public int TotalPages { get; private set; }

        public int PageSize { get; set; } = 5;

        public string Action { get; set; }

        private readonly IRepositoryAsync<Post> _repository;

        public BlogAdminPostsViewModel(IRepositoryAsync<Post> repository)
        {
            _repository = repository;
        }

        public async Task<bool> GetPostsAsync()
        {
            var posts = await _repository.GetAllAsync();
            var count = posts.Where(p => p.IsPublished == IsPublished).Count();
            TotalPages = PageCalculator.TotalPages(count, PageSize);

            return await Task.FromResult(true);
        }
    }
}
