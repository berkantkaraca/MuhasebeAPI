using Moq;
using MuhasebeAPI.Application.Features.AppFeatures.MainRoleFeatures.Commands.CreateMainRole;
using MuhasebeAPI.Application.Services.AppServices;
using MuhasebeAPI.Domain.Entities.App;
using Shouldly;

namespace MuhasebeAPI.UnitTest.Features.AppFeatures.MainRoleFeatures;

public sealed class CreateMainRoleCommandUnitTest
{
    private readonly Mock<IMainRoleService> _mainRoleService;

    public CreateMainRoleCommandUnitTest()
    {
        _mainRoleService = new();
    }

    [Fact]
    public async Task MainRoleShouldBeNull()
    {
        MainRole mainRole = await _mainRoleService.Object.GetByTitleAndCompanyIdAsync(
            title: "Admin",
            companyId: "585985c0-4576-4d62-ae67-59a6f72ae906",
            default
        );

        mainRole.ShouldBeNull();
    }

    [Fact]
    public async Task CreateMainRoleCommandResponseShouldNotBeNull()
    {
        var command = new CreateMainRoleCommandRequest(
            Title: "Admin",
            CompanyId: "585985c0-4576-4d62-ae67-59a6f72ae906"
        );

        var handler = new CreateMainRoleCommandHandler(_mainRoleService.Object);

        CreateMainRoleCommandResponse response = await handler.Handle(command, default);
        response.ShouldNotBeNull();
        response.Message.ShouldNotBeEmpty();
    }
}
