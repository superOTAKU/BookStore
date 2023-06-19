using API.Commons.DataAccesses;
using API.Modules.BookModule.Domains;

namespace API.Modules.BookModule;

public interface IBookRepository : IRepository
{
    void AddBook(Book book);

    Book? GetBookById(int id);

    IEnumerable<Book> GetBooksByAuthorId(int authorId);

    bool IsAuthorExists(int authorId);


}
