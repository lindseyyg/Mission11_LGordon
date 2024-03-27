namespace Mission11_LGordon.Models;

public interface IBookstoreRepository
{
    public IQueryable<Book> Books { get; set; }
}