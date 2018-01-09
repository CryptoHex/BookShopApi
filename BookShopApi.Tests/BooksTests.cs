using BookShopApi.Controllers;
using BookShopApi.Models.Data;
using BookShopApi.Services;
using BookShopApi.Services.Implementations;
using BookShopApi.Services.Models.Book;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Xunit;
using Moq;

namespace BookShopApi.Tests
{
    public class EndpointTests
    {

        public EndpointTests()
        {
            Tests.Initialize();
        }

        [Fact]
        public void BooksControllerGetDetailsOfNonExistantIdShould_ReturnNotFoundStatusCode()
        {
            BooksController booksController = GetController();
            int nonExistantId = 99;
            Assert.IsType<NotFoundResult>(booksController.Get(nonExistantId));
        }

        [Fact]
        public void BooksControllerPostWithInproperValuesShould_ReturnBadRequestStatus()
        {
            BooksController booksController = GetController();
            BookModel bookModel = new BookModel { Title = "Invalid Data" };
            booksController.ModelState.AddModelError("Invalid Data", "Invalid Data");
            Assert.IsType<BadRequestObjectResult>(booksController.Post(bookModel));
        }

        [Fact]
        public void BooksControllerPostWithProperValuesShould_ReturnCreatedStatus()
        {
            BooksController booksController = GetController();
            BookModel bookModel = new BookModel { Title = "BookModel sample", AuthorId = 1, Copies = 2000, Description = "BookModel Create Book", Edition = 3, Price = 2000 };
            Assert.IsType<CreatedAtActionResult>(booksController.Post(bookModel));
        }

        [Fact]
        public void BooksControllerPutWithInproperValuesShould_ReturnBadRequestStatus()
        {      
            int id = 11;
            BooksController booksController = GetController();
            BookModel bookModel = new BookModel { Title = "Invalid Data" };
            booksController.ModelState.AddModelError("Invalid Data", "Invalid Data");
            Assert.IsType<BadRequestObjectResult>(booksController.Put(id,bookModel));
        }

        [Fact]
        public void BooksControllerPutWithProperValuesShould_ReturnCreatedStatus()
        {
            int id =11;
            BooksController booksController = GetController();
            BookModel bookModel = new BookModel { Title = "BookModel sample", AuthorId = 1, Copies = 2000, Description = "BookModel Create Book", Edition = 3, Price = 2000 };
            Assert.IsType<OkResult>(booksController.Put(id, bookModel));
        }


        private BooksController GetController()
        {
            BookShopApiDbContext db = GetDatabase();
            PopulateData(db);
            IBookService books = new BookService(db);
            BooksController booksController = new BooksController(books);

            return booksController;
        }


        private BookShopApiDbContext GetDatabase()
        {
            var dbOptions = new DbContextOptionsBuilder<BookShopApiDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new BookShopApiDbContext(dbOptions);
        }

        private void PopulateData(BookShopApiDbContext db)
        {

            List<Book> booksData = new List<Book>
            {
                new Book { AuthorId = 3, Title = "Fantastic Creatures and where to find them", Description = "Book with ID: 1", Price = 20.00m, Edition = 1, Copies = 100000 },
                new Book { AuthorId = 4, Title = "It", Description = "Book with ID: 2", Price = 40.00m, Edition = 2, Copies = 200000 },
                new Book { AuthorId = 1, Title = "Game of Thrones", Description = "Book with ID: 3", Price = 60.00m, Edition = 1, Copies = 300000 },
                new Book { AuthorId = 2, Title = "The art of war ", Description = "Book with ID: 4", Price = 80.00m, Edition = 4, Copies = 400000 },
            };

            db.Books.AddRange(booksData);
            db.SaveChanges();
        }


    }



}
