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
        enum Operation
        {
            Exit,
            ShowAll,
            ShowById,
            Delete
        }

        static void Main(string[] args)
        {
            using IBookRepository bookRepository = new BookRepository();

            var operation = ShowMenu();

            switch (operation)
            {
                case Operation.ShowAll:
                    ShowAll(bookRepository.Get());
                    break;
                case Operation.ShowById:
                    Console.WriteLine("Enter bookId: ");
                    if (int.TryParse(Console.ReadLine(), out var getBookId))
                    {
                        Show(bookRepository.Get(getBookId));
                    }
                    break;
                case Operation.Delete:
                    Console.WriteLine("Enter bookId: ");
                    if (int.TryParse(Console.ReadLine(), out var deleteBookId))
                    {
                        bookRepository.Delete(deleteBookId);
                        Console.WriteLine("Deleted");
                    }

                    break;
                default:
                    Environment.Exit(0);
                    break;
            }


            #region RepositoryExamples

            //using (IBookRepository booksRepo = new BookRepository())
            //{

            //}


            //var booksRepository = new Old_BooksRepository();

            //GetAllBooks(booksRepository);
            //var book = GetBook(booksRepository);
            //AddBook(booksRepository);
            //UpdateBook(booksRepository, 2);
            //DeleteBook(booksRepository, 10);

            //var repository = new Repository<Visitor>();

            //var result = repository.Get();

            //var visitor = repository.Get(1);

            //var visitorToAdd = new Visitor
            //{
            //    FirstName = "Петр",
            //    LastName = "Петров",
            //    BirthDate = new DateTime(2000, 01, 01),
            //    Rating = 4.4m
            //};
            //repository.Add(visitorToAdd);

            //visitor.LastName = "Иванов";
            //visitor.FirstName = "Иван";
            //visitor.Rating = 2.1m;
            //visitor.BirthDate = new DateTime(1999, 12, 12);

            //repository.Update(visitor);

            #endregion
        }

        private static void ShowAll(IEnumerable<Book> books)
        {
            foreach (var book in books)
            {
                Show(book);
            }
        }

        private static void Show(Book book)
        {
            Console.WriteLine($"{book.Id}\t{book.Title}\t{book.Author}\t{book.PagesCount}");
        }

        private static Operation ShowMenu()
        {
            while (true)
            { 
                Console.WriteLine("Choose option: ");
                Console.WriteLine("1. Show all");
                Console.WriteLine("2. Show by id");
                Console.WriteLine("3. Delete by id");
                Console.WriteLine("0. Exit");

                if (int.TryParse(Console.ReadLine(), out var operationId)
                    && operationId >= 0 && operationId <= 3)
                {
                    var operation = (Operation)operationId;
                    return operation;
                }
                Console.WriteLine("Incorrect input!");
            }
        }

        private static void DeleteBook(Old_BooksRepository oldBooksRepository, int i)
        {
            var bookId = 15;
            oldBooksRepository.Delete(bookId);
        }

        private static void UpdateBook(Old_BooksRepository oldBooksRepository, int bookId)
        {
            var bookToUpate = new Book
            {
                Id = bookId,
                Title = "Дурная кровь",
                Author = "Роберт Гэлбрейт",
                PagesCount = 900
            };
            oldBooksRepository.Update(bookToUpate);
        }

        static void GetAllBooks(Old_BooksRepository oldBooksRepository)
        {
            var books = oldBooksRepository.Get();
            foreach (var bookItem in books)
            {
                Console.WriteLine($"{bookItem.Title}: {bookItem.PagesCount}");
            }
        }

        static Book GetBook(Old_BooksRepository oldBooksRepository)
        {
            var book = oldBooksRepository.Get(2);
            Console.WriteLine($"{book.Title}: {book.PagesCount}");

            return book;
        }

        static void AddBook(Old_BooksRepository oldBooksRepository)
        {
            var bookToAdd = new Book { Author = "Достоевский", Title = "Преступление и наказание", PagesCount = 500 };
            oldBooksRepository.Add(bookToAdd);
        }
    }
}
