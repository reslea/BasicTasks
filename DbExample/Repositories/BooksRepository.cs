using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DbExample.Entities;

namespace DbExample.Repositories
{
    public class BooksRepository : IRepository<Book>, IDisposable
    {
        private readonly SqlConnection _connection;
        private readonly string _tableName = $"[{nameof(Book)}s]";

        public BooksRepository()
        {
            var connectionString = @"Data Source=SZHIZHKONB1\SQLEXPRESS;Initial Catalog=Library;Integrated Security=True;";
            _connection = new SqlConnection(connectionString);
            _connection.Open();
        }

        public IEnumerable<Book> Get()
        {
            var commandText = $"SELECT * FROM {_tableName}";
            var command = GetCommand(commandText);

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
            var commandText = $"SELECT * FROM {_tableName} WHERE Id = @id";
            var command = GetCommand(commandText);
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

        public void Add(Book entity)
        {
            var commandText = $"INSERT INTO {_tableName} (Title, Author, PagesCount) VALUES (@title, @author, @pagesCount)";
            var command = GetCommand(commandText);

            command.Parameters.AddWithValue("title", entity.Title);
            command.Parameters.AddWithValue("author", entity.Author);
            command.Parameters.AddWithValue("pagesCount", entity.PagesCount);

            command.ExecuteNonQuery();
        }

        public void Update(Book entity)
        {
            var commandText = $"UPDATE {_tableName} " +
                              "SET Title = @title, Author = @author, PagesCount = @pagesCount " +
                              "WHERE Id = @id";
            var command = GetCommand(commandText);

            command.Parameters.AddWithValue("id", entity.Id);
            command.Parameters.AddWithValue("title", entity.Title);
            command.Parameters.AddWithValue("author", entity.Author);
            command.Parameters.AddWithValue("pagesCount", entity.PagesCount);

            command.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            var commandText = $"DELETE FROM {_tableName} WHERE Id = @id";
            var command = GetCommand(commandText);
            
            command.Parameters.AddWithValue("id", id);
            command.ExecuteNonQuery();
        }

        public void Dispose()
        {
            _connection?.Dispose();
        }

        private SqlCommand GetCommand(string command)
        {
            return new SqlCommand(command, _connection);
        }
    }
}
