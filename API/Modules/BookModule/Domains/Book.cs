using API.Commons.Domains;

namespace API.Modules.BookModule.Domains;

public class Book : IHasCreateTime, IHasUpdateTime
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime CreateTime { get; set; }
    public DateTime UpdateTime { get; set; }

    public int AuthorId { get; set; }

    public Author Author { get; set; } = null!;
}
