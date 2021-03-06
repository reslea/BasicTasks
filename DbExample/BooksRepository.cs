using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DbExample
{
    public class BooksRepository : IRepository<Book>, IDisposable
    {
        private readonly SqlConnection _connection;

        public BooksRepository()
        {
            var connectionString = @"Data Source=SZHIZHKONB1\SQLEXPRESS;Initial Catalog=Library;Integrated Security=True;";
            _connection = new SqlConnection(connectionString);
            _connection.Open();
        }

        public IEnumerable<Book> Get()
        {
            var commandText = "SELECT * FROM [Books]";
            var command = new SqlCommand(commandText, _connection);

            using var booksReader = command.ExecuteReader();

            while (booksReader.Read())
            {
                yield return new Book
                {
                    Id = (int)booksReader[0],
                    Author = (string)booksReader[1],
                    Title = (string)booksReader[2],
                    PagesCount = (int)booksReader[3]
                };
            }
        }

        public Book Get(int id)
        {
            var commandText = "SELECT * FROM [Books] WHERE Id = @id";
            var command = new SqlCommand(commandText, _connection);
            command.Parameters.AddWithValue("id", id);

            using var booksReader = command.ExecuteReader();

            if (!booksReader.Read()) throw new ArgumentOutOfRangeException();
            
            return new Book
            {
                Id = (int) booksReader[0],
                Author = (string) booksReader[1],
                Title = (string) booksReader[2],
                PagesCount = (int) booksReader[3]
            };
        }

        public void Add(Book book)
        {
            var commandText = "INSERT INTO [Books] (Title, Author, PagesCount) VALUES (@title, @author, @pagesCount)";
            var command = new SqlCommand(commandText, _connection);

            command.Parameters.AddWithValue("title", book.Title);
            command.Parameters.AddWithValue("author", book.Author);
            command.Parameters.AddWithValue("pagesCount", book.PagesCount);

            command.ExecuteNonQuery();
        }

        public void Update(Book book)
        {
            throw new NotImplementedException();
        }

        public void Delete(Book book)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _connection?.Dispose();
        }
    }
}
