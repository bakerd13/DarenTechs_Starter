using DarenTechs.Data.Entities.Blog;
using DarenTechs.Data.Interfaces;
using DarenTechs.Blog.ViewModels;
using DarenTechs.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DarenTechsPlayArea.Tests.ControllerTests
{
    public class BlogControllerTest
    {

        [Fact]
        public void Index_ReturnsAViewResult_WithTheLatestPost()
        {
            // Arrange
            var mockRepo = new Mock<IRepository<Post>>();
            mockRepo.Setup(repo => repo.GetAll()).Returns(GetTestPosts());
            var controller = new BlogController(mockRepo.Object);

            // Act
            var result = controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<BlogViewModel>>(
                viewResult.ViewData.Model);
            Assert.Single(model);
        }

        private ICollection<Post> GetTestPosts()
        {
            var posts = new List<Post>
            {
                new Post
                {
                    Title = "Single Post",
                    AuthorName = "Daren",
                    ShortDescription = "A Short Description",
                    Body = "<b>body</b>",
                    Slug = "/slug/abc-abc",
                    DatePublished = new DateTime(2018, 05, 01),
                    IsDeleted = false,
                    IsPublished = false,
                    IsPublic = true
                }
            };

            return posts;
        }
    }
}
