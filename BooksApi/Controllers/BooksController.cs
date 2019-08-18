using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksApi.Models;
using BooksApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BooksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        IBookService _bookService { get; set; }
        public BooksController(IBookService bookService)
        {
            this._bookService = bookService;
        }

        //GET: api/Books/1
        [HttpGet("{id}")]
        public Task<Book> Get(Guid id)
            => _bookService.GetBookAsync(id);

        //POST: api/Books
       [HttpPost]
        public async Task<IActionResult> Post([FromBody]Book book)
            => (await _bookService.CreateBookAsync(book))
                ? (IActionResult)Created($"api/books/{book.Id}", book) // HTTP 201
                : StatusCode(500); // HTTP 500

        // PUT: api/Books/1
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody]Book book)
            => (await _bookService.UpdateBookAsync(id, book))
                ? Ok()
                : StatusCode(500);

        // DELETE: api/Books/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
            => (await _bookService.DeleteBookAsync(id))
                ? (IActionResult)Ok()
                : NoContent();
    }
}