using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShopApi.Models.Data
{
    public class BookShopApiDbContext : DbContext
    {
        public BookShopApiDbContext(DbContextOptions<BookShopApiDbContext> options)
            : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryBook> CategoryBooks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CategoryBook>()
                .HasKey(cb => new { cb.BookId, cb.CategoryId});
        }

    }
}
