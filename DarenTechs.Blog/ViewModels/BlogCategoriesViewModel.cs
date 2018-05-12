using DarenTechs.Data.Entities.Blog;
using DarenTechs.Data.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DarenTechs.Blog.ViewModels
{
    public class BlogCategoriesViewModel
    {
        public ICollection<Category> Categories { get; set; }

        private readonly IRepositoryAsync<Category> _repository;

        public BlogCategoriesViewModel(IRepositoryAsync<Category> repository)
        {
            _repository = repository;
        }

        public async Task<bool> GetCategoriesAsync()
        {
            Categories = await _repository.GetAllAsync();

            return await Task.FromResult(true);
        }
    }
}
