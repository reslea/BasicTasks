using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EFSamples
{
    class Program
    {
        static void Main(string[] args)
        {

            using var context = new LibraryContext();

            context.Database.EnsureCreated();
            
            var visitor = context.Visitors
                .Include(v => v.TakenBooks)
                .OrderByDescending(v => v.Name)
                .FirstOrDefault();

            if (visitor == null)
            {
                Console.WriteLine("No visitor was found");
                return;
            }

            foreach (var book in visitor.TakenBooks)
            {
                Console.WriteLine($"{book.Id}\t{book.Title}\t{book.Author}\t{book.PagesCount}");
            }

            //FillTables(context);

            //Console.Write("what book to search: ");
            //var searchTerm = Console.ReadLine();
            //SearchBooks(context, searchTerm);
        }

        static void FillTables(LibraryContext context)
        {
            var bookToAdd1 = new Book
            {
                Title = "Title1",
                Author = "Author1",
                PagesCount = 100
            };
            var bookToAdd2 = new Book
            {
                Title = "Title2",
                Author = "Author2",
                PagesCount = 100
            };
            context.Books.Add(bookToAdd1);
            context.Books.Add(bookToAdd2);

            var bookPrice = new BookPrice
            {
                Book = bookToAdd2,
                Price = 10000m
            };
            context.BookPrices.Add(bookPrice);

            var visitor = new Visitor
            {
                Name = "Ivan",
                TakenBooks = new List<Book> { bookToAdd1, bookToAdd2 }
            };
            context.Visitors.Add(visitor);
            context.SaveChanges();
        }

        static IEnumerable<Book> SearchBooks(LibraryContext context, string searchTerm)
        {
            var _books = context.Books;

            var books = _books
                .Where(b => b.Author.Contains(searchTerm) || b.Title.Contains(searchTerm));

            foreach (var book in books)
            {
                Console.WriteLine($"{book.Id}\t{book.Title}\t{book.Author}\t{book.PagesCount}");
            }
            return books;
        }

        static void DataAdepterAndCommandBUilder()
        {
            var connection = new SqlConnection(GetConnectionString());
            var dataAdapter = new SqlDataAdapter("SELECT * FROM Books", connection);

            var dataSet = new DataSet();
            dataAdapter.Fill(dataSet);

            Console.WriteLine($"{nameof(dataAdapter.UpdateBatchSize)}: {dataAdapter.UpdateBatchSize}");

            var booksTable = dataSet.Tables[0];
            var row = booksTable.NewRow();

            row[1] = "T1";
            row[2] = "A1";
            row[3] = 15;

            booksTable.Rows.Add(row);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);

            Console.WriteLine($"{nameof(commandBuilder.GetInsertCommand)}: {commandBuilder.GetInsertCommand().CommandText}");
            Console.WriteLine($"{nameof(commandBuilder.GetUpdateCommand)}: {commandBuilder.GetUpdateCommand().CommandText}");
            Console.WriteLine($"{nameof(commandBuilder.GetDeleteCommand)}: {commandBuilder.GetDeleteCommand().CommandText}");


            dataAdapter.Update(dataSet);
        }

        private static string GetConnectionString()
        {
            return @"Data Source=SZHIZHKONB1\SQLEXPRESS;Initial Catalog=Library;Integrated Security=True;";
        }
    }
}
