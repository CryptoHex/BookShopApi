using BookShopApi.Models.Data;
using BookShopApi.Services.Models.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShopApi.Services
{
    public interface IBookService
    {

        BooksPageListingModel AllBooks(int page = 1);

        Book AddAndReturnBook(BookModel bookModel);

        BookDetailsModel GetBookById(int id);

        void EditBook(int id, BookModel bookModel);

        void DeleteBook(int id);

    }
}
