using MediatR;

namespace API.UseCases.Books.Add;

public class AddBookCommand : IRequest<AddBookResult>
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int AuthorId { get; set; }
}
