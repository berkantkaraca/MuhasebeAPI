using MediatR;
using Microsoft.AspNetCore.Mvc;
using MuhasebeAPI.Application.Features.AppFeatures.MainRoleFeatures.Commands.CreateMainRole;
using MuhasebeAPI.Application.Features.AppFeatures.MainRoleFeatures.Commands.CreateStaticMainRoles;
using MuhasebeAPI.Application.Features.AppFeatures.MainRoleFeatures.Commands.RemoveByIdMainRole;
using MuhasebeAPI.Application.Features.AppFeatures.MainRoleFeatures.Commands.UpdateMainRole;
using MuhasebeAPI.Application.Features.AppFeatures.MainRoleFeatures.Queries.GetAllMainRole;
using MuhasebeAPI.Presentation.Abstraction;

namespace MuhasebeAPI.Presentation.Controllers;

public sealed class MainRolesController : ApiController
{
    public MainRolesController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Create(CreateMainRoleCommandRequest request, CancellationToken cancellationToken)
    {
        CreateMainRoleCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> CreateStaticMainRoles(CancellationToken cancellationToken)
    {
        CreateStaticMainRolesCommandResponse response = await _mediator.Send(new CreateStaticMainRolesCommandRequest(null), cancellationToken);
        return Ok(response);
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetAll()
    {
        GetAllMainRoleQueryResponse response = await _mediator.Send(new GetAllMainRoleQueryRequest());
        return Ok(response);
    }

    [HttpDelete("[action]")]
    public async Task<IActionResult> RemoveById(RemoveByIdMainRoleCommandRequest request)
    {
        RemoveByIdMainRoleCommandResponse response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> Update(UpdateMainRoleCommandRequest request)
    {
        UpdateMainRoleCommandResponse response = await _mediator.Send(request);
        return Ok(response);
    }
}
