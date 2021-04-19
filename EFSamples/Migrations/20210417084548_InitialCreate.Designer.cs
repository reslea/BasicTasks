﻿// <auto-generated />
using System;
using EFSamples;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFSamples.Migrations
{
    [DbContext(typeof(LibraryContext))]
    [Migration("20210417084548_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFSamples.Entities.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("PagesCount")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int?>("VisitorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VisitorId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            Author = "Элли Брош",
                            PagesCount = 500,
                            Title = "Гипербола с половиной",
                            VisitorId = -1
                        },
                        new
                        {
                            Id = -2,
                            Author = "Фредрик Бакман",
                            PagesCount = 600,
                            Title = "Тревожные люди"
                        },
                        new
                        {
                            Id = -3,
                            Author = "Наринэ Абгарян",
                            PagesCount = 400,
                            Title = "Симон",
                            VisitorId = -1
                        },
                        new
                        {
                            Id = -4,
                            Author = "Эмили Сент-Джон Мандел",
                            PagesCount = 1000,
                            Title = "Стеклянный отель"
                        });
                });

            modelBuilder.Entity("EFSamples.Entities.BookPrice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("BookId")
                        .IsUnique();

                    b.ToTable("Prices");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            BookId = -1,
                            Price = 100m
                        },
                        new
                        {
                            Id = -2,
                            BookId = -2,
                            Price = 200m
                        },
                        new
                        {
                            Id = -3,
                            BookId = -3,
                            Price = 300m
                        },
                        new
                        {
                            Id = -4,
                            BookId = -4,
                            Price = 400m
                        });
                });

            modelBuilder.Entity("EFSamples.Entities.Visitor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Visitors");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            Name = "Alex"
                        },
                        new
                        {
                            Id = -2,
                            Name = "Oleg"
                        });
                });

            modelBuilder.Entity("EFSamples.Entities.Book", b =>
                {
                    b.HasOne("EFSamples.Entities.Visitor", "Visitor")
                        .WithMany("TakenBooks")
                        .HasForeignKey("VisitorId");

                    b.Navigation("Visitor");
                });

            modelBuilder.Entity("EFSamples.Entities.BookPrice", b =>
                {
                    b.HasOne("EFSamples.Entities.Book", "Book")
                        .WithOne()
                        .HasForeignKey("EFSamples.Entities.BookPrice", "BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");
                });

            modelBuilder.Entity("EFSamples.Entities.Visitor", b =>
                {
                    b.Navigation("TakenBooks");
                });
#pragma warning restore 612, 618
        }
    }
}
