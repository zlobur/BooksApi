using BooksApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksApi.Services
{
    public interface IBookService
    {
        Task<bool> CreateBookAsync(Book book);
        Task<Book> GetBookAsync(int id);
        Task<bool> UpdateBookAsync(int id, Book book);
        Task<bool> DeleteBookAsync(int id);
    }
}
