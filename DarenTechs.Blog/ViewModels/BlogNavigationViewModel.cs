using DarenTechs.Data.Interfaces;
using DarenTechs.Data.Entities.Blog;
using DarenTechs.Data.TreeData;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace DarenTechs.Blog.ViewModels
{
    public class BlogNavigationViewModel
    {
        public Tree TreeStructure { get; set; }

        private readonly IRepositoryAsync<Post> _repository;

        public BlogNavigationViewModel(IRepositoryAsync<Post> repository)
        {
            _repository = repository;
        }

        public async Task<bool> PopulateTree()
        {
            var posts = await GetNavigationPostsAsync();

            var postNavTree = new List<Posts>();
            var navPosts = GenerateCoreNodes(posts);

            postNavTree.AddRange(navPosts);

            var postEntities = posts.Select(s => new Posts() {
                Key = s.Id.ToString(),
                Title = s.Title,
                ParentId = string.Format("{0}{1}", s.DatePublished.Year.ToString(), s.DatePublished.Month.ToString()),
                Url = "/Blog/Navigation/" + s.Id.ToString()
            });

            postNavTree.AddRange(postEntities);

            TreeStructure = new TreeNodes<Posts>().GenerateTreeNodes(postNavTree);

            return await Task.FromResult(true);
        }

        private async Task<ICollection<Post>> GetNavigationPostsAsync()
        {
            return await _repository.GetAllAsync();
        }

        private IList<Posts> GenerateCoreNodes(ICollection<Post> posts)
        {
            var navPosts = new List<Posts>();

            var rootGuid = Guid.NewGuid();

            var root = new Posts
            {
                Key = rootGuid.ToString(),
                Title = "Root",
                ParentId = string.Empty
            };
            navPosts.Add(root);

            var yearPosts = posts.GroupBy(g => new { g.DatePublished.Year }).Select(s => s.Key.Year).OrderByDescending(o => o);

            foreach (var year in yearPosts)
            {
                var guid = Guid.NewGuid();

                var yearModel = new Posts
                {
                    Key = guid.ToString(),
                    Title = year.ToString(),
                    ParentId = rootGuid.ToString()
                };

                navPosts.Add(yearModel);

                var genMon = GenerateMonthNodes(posts, guid, year);

                navPosts.AddRange(genMon);
            }

            return navPosts;
        }

        private IList<Posts> GenerateMonthNodes(ICollection<Post> posts, Guid guid, int year)
        {
            var navPosts = new List<Posts>();
            var monthPosts = posts.Where(w => w.DatePublished.Year == year).GroupBy(g => new { g.DatePublished.Month }).Select(s => s.Key.Month).OrderByDescending(o => o);

            foreach (var month in monthPosts)
            {
                var test = new Posts
                {
                    Key = string.Format("{0}{1}", year.ToString(), month),
                    Title = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month),
                    ParentId = guid.ToString()
                };

                navPosts.Add(test);
            }

            return navPosts;
        }
    }
}
