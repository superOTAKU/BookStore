using API.UseCases.Books.Add;
using API.UseCases.Books.AddCover;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    private readonly IMediator _mediator;

    public BookController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<AddBookResult> AddBook([FromBody]AddBookCommand command)
    {
        return await _mediator.Send(command);
    }

    [HttpPost]
    [Route("{id}/cover")]
    public async Task<Unit> AddBookCover([FromRoute]int id, IFormFile file)
    {
        return await _mediator.Send(new AddBookCoverComand
        {
            BookId = id,
            CoverFile = file
        });
    }


}
