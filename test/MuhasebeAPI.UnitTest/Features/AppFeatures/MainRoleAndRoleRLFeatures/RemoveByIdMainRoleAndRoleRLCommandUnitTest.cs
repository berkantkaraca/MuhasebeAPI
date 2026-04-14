using Moq;
using MuhasebeAPI.Application.Features.AppFeatures.MainRoleAndRoleRLFeatures.Commands.RemoveByIdMainRoleAndRoleRL;
using MuhasebeAPI.Application.Services.AppServices;
using MuhasebeAPI.Domain.Entities.App;
using Shouldly;

namespace MuhasebeAPI.UnitTest.Features.AppFeatures.MainRoleAndRoleRLFeatures;

public sealed class RemoveByIdMainRoleAndRoleRLCommandUnitTest
{
    private readonly Mock<IMainRoleAndRoleRelationshipService> _serviceMock;

    public RemoveByIdMainRoleAndRoleRLCommandUnitTest()
    {
        _serviceMock = new();
    }

    [Fact]
    public async Task MainRoleAndRoleRelationshipShouldNotBeNull()
    {
        _serviceMock.Setup(s=> s.GetByIdAsync(It.IsAny<string>()))
            .ReturnsAsync(new MainRoleAndRoleRelationship());
    }

    [Fact]
    public async Task RemoveByIdMainRoleAndRoleRLCommandResponseShouldNotBeNull()
    {
        RemoveByIdMainRoleAndRoleRLCommandRequest removeByIdMainRoleAndRoleRLCommand = new(Id: "58986c90-54d0-4f21-968e-c10b30bfee66");

        RemoveByIdMainRoleAndRoleRLCommandHandler handler = new(_serviceMock.Object);

        _serviceMock.Setup(s => s.GetByIdAsync(It.IsAny<string>()))
           .ReturnsAsync(new MainRoleAndRoleRelationship());

        RemoveByIdMainRoleAndRoleRLCommandResponse response = await handler.Handle(removeByIdMainRoleAndRoleRLCommand, default);
        response.ShouldNotBeNull();
        response.Message.ShouldNotBeEmpty();
    }
}
