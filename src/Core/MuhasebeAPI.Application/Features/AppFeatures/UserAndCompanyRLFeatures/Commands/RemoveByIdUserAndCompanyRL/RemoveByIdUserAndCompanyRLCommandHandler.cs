using MuhasebeAPI.Application.Messaging.Command;
using MuhasebeAPI.Application.Services.AppServices;

namespace MuhasebeAPI.Application.Features.AppFeatures.UserAndCompanyRLFeatures.Commands.RemoveByIdUserAndCompanyRL;

public sealed class RemoveByIdUserAndCompanyRLCommandHandler : ICommandHandler<RemoveByIdUserAndCompanyRLCommandRequest, RemoveByIdUserAndCompanyRLCommandResponse>
{
    private readonly IUserAndCompanyRelationshipService _service;

    public RemoveByIdUserAndCompanyRLCommandHandler(IUserAndCompanyRelationshipService service)
    {
        _service = service;
    }

    public async Task<RemoveByIdUserAndCompanyRLCommandResponse> Handle(RemoveByIdUserAndCompanyRLCommandRequest request, CancellationToken cancellationToken)
    {
        await _service.RemoveByIdAsync(request.Id);
        return new();
    }
}
