using MediatR;

namespace API.UseCases.Attaches.Download;

public class DownloadAttachRequest : IRequest<Unit>
{
    public int AttachId { get; set; }
}
