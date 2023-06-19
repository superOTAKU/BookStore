using MediatR;

namespace API.UseCases.Books.AddCover;

public class AddBookCoverComand : IRequest<Unit>
{
    public int BookId { get; set; }

    public IFormFile CoverFile = null!;
}
