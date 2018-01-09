using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShopApi.Models.Data;
using BookShopApi.Infrastructure.Extensions;
using BookShopApi.Services.Models.Book;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using static BookShopApi.Infrastructure.Constants.PageConstants;
namespace BookShopApi.Services.Implementations
{

    public class BookService : IBookService
    {
        private readonly BookShopApiDbContext db;

        public BookService(BookShopApiDbContext db)
        {
            this.db = db;
        }


        public Book AddAndReturnBook(BookModel bookModel)
        {
            var book = Mapper.Map<Book>(bookModel);

            this.db.Books.Add(book);
            db.SaveChanges();
            return book;
        }

        public void EditBook(int id, BookModel bookModel)
        {
            var allbooks = this.db.Books.ToList();
            var existingBook = this.db.Books.Find(id);
            var book = Mapper.Map<Book>(bookModel);

            existingBook.Title = book.Title;
            existingBook.Description = book.Description;
            existingBook.AuthorId = book.AuthorId;
            existingBook.Copies = book.Copies;
            existingBook.Price = book.Price;
            existingBook.Edition = book.Edition;

            db.SaveChanges();
        }

        public BooksPageListingModel AllBooks(int page = 1)
        {
            int totalPages = (int)Math.Ceiling(this.db.Books.Count() / (double)PageSize);
            if (totalPages < page)
            {
                page = 1;
            }

            var books = this.db.Books
                        .OrderByDescending(j => j.Id)
                        .Skip((page - 1) * PageSize)
                        .Take(PageSize)
                        .ProjectTo<BooksListingModel>()
                        .ToList();

            var booksPage = new BooksPageListingModel
            {
                Books = books,
                Page = page,
                TotalPages = totalPages
            };

            return booksPage;

        }
        public BookDetailsModel GetBookById(int id)
        {
            var book = this.db.Books.Find(id);

            var bookDetailsModel = Mapper.Map<BookDetailsModel>(book);

            return bookDetailsModel;
        }

        public void DeleteBook(int id)
        {
            var book = this.db.Books.Find(id);

            db.Remove(book);
            db.SaveChanges();
        }
    }
}
