using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NoteApp.Models;
using System;
using System.Linq;

namespace NoteApp.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new NoteContext(
                serviceProvider.GetRequiredService<DbContextOptions<NoteContext>>()))
            {
                if (context.Categories.Any())
                {
                    return;   // DB has been seeded
                }

                context.Categories.AddRange(
                    new Category { Name = "Work" },
                    new Category { Name = "Personal" },
                    new Category { Name = "Misc" }
                );

                context.SaveChanges();
            }
        }
    }
}
