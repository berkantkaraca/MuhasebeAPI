using MediatR;
using Microsoft.AspNetCore.Mvc;
using MuhasebeAPI.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;
using MuhasebeAPI.Application.Features.AppFeatures.CompanyFeatures.Commands.MigrateCompanyDatabases;
using MuhasebeAPI.Application.Features.AppFeatures.CompanyFeatures.Queries.GetAllCompany;
using MuhasebeAPI.Presentation.Abstraction;

namespace MuhasebeAPI.Presentation.Controllers;

public class CompaniesController : ApiController
{
    public CompaniesController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> CreateCompany(CreateCompanyCommandRequest request, CancellationToken cancellationToken)
    {
        CreateCompanyCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> MigrateCompanyDatabases()
    {
        MigrateCompanyDatabasesCommandResponse response = await _mediator.Send(new MigrateCompanyDatabasesCommandRequest());
        return Ok(response);
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetAllCompany()
    {
        GetAllCompanyQueryResponse response = await _mediator.Send(new GetAllCompanyQueryRequest());
        return Ok(response);
    }
}
