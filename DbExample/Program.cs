using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using DbExample.Entities;
using DbExample.Repositories;

namespace DbExample
{
    class Program
    {
        static void Main(string[] args)
        {
            //var booksRepository = new BooksRepository();

            //GetAllBooks(booksRepository);
            //var book = GetBook(booksRepository);
            //AddBook(booksRepository);
            //UpdateBook(booksRepository, 2);
            //DeleteBook(booksRepository, 10);

            var repository = new Repository<Visitor>();

            var result = repository.Get();

            var visitor = repository.Get(1);

            //var visitorToAdd = new Visitor
            //{
            //    FirstName = "Петр",
            //    LastName = "Петров",
            //    BirthDate = new DateTime(2000, 01, 01),
            //    Rating = 4.4m
            //};
            //repository.Add(visitorToAdd);

            visitor.LastName = "Иванов";
            visitor.FirstName = "Иван";
            visitor.Rating = 2.1m;
            visitor.BirthDate = new DateTime(1999, 12, 12);

            repository.Update(visitor);
        }

        private static void DeleteBook(BooksRepository booksRepository, int i)
        {
            var bookId = 15;
            booksRepository.Delete(bookId);
        }

        private static void UpdateBook(BooksRepository booksRepository, int bookId)
        {
            var bookToUpate = new Book
            {
                Id = bookId,
                Title = "Дурная кровь",
                Author = "Роберт Гэлбрейт",
                PagesCount = 900
            };
            booksRepository.Update(bookToUpate);
        }

        static void GetAllBooks(BooksRepository booksRepository)
        {
            var books = booksRepository.Get();
            foreach (var bookItem in books)
            {
                Console.WriteLine($"{bookItem.Title}: {bookItem.PagesCount}");
            }
        }

        static Book GetBook(BooksRepository booksRepository)
        {
            var book = booksRepository.Get(2);
            Console.WriteLine($"{book.Title}: {book.PagesCount}");

            return book;
        }

        static void AddBook(BooksRepository booksRepository)
        {
            var bookToAdd = new Book { Author = "Достоевский", Title = "Преступление и наказание", PagesCount = 500 };
            booksRepository.Add(bookToAdd);
        }
    }
}
