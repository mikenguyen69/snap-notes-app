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
    public class TagControllerShould : BaseWebControllerSetup<Tag>
    {
        [Fact]
        public async Task ListShouldReturnsTwoItems()
        {
            var result = (await GetList("/api/tags")).ToList();

            Assert.Equal(2, result.Count());
            Assert.Equal(1, result.Count(a => a.Name == "Test Item 1"));
            Assert.Equal(1, result.Count(a => a.Name == "Test Item 2"));
        }

        [Fact]
        public async Task GetByIdShouldReturnOneItem()
        {
            var result = (await GetById("/api/tags/1"));

            Assert.NotNull(result);
            Assert.Equal("Test Item 1", result.Name);
        }

        [Fact]
        public async Task PostShouldAddNewItem()
        {
            var dto = new TagDTO()
            {
                Id = 3,
                Name = "Test 3",
            };

            await Post($"/api/tags", dto);

            var result = (await GetById($"/api/tags/{dto.Id}"));

            Assert.NotNull(result);
            Assert.Equal("Test 3", result.Name);

        }

        //[Fact]
        //public async Task CompleteShouldMarkItemToBeDone()
        //{
        //    var result = await GetById("/api/tags/1/complete");

        //    Assert.NotNull(result);
        //    Assert.Equal("Test Item 1", result.Name);
        //    Assert.True(result.IsDone);
        //}

        //[Fact]
        //public async Task CompleteByPatchShouldAlsoMarkItemToBeDone()
        //{
        //    var result = await GetById("api/todoitems/1");
            
        //    var response = await Patch("/api/todoitems/complete", result);

        //    Assert.Equal(response.Id, result.Id);
        //    Assert.Equal(response.Name, result.Name);
        //    Assert.True(response.IsDone);
        //}
    }
}
