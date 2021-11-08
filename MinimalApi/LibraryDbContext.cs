using Microsoft.EntityFrameworkCore;

namespace MinimalApi
{
    public class LibraryDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public LibraryDbContext(DbContextOptions<LibraryDbContext> opts) : base(opts)
        {
        }
    }
}
