using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using DbExample.Entities;

namespace DbExample.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public IEnumerable<Book> Get(string title)
        {
            var results = new List<Book>();

            var commandText = $"SELECT * FROM {TableName} WHERE Title = @title";
            var command = GetCommand(commandText);
            command.Parameters.AddWithValue("title", title);

            using (var reader = command.ExecuteReader())
            {

                var schema = reader.GetColumnSchema();
                while (reader.Read())
                {
                    results.Add(Create(schema, reader));
                }

                return results;
            }
        }
    }
}
