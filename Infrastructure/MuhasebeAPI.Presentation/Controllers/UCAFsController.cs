using MediatR;
using Microsoft.AspNetCore.Mvc;
using MuhasebeAPI.Application.Features.CompanyFeatures.UCAFFeatures.Commands.CreateUCAF;
using MuhasebeAPI.Presentation.Abstraction;

namespace OnlineMuhasebeServer.Presentation.Controller;

public sealed class UCAFsController : ApiController
{
    public UCAFsController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> CreateUCAF(CreateUCAFCommandRequest request)
    {
        CreateUCAFCommandResponse response = await _mediator.Send(request);
        return Ok(response);
    }
}
