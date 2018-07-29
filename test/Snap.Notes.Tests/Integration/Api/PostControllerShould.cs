using Snap.Notes.Api.DTO;
using Snap.Notes.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Snap.Notes.Tests.Integration.Api
{
    public class PostControllerShould : BaseWebControllerSetup<Post>
    {
        [Fact]
        public async Task ListShouldReturnsTwoItems()
        {
            var result = (await GetList("/api/posts")).ToList();

            Assert.Equal(2, result.Count());
            Assert.Equal(1, result.Count(a => a.Content == "Test Item 1"));
            Assert.Equal(1, result.Count(a => a.Content == "Test Item 2"));
        }

        [Fact]
        public async Task GetByIdShouldReturnOneItem()
        {
            var result = (await GetById("/api/posts/1"));

            Assert.NotNull(result);
            Assert.Equal("Test Item 1", result.Content);
        }

        [Fact]
        public async Task PostShouldAddNewItem()
        {
            var dto = new PostDTO()
            {
                Id = 3,
                Content = "Test 3",
                CategoryId = 1,
            };

            await Post($"/api/posts", dto);

            var result = (await GetById($"/api/posts/{dto.Id}"));

            Assert.NotNull(result);
            Assert.Equal("Test 3", result.Content);

        }

        //[Fact]
        //public async Task CompleteShouldMarkItemToBeDone()
        //{
        //    var result = await GetById("/api/posts/1/complete");

        //    Assert.NotNull(result);
        //    Assert.Equal("Test Item 1", result.Title);
        //    Assert.True(result.IsDone);
        //}

        //[Fact]
        //public async Task CompleteByPatchShouldAlsoMarkItemToBeDone()
        //{
        //    var result = await GetById("api/todoitems/1");
            
        //    var response = await Patch("/api/todoitems/complete", result);

        //    Assert.Equal(response.Id, result.Id);
        //    Assert.Equal(response.Title, result.Title);
        //    Assert.True(response.IsDone);
        //}
    }
}
