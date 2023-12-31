public class BookService : IBookService
{
    private readonly List<Book> _books;

    public BookService()
    {
        _books = new List<Book>
        {
            new Book { Id = 1, Title = "1984", Author = "George Orwell" },
            new Book { Id = 2, Title = "To Kill a Mockingbird", Author = "Harper Lee" },
            new Book { Id = 3, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald" },
        };
    }

    public IEnumerable<Book> GetAllBooks() => _books;

    public Book GetBookById(int id) => _books.FirstOrDefault(b => b.Id == id);

    public void AddBook(Book book)
    {
        _books.Add(book);
    }

    public void UpdateBook(Book book)
    {
        var existingBook = GetBookById(book.Id);
        if (existingBook == null)
        {
            return;
        }
        existingBook.Title = book.Title;
        existingBook.Author = book.Author;
    }

    public void DeleteBook(int id)
    {
        var book = GetBookById(id);
        if (book == null)
        {
            return;
        }
        _books.Remove(book);
    }
}