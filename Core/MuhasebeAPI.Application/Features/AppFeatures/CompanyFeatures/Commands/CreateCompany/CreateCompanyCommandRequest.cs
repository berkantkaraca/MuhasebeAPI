using MuhasebeAPI.Application.Messaging.Command;

namespace MuhasebeAPI.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;

public sealed record CreateCompanyCommandRequest(
        string Name,
        string ServerName,
        string DatabaseName,
        string UserId,
        string Password
) : ICommand<CreateCompanyCommandResponse>;
