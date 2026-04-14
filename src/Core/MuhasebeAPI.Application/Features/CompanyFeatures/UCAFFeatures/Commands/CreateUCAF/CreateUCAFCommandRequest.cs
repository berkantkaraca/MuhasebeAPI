using MediatR;
using MuhasebeAPI.Application.Messaging.Command;

namespace MuhasebeAPI.Application.Features.CompanyFeatures.UCAFFeatures.Commands.CreateUCAF;

public sealed record CreateUCAFCommandRequest(
    string Code,
    string Name,
    string Type,
    string CompanyId
) : ICommand<CreateUCAFCommandResponse>;
