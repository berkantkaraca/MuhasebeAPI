using Moq;
using MuhasebeAPI.Application.Features.AppFeatures.MainRoleFeatures.Commands.RemoveByIdMainRole;
using MuhasebeAPI.Application.Services.AppServices;
using Shouldly;

namespace MuhasebeAPI.UnitTest.Features.AppFeatures.MainRoleFeatures;

public sealed class RemoveByIdMainRoleCommandUnitTest
{
    private readonly Mock<IMainRoleService> _mainRoleService;

    public RemoveByIdMainRoleCommandUnitTest()
    {
        _mainRoleService = new();
    }

    [Fact]
    public async Task RemoveByIdMainRoleCommandResponseShouldNotBeNull()
    {
        var command = new RemoveByIdMainRoleCommandRequest(Id: "585985c0-4576-4d62-ae67-59a6f72ae906");
        var handler = new RemoveByIdMainRoleCommandHandler(_mainRoleService.Object);

        RemoveByIdMainRoleCommandResponse response = await handler.Handle(command, default);
        response.ShouldNotBeNull();
        response.Message.ShouldNotBeEmpty();
    }
}
