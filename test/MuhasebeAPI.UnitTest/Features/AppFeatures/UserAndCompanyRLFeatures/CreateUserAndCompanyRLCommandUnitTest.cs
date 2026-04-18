using Moq;
using MuhasebeAPI.Application.Features.AppFeatures.UserAndCompanyRLFeatures.Commands.CreateUserAndCompanyRL;
using MuhasebeAPI.Application.Services.AppServices;
using MuhasebeAPI.Domain.Entities.App;
using Shouldly;

namespace MuhasebeAPI.UnitTest.Features.AppFeatures.UserAndCompanyRLFeatures;

public sealed class CreateUserAndCompanyRLCommandUnitTest
{
    private readonly Mock<IUserAndCompanyRelationshipService> _serviceMock;

    public CreateUserAndCompanyRLCommandUnitTest()
    {
        _serviceMock = new();
    }

    [Fact]
    public async Task UserAndCompanyRelationshipShouldBeNull()
    {
        UserAndCompanyRelationship userAndCompanyRelationship = await _serviceMock.Object.GetByUserIdAndCompanyIdAsync(
            userId: "735195e9-1ea9-4324-81b5-d33e53e1ffd2",
            companyId: "984795a4-fa9a-4ea0-8e42-b2652221aa98",
            cancellationToken: default
        );

        userAndCompanyRelationship.ShouldBeNull();
    }

    [Fact]
    public async Task CreateUserAndCompanyRLCommandResponseShouldNotBeNull()
    {
        CreateUserAndCompanyRLCommandRequest command = new(
            AppUserId: "735195e9-1ea9-4324-81b5-d33e53e1ffd2",
            CompanyId: "984795a4-fa9a-4ea0-8e42-b2652221aa98"
        );

        CreateUserAndCompanyRLCommandHandler handler = new(_serviceMock.Object);

        CreateUserAndCompanyRLCommandResponse response =  await handler.Handle(command, default);
        response.ShouldNotBeNull();
        response.Message.ShouldNotBeEmpty();
    }
}
