using System;
using Microsoft.EntityFrameworkCore;
using Xunit;
using System.Linq;
using Snap.Notes.Core.Entities;

namespace Snap.Notes.Tests.Integration.Repository
{
    public class CategoryRepositoryShould : BaseRepositorySetup<Category>
    {
        [Fact]
        public void AddEntryAndSetId()
        {           
            var item = new Category();

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
            var item = new Category()
            {
                Title = initialTitle
            };
            _repository.Add(item);
            
            // detach the item so we get a different instance
            _dbContext.Entry(item).State = EntityState.Detached;

            // fetch the item and update its title
            var newItem = _repository.List()
                .FirstOrDefault(i => i.Title == initialTitle);
            Assert.NotSame(item, newItem);
            var newTitle = Guid.NewGuid().ToString();
            newItem.Title = newTitle;

            // Update the item
            _repository.Update(newItem);        
            var updatedItem = _repository.List()
                .FirstOrDefault(i => i.Title == newTitle);

            Assert.NotEqual(item.Title, updatedItem.Title);
            Assert.Equal(newItem.Id, updatedItem.Id);
        }

        [Fact]
        public void DeleteEntryAfterAddingIt()
        {
            // add an item
            var initialTitle = Guid.NewGuid().ToString();
            var item = new Category()
            {
                Title = initialTitle
            };
            _repository.Add(item);

            // delete the item
            _repository.Delete(item);

            // verify it's no longer there
            Assert.DoesNotContain(_repository.List(), 
                i => i.Title == initialTitle);
        }        
    }
}