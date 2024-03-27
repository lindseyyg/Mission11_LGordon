using Microsoft.EntityFrameworkCore;

namespace Mission11_LGordon.Models;

public class BookstoreContext : DbContext
{
    public BookstoreContext (DbContextOptions<BookstoreContext> options) : base(options) { }
    public DbSet<Book> Books { get; set; }
}