using MediatR;
using Microsoft.AspNetCore.Mvc;
using MuhasebeAPI.Application.Features.AppFeatures.MainRoleAndRoleRLFeatures.Commands.CreateMainRoleAndRoleRL;
using MuhasebeAPI.Application.Features.AppFeatures.MainRoleAndRoleRLFeatures.Commands.RemoveByIdMainRoleAndRoleRL;
using MuhasebeAPI.Application.Features.AppFeatures.MainRoleAndRoleRLFeatures.Queries;
using MuhasebeAPI.Presentation.Abstraction; 

namespace MuhasebeAPI.Presentation.Controller;

public class MainRoleAndRoleRelationshipsController : ApiController
{
    public MainRoleAndRoleRelationshipsController(IMediator mediator) : base(mediator) { }

    [HttpPost("[action]")]
    public async Task<IActionResult> Create(CreateMainRoleAndRoleRLCommandRequest request, CancellationToken cancellationToken)
    {
        CreateMainRoleAndRoleRLCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpDelete("[action]")]
    public async Task<IActionResult> RemoveById(RemoveByIdMainRoleAndRoleRLCommandRequest request)
    {
        RemoveByIdMainRoleAndRoleRLCommandResponse response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetAll()
    {
        GetAllMainRoleAndRoleRLQueryResponse response = await _mediator.Send(new GetAllMainRoleAndRoleRLQueryRequest());
        return Ok(response);
    }
}
