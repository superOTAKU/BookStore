using API.Infrastructures.Exceptions;
using API.Modules.BookModule;
using API.Modules.BookModule.Domains;
using MediatR;
using System.Net;

namespace API.UseCases.Books.Add;

public class AddBookCommandHandler : IRequestHandler<AddBookCommand, AddBookResult>
{
    private readonly IBookRepository _repository;
    private readonly ILogger<AddBookCommandHandler> _logger;

    public AddBookCommandHandler(IBookRepository repository, ILogger<AddBookCommandHandler> logger)
    {
        _repository = repository;
        _logger = logger;   
    }

    public async Task<AddBookResult> Handle(AddBookCommand request, CancellationToken cancellationToken)
    {
        if (!_repository.IsAuthorExists(request.AuthorId))
        {
            throw new RestException(ErrorCodes.AuthorNotFound, HttpStatusCode.NotFound);
        }
        var book = new Book
        {
            Title = request.Title,
            Description = request.Description,
            AuthorId = request.AuthorId,
        };
        _repository.AddBook(book);
        _repository.UnitOfWork.Commit();
        _logger.LogInformation("Book {Id} is Added", book.Id);
        return new AddBookResult
        {
            Id = book.Id,
        };
    }

}
