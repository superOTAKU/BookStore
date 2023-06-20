using API.Commons.Consts;
using API.Modules.AclModule;
using API.Modules.AttachModule;
using API.Modules.AttachModule.Dtos;
using MediatR;

namespace API.UseCases.Attaches.GetMataList;

public class GetAttachListRequestHandler : IRequestHandler<GetAttachListRequest, IEnumerable<AttachMetadata>>
{
    private readonly IAttachRepository _repository;
    private readonly IAclService _aclService;

    public GetAttachListRequestHandler(IAttachRepository repository, IAclService aclService)
    {
        _repository = repository;
        _aclService = aclService;
    }
    public Task<IEnumerable<AttachMetadata>> Handle(GetAttachListRequest request, CancellationToken cancellationToken)
    {
        var attaches = _repository.GetList(request.ComponentType, request.ComponentId);
        foreach (var attach in attaches)
        {
            _aclService.AccessControl(AclEntityTypes.Attach, attach.Id.ToString());
        }
        //TODO 抽象mapper，以及extension object load...
        return Task.FromResult(attaches.Select(attach => new AttachMetadata
        {
            Id = attach.Id,
            Name = attach.Name,
            MimeType = attach.MimeType,
            Size = attach.Size
        }));
    }
}
