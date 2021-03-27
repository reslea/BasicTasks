using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;

namespace DapperClone
{
    public static class SqlConnectionExtentions
    {
        public static IEnumerable<T> Query<T>(
            this SqlConnection connection, 
            string queryText) where T : new()
        {
            EnsureConnectionOpen(connection);

            var command = new SqlCommand(queryText, connection);

            using var reader = command.ExecuteReader();
            var schema = reader.GetColumnSchema();
            while (reader.Read())
            {
                yield return Create<T>(schema, reader);
            }
        }

        public static T QueryFirstOrDefault<T>(
            this SqlConnection connection,
            string queryText) where T : new()
        {
            var command = new SqlCommand(queryText, connection);

            using var reader = command.ExecuteReader();
            var schema = reader.GetColumnSchema();
            return reader.Read() 
                ? Create<T>(schema, reader) 
                : default;
        }

        public static T QueryFirstOrDefault<T>(
            this SqlConnection connection,
            string queryText,
            object objParams) where T : new()
        {
            var command = GetCommandWithParams(connection, queryText, objParams);

            using var reader = command.ExecuteReader();
            var schema = reader.GetColumnSchema();
            return reader.Read()
                ? Create<T>(schema, reader)
                : default;
        }

        public static int Execute(
            this SqlConnection connection,
            string commandText)
        {
            EnsureConnectionOpen(connection);

            var command = new SqlCommand(commandText, connection);

            return command.ExecuteNonQuery();
        }

        public static int Execute(
            this SqlConnection connection,
            string commandText,
            object objParams)
        {
            EnsureConnectionOpen(connection);
            
            return GetCommandWithParams(connection, commandText, objParams)
                .ExecuteNonQuery();
        }

        private static SqlCommand GetCommandWithParams(SqlConnection connection, string commandOrQuery, object objParams)
        {
            var queryParams = GetParameterNames(commandOrQuery);
            var properties = objParams.GetType().GetProperties();

            var command = new SqlCommand(commandOrQuery, connection);
            foreach (var queryParam in queryParams)
            {
                var property = properties.First(p => p.Name == queryParam);
                var paramValue = property.GetValue(objParams);
                command.Parameters.AddWithValue(queryParam, paramValue);
            }

            return command;
        }

        private static IEnumerable<string> GetParameterNames(string queryText)
        {
            Regex regex = new Regex(@"@[\w\d-]+");
            MatchCollection matches = regex.Matches(queryText);
            if (matches.Count == 0) yield break;
            foreach (Match match in matches)
                yield return match.Value.Substring(1);
        }

        private static void EnsureConnectionOpen(SqlConnection connection)
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
        }

        private static T Create<T>(ReadOnlyCollection<DbColumn> schema, 
            SqlDataReader reader) where T : new()
        {
            var result = new T();

            for (int colIdx = 0; colIdx < schema.Count; colIdx++)
            {
                var columnName = schema[colIdx].ColumnName;
                var columnType = schema[colIdx].DataType;
                var columnValue = reader[colIdx];

                var value = Convert.ChangeType(columnValue, columnType);

                var property = typeof(T).GetProperties()
                    .FirstOrDefault(p => p.Name == columnName);

                if (property?.PropertyType == columnType)
                {
                    property.SetValue(result, value);
                }
            }

            return result;
        }
    }
}
