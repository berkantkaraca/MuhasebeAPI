using MuhasebeAPI.Application.Exceptions;
using MuhasebeAPI.Application.Messaging.Command;
using MuhasebeAPI.Application.Services.AppServices;
using MuhasebeAPI.Domain.Entities.App;

namespace MuhasebeAPI.Application.Features.AppFeatures.UserAndCompanyRLFeatures.Commands.CreateUserAndCompanyRL;

public sealed class CreateUserAndCompanyRLCommandHandler : ICommandHandler<CreateUserAndCompanyRLCommandRequest, CreateUserAndCompanyRLCommandResponse>
{
    private readonly IUserAndCompanyRelationshipService _userAndCompanyRelationshipService;

    public CreateUserAndCompanyRLCommandHandler(IUserAndCompanyRelationshipService userAndCompanyRelationshipService)
    {
        _userAndCompanyRelationshipService = userAndCompanyRelationshipService;
    }

    public async Task<CreateUserAndCompanyRLCommandResponse> Handle(CreateUserAndCompanyRLCommandRequest request, CancellationToken cancellationToken)
    {
        UserAndCompanyRelationship entity = await _userAndCompanyRelationshipService.GetByUserIdAndCompanyIdAsync(request.AppUserId, request.CompanyId, cancellationToken);

        if (entity != null)
            throw new ConflictException("Bu kullanıcı daha önce bu şirkete kayıt edilmiş!");

        UserAndCompanyRelationship userAndCompanyRelationship = new(
            Guid.NewGuid().ToString(),
            request.AppUserId,
            request.CompanyId
        );

        await _userAndCompanyRelationshipService.CreateAsync(userAndCompanyRelationship, cancellationToken);
        return new();
    }
}
