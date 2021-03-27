using System;
using System.Data.SqlClient;
using System.Linq;

namespace DapperClone.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = @"Data Source=SZHIZHKONB1\SQLEXPRESS;Initial Catalog=Library;Integrated Security=True;";
            using var connection = new SqlConnection(connectionString);

            var bookToAdd = new Book
            {
                Title = "Над пропастью во ржи",
                Author = "Сэлинжер",
                PagesCount = 277
            };

            connection.Execute("INSERT INTO Books (Title, Author, PagesCount) VALUES (@Title, @Author, @PagesCount)",
                bookToAdd);

            var books = connection.Query<Book>("SELECT * FROM Books").ToList();

            var idiotBook = connection.QueryFirstOrDefault<Book>("SELECT * FROM Books WHERE Id = @Id", new { Id = 3 });
        }
    }
}
