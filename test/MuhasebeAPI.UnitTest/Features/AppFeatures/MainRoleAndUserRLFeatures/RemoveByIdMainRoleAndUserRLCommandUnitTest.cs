using Moq;
using MuhasebeAPI.Application.Features.AppFeatures.MainRoleAndUserRLFeatures.Commands.RemoveByIdMainRoleAndUserRL;
using MuhasebeAPI.Application.Services.AppServices;
using MuhasebeAPI.Domain.Entities.App;
using Shouldly;

namespace MuhasebeAPI.UnitTest.Features.AppFeatures.MainRoleAndUserRLFeatures;

public sealed class RemoveByIdMainRoleAndUserRLCommandUnitTest
{
    private readonly Mock<IMainRoleAndUserRelationshipService> _serviceMock;

    public RemoveByIdMainRoleAndUserRLCommandUnitTest()
    {
        _serviceMock = new();
    }

    [Fact]
    public async Task MainRoleAndUserRelationshipShouldNotBeNull()
    {
        _serviceMock.Setup(x=> x.GetByIdAsync(It.IsAny<string>(),false))
            .ReturnsAsync(new MainRoleAndUserRelationship());
    }

    [Fact]
    public async Task RemoveByIdMainRoleAndUserRLCommandResponseShouldNotBeNull()
    {
        RemoveByIdMainRoleAndUserRLCommandRequest command = new(Id: "");

        RemoveByIdMainRoleAndUserRLCommandHandler handler = new(_serviceMock.Object);

        _serviceMock.Setup(x => x.GetByIdAsync(It.IsAny<string>(), false))
           .ReturnsAsync(new MainRoleAndUserRelationship());

        RemoveByIdMainRoleAndUserRLCommandResponse response = await handler.Handle(command, default);
        response.ShouldNotBeNull();
        response.Message.ShouldNotBeEmpty();
    }
}
