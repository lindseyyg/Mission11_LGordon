namespace Mission11_LGordon.Models;
    public class EFBookstoreRepository : IBookstoreRepository
    {
        private BookstoreContext _context;

        public EFBookstoreRepository(BookstoreContext temp)
        {
            _context = temp;
        }

        public IQueryable<Book> Books
        {
            get => _context.Books;
            set => throw new NotSupportedException("Setting Books property is not supported.");
        }

    }