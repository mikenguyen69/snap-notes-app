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
        }
            
    }
}
