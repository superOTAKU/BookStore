using API.Commons.Consts;
using API.Infrastructures.Exceptions;
using API.Modules.AclModule;
using API.Modules.AttachModule;
using MediatR;
using System.Net;

namespace API.UseCases.Attaches.Download;

public class DownloadAttachRequestHandler : IRequestHandler<DownloadAttachRequest, Unit>
{
    private readonly IAttachRepository _attachRepository;
    private readonly IStorageProtocolLoader _storageProtocolLoader;
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly IAclService _aclService;
    public DownloadAttachRequestHandler(IAttachRepository attachRepository, 
        IStorageProtocolLoader storageProtocolLoader, 
        IHttpContextAccessor httpContextAccessor,
        IAclService aclService)
    {
        _attachRepository = attachRepository;
        _storageProtocolLoader = storageProtocolLoader;
        _contextAccessor = httpContextAccessor;
        _aclService = aclService;
    }

    public Task<Unit> Handle(DownloadAttachRequest request, CancellationToken cancellationToken)
    {
        var attach = _attachRepository.GetById(request.AttachId)
            ?? throw new RestException(ErrorCodes.AuthorNotFound, HttpStatusCode.NotFound);
        _aclService.AccessControl(AclEntityTypes.Attach, attach.Id.ToString());
        var storageProtocol = _storageProtocolLoader.Load(attach.StorageProtocol)
            ?? throw new ArgumentNullException(nameof(attach.StorageProtocol));
        var response = _contextAccessor.HttpContext?.Response 
            ?? throw new ArgumentNullException("response not found");
        response.ContentType = attach.MimeType;
        using var stream = storageProtocol.Load(attach.StorageUrl);
        stream.CopyTo(response.Body);
        return Task.FromResult(Unit.Value);
    }
}
