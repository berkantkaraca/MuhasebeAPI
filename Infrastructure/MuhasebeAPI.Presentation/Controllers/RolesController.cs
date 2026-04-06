using MediatR;
using Microsoft.AspNetCore.Mvc;
using MuhasebeAPI.Application.Features.AppFeatures.RoleFeatures.Commands.CreateRole;
using MuhasebeAPI.Application.Features.AppFeatures.RoleFeatures.Commands.DeleteRole;
using MuhasebeAPI.Application.Features.AppFeatures.RoleFeatures.Commands.UpdateRole;
using MuhasebeAPI.Application.Features.AppFeatures.RoleFeatures.Queries.GetAllRoles;
using MuhasebeAPI.Presentation.Abstraction;

namespace MuhasebeAPI.Presentation.Controllers;

public class RolesController : ApiController
{
    public RolesController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> CreateRole(CreateRoleCommandRequest request)
    {
        CreateRoleCommandResponse response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetlAllRoles()
    {
        GetAllRolesQueryResponse response = await _mediator.Send(new GetAllRolesQueryRequest());
        return Ok(response);
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> UpdateRole(UpdateRoleRequest request)
    {
        UpdateRoleCommandResponse response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpDelete("[action]/{id}")]
    public async Task<IActionResult> DeleteRole(string id)
    {
        DeleteRoleCommandResponse response = await _mediator.Send(new DeleteRoleCommandRequest(id));
        return Ok(response);
    }
}
