Console.WriteLine("Hello, World!");

var book = new Book(15);
var anotherBook = CreateRandomBook();
var library = new Library();

// create method
Book CreateRandomBook()
{
    return new Book(4);
}

// create type
class Library { }