using Moq;
using MuhasebeAPI.Application.Features.AppFeatures.RoleFeatures.Commands.CreateRole;
using MuhasebeAPI.Application.Services.AppServices;
using MuhasebeAPI.Domain.Entities.App.Identity;
using Shouldly;

namespace MuhasebeAPI.UnitTest.Features.AppFeatures.RoleFeatures;

public sealed class CreateRoleCommandUnitTest
{
    private readonly Mock<IRoleService> _roleServiceMock;

    public CreateRoleCommandUnitTest()
    {
        _roleServiceMock = new();
    }

    [Fact]
    public async Task AppRoleShouldBeNull()
    {
        AppRole? appRole = await _roleServiceMock.Object.GetByCode("UCAF.Create");
        appRole.ShouldBeNull();
    }

    [Fact]
    public async Task CreateRoleCommandResponseShouldNotBeNull()
    {
        var command = new CreateRoleCommandRequest(
            Code: "UCAF.Create",
            Name: "Hesap Planı Kayıt Ekleme"
        );

        var handler = new CreateRoleCommandHandler(_roleServiceMock.Object);

        CreateRoleCommandResponse response = await handler.Handle(command, default);
        response.ShouldNotBeNull();
        response.Message.ShouldNotBeEmpty();
    }
}
