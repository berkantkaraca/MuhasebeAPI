using Moq;
using MuhasebeAPI.Application.Features.CompanyFeatures.UCAFFeatures.Commands.CreateUCAF;
using MuhasebeAPI.Application.Services.CompanyServices;
using MuhasebeAPI.Domain.Entities.Company;
using Shouldly;

namespace MuhasebeAPI.UnitTest.Features.CompanyFeatures;

public sealed class CreateUCAFCommandUnitTest
{
    private readonly Mock<IUCAFService> _ucafService;

    public CreateUCAFCommandUnitTest()
    {
        _ucafService = new();
    }

    [Fact]
    public async Task UCAFShouldBeNull()
    {
        UniformChartOfAccount ucaf = await _ucafService.Object.GetByCode("100.01.001", default);
        ucaf.ShouldBeNull();
    }

    [Fact]
    public async Task CreateUCAFCommandResponseShouldNotBeNull()
    {
        var command = new CreateUCAFCommandRequest(
            Code: "100.01.001",
            Name: "TL Kasa",
            Type: "M",
            CompanyId: "585985c0-4576-4d62-ae67-59a6f72ae906"
        );

        var handler = new CreateUCAFCommandHandler(_ucafService.Object);

        CreateUCAFCommandResponse response = await handler.Handle(command, default);
        response.ShouldNotBeNull();
        response.Message.ShouldNotBeEmpty();
    }
}

