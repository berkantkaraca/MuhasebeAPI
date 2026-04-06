using MuhasebeAPI.Application.Messaging.Command;
using MuhasebeAPI.Application.Services.AppServices;

namespace MuhasebeAPI.Application.Features.AppFeatures.CompanyFeatures.Commands.MigrateCompanyDatabases;

public sealed class MigrateCompanyDatabasesCommandHandler : ICommandHandler<MigrateCompanyDatabasesCommandRequest, MigrateCompanyDatabasesCommandResponse>
{
    private readonly ICompanyService _companyService;

    public MigrateCompanyDatabasesCommandHandler(ICompanyService companyService)
    {
        _companyService = companyService;
    }

    public async Task<MigrateCompanyDatabasesCommandResponse> Handle(MigrateCompanyDatabasesCommandRequest request, CancellationToken cancellationToken)
    {
        await _companyService.MigrateCompanyDatabases();
        return new();
    }
}

