using API.Commons.DataAccesses;
using API.Modules.BookModule;
using API.Modules.BookModule.Domains;

namespace API.Infrastructures.DataAccesses;

public class BookRepository : RepositoryBase, IBookRepository
{
    public BookRepository(AppDbContext db, IUnitOfWork unitOfWork) : base(db, unitOfWork)
    {
    }

    public void AddBook(Book book)
    {
        Db.Books.Add(book);
    }

    public bool IsAuthorExists(int authorId)
    {
        return Db.Authors.Any(e => e.Id == authorId);
    }

    public Book? GetBookById(int id)
    {
        return Db.Books.Where(e => e.Id == id).FirstOrDefault();
    }

    public IEnumerable<Book> GetBooksByAuthorId(int authorId)
    {
        return Db.Books.Where(e => e.AuthorId == authorId);
    }
}
