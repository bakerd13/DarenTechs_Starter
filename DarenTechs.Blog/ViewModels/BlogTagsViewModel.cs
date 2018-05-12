using DarenTechs.Data.Data;
using DarenTechs.Data.Entities;
using DarenTechs.Data.Entities.Blog;
using DarenTechs.Data.Interfaces;
using DarenTechs.Data.TreeData;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace DarenTechs.Blog.ViewModels
{
    public class BlogTagsViewModel
    {
        public ICollection<Tag> Tags { get; set; }

        private readonly IRepositoryAsync<Tag> _repository;

        public BlogTagsViewModel(IRepositoryAsync<Tag> repository)
        {
            _repository = repository;
        }

        public async Task<bool> GetTagsAsync()
        {
            Tags = await _repository.GetAllAsync();

            return await Task.FromResult(true);
        }
    }
}
