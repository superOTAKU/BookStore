using API.Commons.Domains;

namespace API.Modules.BookModule.Domains;

public class Author : IHasCreateTime, IHasUpdateTime
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Nationality { get; set; } = null!;
    public DateTime CreateTime { get; set; }
    public DateTime UpdateTime { get; set; }

    public IList<Book> Books { get; set;} = new List<Book>();
}
