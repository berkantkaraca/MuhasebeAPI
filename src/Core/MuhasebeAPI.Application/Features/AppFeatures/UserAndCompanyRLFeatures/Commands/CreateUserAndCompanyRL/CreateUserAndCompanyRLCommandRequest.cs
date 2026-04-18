using MuhasebeAPI.Application.Messaging.Command;

namespace MuhasebeAPI.Application.Features.AppFeatures.UserAndCompanyRLFeatures.Commands.CreateUserAndCompanyRL;

public sealed record CreateUserAndCompanyRLCommandRequest(
    string AppUserId,
    string CompanyId
) : ICommand<CreateUserAndCompanyRLCommandResponse>;

