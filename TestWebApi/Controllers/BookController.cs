using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestWebApi.Models;

namespace TestWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private static int _idCounter = 1;
        private static readonly List<Book> _books = new List<Book>();

        [HttpGet]
        public IEnumerable<BookModel> GetBooks()
        {
            return _books.Select(b => new BookModel
            {
                Id = b.Id,
                Title = b.Title,
                Author = b.Author,
                PagesCount = b.PagesCount
            });
        }

        [HttpPost]
        public void AddBook([FromForm] BookModel model)
        {
            _books.Add(new Book
            {
                Id = _idCounter++,
                Title = model.Title,
                Author = model.Author,
                PagesCount = model.PagesCount
            });
        }

        [HttpDelete("{id}")]
        public void DeleteBook(int id)
        {
            _books.Remove(_books.First(b => b.Id == id));
        }
    }

    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public int PagesCount { get; set; }

        public int? VisitorId { get; set; }
    }
}
