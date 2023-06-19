using API.Commons.Consts;
using API.Commons.DataAccesses;
using API.Infrastructures.Exceptions;
using API.Modules.AclModule;
using API.Modules.AclModule.Dtos;
using API.Modules.AclModule.Policies;
using API.Modules.AttachModule;
using API.Modules.AttachModule.Dtos;
using API.Modules.AttachModule.StorageProtocols;
using API.Modules.BookModule;
using MediatR;
using System.Net;

namespace API.UseCases.Books.AddCover;

public class AddBookCoverCommandHandler : IRequestHandler<AddBookCoverComand, Unit>
{
    private readonly IAttachService _attachService;
    private readonly IBookRepository _bookRepository;
    private readonly ILogger<AddBookCoverCommandHandler> _logger;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAclService _aclService;

    public AddBookCoverCommandHandler(IBookRepository bookRepository, IAttachService attachService, 
        IAclService aclService,
        ILogger<AddBookCoverCommandHandler> logger, IUnitOfWork unitOfWork)
    {
        _attachService = attachService;
        _bookRepository = bookRepository;
        _logger = logger;
        _unitOfWork = unitOfWork;
        _aclService = aclService;
    }

    public Task<Unit> Handle(AddBookCoverComand request, CancellationToken cancellationToken)
    {
        var book = _bookRepository.GetBookById(request.BookId);
        if (book == null)
        {
            throw new RestException(ErrorCodes.BookNotFound, HttpStatusCode.NotFound);
        }
        var stream = request.CoverFile.OpenReadStream();
        var attach = _attachService.Put(new PutAttachCommand
        {
            ComponentType = AttachComponentTypes.BookCover,
            ComponentId = request.BookId.ToString(),
            Name = request.CoverFile.FileName,
            Stream = stream,
            StorageProtocol = LocalFileStorageProtocol.Name
        });
        _aclService.AddAclRecord(new AddAclRecordCommand
        {
            EntityType = AclEntityTypes.Attach,
            EntityId = attach.Id.ToString(),
            Policy = AllowAllPolicy.Name
        });
        _unitOfWork.Commit();
        _logger.LogInformation("Book {bookId} add a cover", request.BookId);
        return Task.FromResult(Unit.Value);
    }
}
