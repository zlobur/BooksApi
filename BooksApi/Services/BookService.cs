using BooksApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksApi.Services
{
    public class BookService : IBookService
    {
        private readonly BooksContext _context;
        public BookService(BooksContext context)
        {
            this._context = context;
        }

        public async Task<bool> CreateBookAsync(Book book)
        {
            _context.Books.Add(book);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteBookAsync(Guid id)
        {
            var book = await _context.Books.SingleOrDefaultAsync(b => b.Id == id);
            if (book == null)
            {
                return false;
            }

            _context.Books.Remove(book);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Book> GetBookAsync(Guid id)
        {
            return await _context.Books.SingleOrDefaultAsync(m => m.Id == id);
        }

        public async Task<bool> UpdateBookAsync(Guid id, Book book)
        {
            _context.Entry(book).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;

        }
    }
}
