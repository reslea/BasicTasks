using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;

namespace DbExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var booksRepository = new BooksRepository();

            var books = booksRepository.Get();
            foreach (var bookItem in books)
            {
                Console.WriteLine($"{bookItem.Title}: {bookItem.PagesCount}");
            }

            var book = booksRepository.Get(2);
            Console.WriteLine($"{book.Title}: {book.PagesCount}");

            booksRepository.Add(new Book { Author = "Достоевский", Title = "Преступление и наказание", PagesCount = 500 });
        }
    }
}
