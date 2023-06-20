using API.Modules.AttachModule.Dtos;
using MediatR;

namespace API.UseCases.Attaches.GetMataList;

public class GetAttachListRequest : IRequest<IEnumerable<AttachMetadata>>
{
    public string ComponentType { get; set; } = null!;

    public string ComponentId { get; set; } = null!;
}
