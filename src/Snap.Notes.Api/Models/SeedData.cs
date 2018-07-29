using Snap.Notes.Core.Entities;
using Snap.Notes.Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;


namespace Snap.Notes.Api.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(AppDbContext context)
        {
            if (!context.Categories.Any())
            {
                // Add ToDoItems
                context.Categories.AddRange(
                    new Category
                    {
                        Id = 1,
                        Title = "Test Item 1",
                        Description = "Item 1 Description"
                    },
                    new Category
                    {
                        Id = 2,
                        Title = "Test Item 2",
                        Description = "Item 2 Description"
                    }
                );


                context.SaveChanges();
            }

            if (!context.Posts.Any())
            {
                // Add ToDoItems
                context.Posts.AddRange(
                    new Post
                    {
                        Id = 1,
                        Content = "Test Item 1",
                        CategoryId = 1
                    },
                    new Post
                    {
                        Id = 2,
                        Content = "Test Item 2",
                        CategoryId = 1
                    }
                );


                context.SaveChanges();
            }

            if (!context.Books.Any())
            {
                // Add ToDoItems
                context.Books.AddRange(
                    new Book
                    {
                        Id = 1,
                        Title = "Test Item 1",
                        CategoryId = 1,
                        Author = "Mike",
                        Url = "mike.com"
                    },
                    new Book
                    {
                        Id = 2,
                        Title = "Test Item 2",
                        CategoryId = 1,
                        Author = "Mike",
                        Url = "mike.com"
                    }
                );


                context.SaveChanges();
            }

            if (!context.Tags.Any())
            {
                // Add ToDoItems
                context.Tags.AddRange(
                    new Tag
                    {
                       Name = "Test Item 1",
                    },
                    new Tag
                    {
                        Name = "Test Item 2",
                    }
                );


                context.SaveChanges();
            }
        }
            
    }
}
