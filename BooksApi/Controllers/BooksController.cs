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

        //[HttpGet]
        //public ActionResult<IEnumerable<string>> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}
        // GET: api/Books/1
        [HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "111";
        //}
        public Task<Book> Get(int id)
            => _bookService.GetBookAsync(id);

        // POST: api/Books
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Book book)
            => (await _bookService.CreateBookAsync(book))
                ? (IActionResult)Created($"api/products/{book.Id}", book) // HTTP 201
                : StatusCode(500); // HTTP 500

        // PUT: api/Books/1
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]Book book)
            => (await _bookService.UpdateBookAsync(id, book))
                ? Ok()
                : StatusCode(500);

        // DELETE: api/Books/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
            => (await _bookService.DeleteBookAsync(id))
                ? (IActionResult)Ok()
                : NoContent();
    }
}