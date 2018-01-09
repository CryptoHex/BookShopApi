using BookShopApi.Controllers.BaseController;
using BookShopApi.Models.Data;
using BookShopApi.Services;
using BookShopApi.Services.Models.Book;
using Microsoft.AspNetCore.Mvc;
using BookShopApi.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShopApi.Controllers
{
    [Route("api/[controller]")]
    public class BooksController : BaseApiController
    {
        private readonly IBookService books;

        public BooksController(IBookService books)
        {
            this.books = books;
        }

        //[HttpGet]
        //public IEnumerable<Book> Get() => this.books.AllBooks();

        [HttpGet]
        public IActionResult Get()
        {
            var httpQuery = HttpContext.Request.Query["page"];
            int page = HttpContext.Request.Query["page"].ToString().GetValueOrOneIfDefault();
      
            var bookPage = this.books.AllBooks(page);

            if (bookPage != null)
            {
                return Ok(bookPage);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {

            var book = this.books.GetBookById(id);

            if (book !=  null)
            {
                return Ok(book);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Post([FromBody] BookModel bookModel)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var book = books.AddAndReturnBook(bookModel);
            return CreatedAtAction("books", book.Id,book);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] BookModel bookModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            books.EditBook(id, bookModel);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            books.DeleteBook(id);
            return Ok();
        }

    }
}
