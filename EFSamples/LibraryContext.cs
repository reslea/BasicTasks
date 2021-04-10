using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace EFSamples
{
    public class LibraryContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public DbSet<BookPrice> BookPrices { get; set; }

        public DbSet<Visitor> Visitors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = @"Data Source=SZHIZHKONB1\SQLEXPRESS;Initial Catalog=GeneratedLibrary;Integrated Security=True;";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
