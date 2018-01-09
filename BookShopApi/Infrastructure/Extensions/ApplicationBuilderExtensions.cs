
using BookShopApi.Models.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShopApi.Infrastructure.Extensions
{


    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseDatabasePopulationAndMigration(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
            
              //  serviceScope.ServiceProvider.GetService<BookShopApiDbContext>().Database.EnsureDeleted();
                serviceScope.ServiceProvider.GetService<BookShopApiDbContext>().Database.Migrate();

                var db = serviceScope.ServiceProvider.GetService<BookShopApiDbContext>();


                Task
                    .Run(async () =>
                    {

                        var authors = await db.Authors.ToListAsync();
                        if (authors.Count() == 0)
                        {
                            authors = new List<Author>
                            {

                                new Author { FirstName = "George", LastName = "R.R. Martin"},
                                new Author { FirstName = "Sun", LastName = "Tzu"},
                                new Author { FirstName = "J. K.", LastName = "Rowling"},
                                new Author { FirstName = "Stephen", LastName = "King"},

                            };
                            await db.Authors.AddRangeAsync(authors);
                            await db.SaveChangesAsync();
                        }

                        var books = await db.Books.ToListAsync();
                        if (books.Count() == 0)
                        {
                            books = new List<Book>
                            {
                                new Book { AuthorId = 3, Title = "Fantastic Creatures and where to find them", Description ="Book with ID: 1",Price = 20.00m, Edition = 1, Copies = 100000 },    
                                new Book { AuthorId = 4, Title = "It", Description ="Book with ID: 2",Price = 40.00m, Edition = 2, Copies = 200000 },
                                new Book { AuthorId = 1, Title = "Game of Thrones", Description ="Book with ID: 3",Price = 60.00m, Edition = 1, Copies = 300000 },
                                new Book { AuthorId = 2, Title = "The art of war ", Description ="Book with ID: 4",Price = 80.00m, Edition = 4, Copies = 400000 },
                            };

                            await db.Books.AddRangeAsync(books);
                            await db.SaveChangesAsync();
                        }

                        var categories = await db.Categories.ToListAsync();
                        if (categories.Count() == 0)
                        {
                            categories = new List<Category>
                            {
                                new Category { Name = "Fantasy" },
                                new Category { Name = "Horror" },
                                new Category { Name = "Epic Fantasy" },
                                new Category { Name = "Military Strategy" },
                            };

                            await db.Categories.AddRangeAsync(categories);
                            await db.SaveChangesAsync();
                        }

                        var categoryBooks = await db.CategoryBooks.ToListAsync();
                        if (categoryBooks.Count() == 0)
                        {
                            categoryBooks = new List<CategoryBook>
                            {
                                new CategoryBook { BookId = 1, CategoryId = 1 },
                                new CategoryBook { BookId = 2, CategoryId = 2 },
                                new CategoryBook { BookId = 3, CategoryId = 3 },
                                new CategoryBook { BookId = 4, CategoryId = 4 },

                            };

                            await db.CategoryBooks.AddRangeAsync(categoryBooks);
                            await db.SaveChangesAsync();
                        }



                    })
                    .Wait();

            }

            return app;
        }
    }
}
