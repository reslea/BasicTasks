﻿using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;

namespace EFSamples
{
    class Program
    {
        static void Main(string[] args)
        {

            using var context = new LibraryContext();
            context.Database.EnsureCreated();

            Console.Write("what book to search: ");
            var searchTerm = Console.ReadLine();
            var _books = context.Books;

            var books = _books
                .Where(b => b.Author.Contains(searchTerm) || b.Title.Contains(searchTerm));
            
            foreach (var book in books)
            {
                Console.WriteLine($"{book.Id}\t{book.Title}\t{book.Author}\t{book.PagesCount}");
            }
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
