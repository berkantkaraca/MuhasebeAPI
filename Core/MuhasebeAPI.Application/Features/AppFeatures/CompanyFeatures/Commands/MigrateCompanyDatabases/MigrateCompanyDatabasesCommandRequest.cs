using MuhasebeAPI.Application.Messaging.Command;

namespace MuhasebeAPI.Application.Features.AppFeatures.CompanyFeatures.Commands.MigrateCompanyDatabases;

public sealed record MigrateCompanyDatabasesCommandRequest() : ICommand<MigrateCompanyDatabasesCommandResponse>;
