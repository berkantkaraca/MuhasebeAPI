using MediatR;
using Microsoft.AspNetCore.Mvc;
using MuhasebeAPI.Application.Features.AppFeatures.UserAndCompanyRLFeatures.Commands.CreateUserAndCompanyRL;
using MuhasebeAPI.Application.Features.AppFeatures.UserAndCompanyRLFeatures.Commands.RemoveByIdUserAndCompanyRL;
using MuhasebeAPI.Presentation.Abstraction; 

namespace MuhasebeAPI.Presentation.Controller;

public class UserAndCompanyRelationshipsController : ApiController
{
    public UserAndCompanyRelationshipsController(IMediator mediator) : base(mediator)  { }

    [HttpPost("[action]")]
    public async Task<IActionResult> Create(CreateUserAndCompanyRLCommandRequest request, CancellationToken cancellationToken)
    {
        CreateUserAndCompanyRLCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpDelete("[action]")]
    public async Task<IActionResult> RemoveById(RemoveByIdUserAndCompanyRLCommandRequest request)
    {
        RemoveByIdUserAndCompanyRLCommandResponse response = await _mediator.Send(request);
        return Ok(response);
    }
}
