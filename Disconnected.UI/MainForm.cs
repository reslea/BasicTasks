using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Disconnected.UI
{
    public partial class MainForm : Form
    {
        private readonly SqlConnection _connection;
        private DataTable _dataTable;

        public MainForm()
        {
            InitializeComponent();

            var connectionString = ConfigurationManager.ConnectionStrings["Library"].ConnectionString;
            using (_connection = new SqlConnection(connectionString))
            {
                _connection.Open();

                //PopulateDataGrid_Sample();
                var booksTable = PopulateDataTable("Books");
                var pricesTable = PopulateDataTable("Prices");



                BooksDataGridView.DataSource = booksTable;
                PricesDataGridView.DataSource = pricesTable;

                var dataset = new DataSet();
                dataset.Tables.Add(booksTable);
                dataset.Tables.Add(pricesTable);

                dataset.Relations.Add("BooksPrices",
                    booksTable.Columns["Id"],
                    pricesTable.Columns["BookId"]);
            }
        }

        private DataTable PopulateDataTable(string tableName)
        {
            _dataTable = new DataTable(tableName);
            var command = new SqlCommand($"SELECT * FROM {tableName}", _connection);

            using (var reader = command.ExecuteReader())
            {
                bool isFirstTime = true;
                while (reader.Read())
                {
                    var row = _dataTable.NewRow();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        if (isFirstTime)
                        {
                            _dataTable.Columns.Add(reader.GetName(i), reader.GetFieldType(i));
                        }
                        row[i] = reader[i];
                    }

                    _dataTable.Rows.Add(row);
                    isFirstTime = false;
                }
            }
            
            return _dataTable;
        }

        private void PopulateDataGrid_Sample()
        {
            _dataTable.Columns.Add("Id", typeof(int));
            _dataTable.Columns.Add("Title", typeof(string));
            _dataTable.Columns.Add("Author", typeof(string));
            _dataTable.Columns.Add("PagesCount", typeof(int));

            var row = _dataTable.NewRow();

            row["Id"] = 1;
            row["Title"] = "Война и мир";
            row["Author"] = "Л.Н. Толстой";
            row["PagesCount"] = 100500;

            _dataTable.Rows.Add(row);
        }

        private void DebugButton_Click(object sender, EventArgs e)
        {
            var row = _dataTable.NewRow();

            row[0] = 1;
            row[1] = "11";
            row[2] = "111";
            row[3] = 1111;

            _dataTable.Rows.Add(row);
        }

        private void AddBookButton_Click(object sender, EventArgs e)
        {
            var book = new Book
            {
                Author = AuthorTextBox.Text,
                Title = TitleTextBox.Text,
                PagesCount = (int) PagesCountNumeric.Value
            };

            var context = new ValidationContext(book);
            var isValid = Validator.TryValidateObject(book, context, new List<ValidationResult>(), true);

        }
    }
}
