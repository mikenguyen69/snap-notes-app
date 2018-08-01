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
    public class CategoryControllerShould : BaseWebControllerSetup<Category>
    {
        [Fact]
        public async Task ListShouldReturnsTwoItems()
        {
            var result = (await GetList("/api/categories")).ToList();

            Assert.Equal(2, result.Count());
            Assert.Equal(1, result.Count(a => a.Title == "Test Item 1"));
            Assert.Equal(1, result.Count(a => a.Title == "Test Item 2"));
        }

        [Fact]
        public async Task GetByIdShouldReturnOneItem()
        {
            var result = (await GetById("/api/categories/1"));

            Assert.NotNull(result);
            Assert.Equal("Test Item 1", result.Title);
        }

        [Fact]
        public async Task PostShouldAddNewItem()
        {
            var dto = new CategoryDTO()
            {
                Id = 3,
                Title = "Test 3",
                Description = "This is item 3 testing only",
            };

            await Post($"/api/categories", dto);

            var result = (await GetById($"/api/categories/{dto.Id}"));

            Assert.NotNull(result);
            Assert.Equal("Test 3", result.Title);

        }
    }
}
