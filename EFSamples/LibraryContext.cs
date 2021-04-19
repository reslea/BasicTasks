using System;
using System.Collections.Generic;
using System.Text;
using EFSamples.Entities;
using EFSamples.EntityConfigurations;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Seed(modelBuilder);

            //modelBuilder.ApplyConfiguration(new BookConfiguration());
            //modelBuilder.ApplyConfiguration(new BookPriceConfiguration());
            //modelBuilder.ApplyConfiguration(new VisitorConfiguration());

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LibraryContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        private void Seed(ModelBuilder modelBuilder)
        {
            var visitor1 = new Visitor { Id = -1, Name = "Alex" };
            var visitor2 = new Visitor { Id = -2, Name = "Oleg" };

            modelBuilder.Entity<Visitor>().HasData(visitor1);
            modelBuilder.Entity<Visitor>().HasData(visitor2);

            var book1 = new Book { Id = -1, Title = "Гипербола с половиной", Author = "Элли Брош", PagesCount = 500, VisitorId = visitor1.Id };
            var book2 = new Book { Id = -2, Title = "Тревожные люди", Author = "Фредрик Бакман", PagesCount = 600 };
            var book3 = new Book { Id = -3, Title = "Симон", Author = "Наринэ Абгарян", PagesCount = 400, VisitorId = visitor1.Id };
            var book4 = new Book { Id = -4, Title = "Стеклянный отель", Author = "Эмили Сент-Джон Мандел", PagesCount = 1000 };

            modelBuilder.Entity<Book>().HasData(book1);
            modelBuilder.Entity<Book>().HasData(book2);
            modelBuilder.Entity<Book>().HasData(book3);
            modelBuilder.Entity<Book>().HasData(book4);

            var bookPrice1 = new BookPrice { Id = -1, BookId = book1.Id, Price = 100 };
            var bookPrice2 = new BookPrice { Id = -2, BookId = book2.Id, Price = 200 };
            var bookPrice3 = new BookPrice { Id = -3, BookId = book3.Id, Price = 300 };
            var bookPrice4 = new BookPrice { Id = -4, BookId = book4.Id, Price = 400 };

            modelBuilder.Entity<BookPrice>().HasData(bookPrice1);
            modelBuilder.Entity<BookPrice>().HasData(bookPrice2);
            modelBuilder.Entity<BookPrice>().HasData(bookPrice3);
            modelBuilder.Entity<BookPrice>().HasData(bookPrice4);
        }
    }
}
