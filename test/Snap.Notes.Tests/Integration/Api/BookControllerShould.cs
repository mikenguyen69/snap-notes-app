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
    public class BookControllerShould : BaseWebControllerSetup<Book>
    {
        [Fact]
        public async Task ListShouldReturnsTwoItems()
        {
            var result = (await GetList("/api/books")).ToList();

            Assert.Equal(2, result.Count());
            Assert.Equal(1, result.Count(a => a.Title == "Test Item 1"));
            Assert.Equal(1, result.Count(a => a.Title == "Test Item 2"));
        }

        [Fact]
        public async Task GetByIdShouldReturnOneItem()
        {
            var result = (await GetById("/api/books/1"));

            Assert.NotNull(result);
            Assert.Equal("Test Item 1", result.Title);
        }

        [Fact]
        public async Task PostShouldAddNewItem()
        {
            var dto = new BookDTO()
            {
                Id = 3,
                Title = "Test 3",
                CategoryId = 1,
            };

            await Post($"/api/books", dto);

            var result = (await GetById($"/api/books/{dto.Id}"));

            Assert.NotNull(result);
            Assert.Equal("Test 3", result.Title);

        }

        //[Fact]
        //public async Task CompleteShouldMarkItemToBeDone()
        //{
        //    var result = await GetById("/api/books/1/complete");

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
