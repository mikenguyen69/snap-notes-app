using System;
using Microsoft.EntityFrameworkCore;
using Xunit;
using System.Linq;
using Snap.Notes.Core.Entities;

namespace Snap.Notes.Tests.Integration.Repository
{
    public class PostRepositoryShould : BaseRepositorySetup<Post>
    {
        [Fact]
        public void AddEntryAndSetId()
        {           
            var item = new Post();

            _repository.Add(item);

            var newItem = _repository.List().FirstOrDefault();

            Assert.Equal(item, newItem);
            Assert.True(newItem.Id > 0);
        }

        [Fact]
        public void UpdateEntryAfterAddingIt()
        {
            // add an item
            var initialTitle = Guid.NewGuid().ToString();
            var item = new Post()
            {
                Content = initialTitle
            };
            _repository.Add(item);
            
            // detach the item so we get a different instance
            _dbContext.Entry(item).State = EntityState.Detached;

            // fetch the item and update its title
            var newItem = _repository.List()
                .FirstOrDefault(i => i.Content == initialTitle);
            Assert.NotSame(item, newItem);
            var newTitle = Guid.NewGuid().ToString();
            newItem.Content = newTitle;

            // Update the item
            _repository.Update(newItem);        
            var updatedItem = _repository.List()
                .FirstOrDefault(i => i.Content == newTitle);

            Assert.NotEqual(item.Content, updatedItem.Content);
            Assert.Equal(newItem.Id, updatedItem.Id);
        }

        [Fact]
        public void DeleteEntryAfterAddingIt()
        {
            // add an item
            var initialTitle = Guid.NewGuid().ToString();
            var item = new Post()
            {
                Content = initialTitle,
                CategoryId = 1,
            };
            _repository.Add(item);

            // delete the item
            _repository.Delete(item);

            // verify it's no longer there
            Assert.DoesNotContain(_repository.List(), 
                i => i.Content == initialTitle);
        }        
    }
}