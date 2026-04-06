using MediatR;
using MuhasebeAPI.Application.Messaging.Command;
using MuhasebeAPI.Application.Services.CompanyServices;

namespace MuhasebeAPI.Application.Features.CompanyFeatures.UCAFFeatures.Commands.CreateUCAF;

public sealed class CreateUCAFCommandHandler : ICommandHandler<CreateUCAFCommandRequest, CreateUCAFCommandResponse>
{
    private readonly IUCAFService _ucafService;

    public CreateUCAFCommandHandler(IUCAFService ucafService)
    {
        _ucafService = ucafService;
    }

    public async Task<CreateUCAFCommandResponse> Handle(CreateUCAFCommandRequest request, CancellationToken cancellationToken)
    {
        await _ucafService.CreateUcafAsync(request);
        return new();
    }
}
