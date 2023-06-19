using API.UseCases.Attaches.Download;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AttachController : ControllerBase
{
    private readonly IMediator _mediator;

    public AttachController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// 下载附件
    /// </summary>
    [Route("{id}")]
    [HttpGet]
    public async Task DownloadAttach([FromRoute]int id)
    {
        await _mediator.Send(new DownloadAttachRequest
        {
            AttachId = id
        });
    }

}
