using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using my_books_tutorial.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books_tutorial.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using(var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                if (!context.Books.Any())
                {
                    context.Books.AddRange(new Book()
                    {
                        Title = "first book",
                        Description = "Description",
                        IsRead = true,
                        Rate = 5,
                        Genre = "Genre",
                        Author = "Malith",
                        CoverUrl = "URL",
                        DateAdded = DateTime.Now.AddDays(-10)

                    },
                    new Book()
                    {
                        Title = "Second book",
                        Description = "Description",
                        IsRead = true,
                        Rate = 5,
                        Genre = "Genre",
                        Author = "Chamika",
                        CoverUrl = "URL",
                        DateAdded = DateTime.Now.AddDays(-10)

                    });

                    context.SaveChanges();
                }
            }

        }
    }
}
