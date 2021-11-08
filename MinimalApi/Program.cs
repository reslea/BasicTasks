using MinimalApi;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// before .Build => ConfigureServices

var services = builder.Services;
services.AddDbContext<LibraryDbContext>(options => options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MinimalLibraryDb;Integrated Security=True;"));

services.AddEndpointsApiExplorer();
services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "TestWebApi", Version = "v1" });
});

var app = builder.Build();
// after .Build => Configure

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TestWebApi v1"));

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetService<LibraryDbContext>();
    dbContext!.Database.EnsureCreated();
}

List<Book> books = new List<Book>();

app.MapGet("/books", (LibraryDbContext context) => context.Books.ToList());
app.MapGet("/books/{id:int}", (LibraryDbContext context, int id) =>
    context.Books.FirstOrDefault(b => b.Id == id) switch
    {
        { } x => Results.Ok(x),
        null => Results.NotFound()
    });
app.MapPost("/books/", (LibraryDbContext context, Book newBook) => {
    context.Books.Add(newBook);
    context.SaveChanges();
});
app.MapDelete("/books/{id:int}", (LibraryDbContext context, int id) => {
    context.Books.Remove(context.Books.First(b => b.Id == id));
    context.SaveChanges();
});
app.MapPut("/books/{id:int}", (LibraryDbContext context, int id, Book toUpdate) =>
{
    var existingBook = context.Books.FirstOrDefault(b => b.Id == id);
    if (existingBook == null) return Results.NotFound();

    var updatedBook = existingBook with { 
        Title = toUpdate.Title, 
        Author = toUpdate.Author,
        PagesCount = toUpdate.PagesCount,
        VisitorId = toUpdate.VisitorId,
    };

    context.Entry(existingBook).State = EntityState.Detached;

    context.Books.Update(updatedBook);
    context.SaveChanges();

    return Results.Ok(updatedBook);
});

app.Run();

public record Book(int Id, string Title, string Author, int PagesCount, int? VisitorId);