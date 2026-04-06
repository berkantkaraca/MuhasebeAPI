using Moq;
using MuhasebeAPI.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;
using MuhasebeAPI.Application.Services.AppServices;
using MuhasebeAPI.Domain.Entities.App;
using Shouldly;

namespace MuhasebeAPI.UnitTest.Features.AppFeatures.CompanyFeatures.Commands;

public sealed class CreateCompanyCommandUnitTest
{
    private readonly Mock<ICompanyService> _companyService;

    public CreateCompanyCommandUnitTest()
    {
        _companyService = new();
    }

    [Fact]
    public async Task CompanyShouldBeNull()
    {
        Company company = (await _companyService.Object.GetCompanyByName("Karaca Ltd Şti"))!;
        company.ShouldBeNull();
    }

    [Fact]
    public async Task CreateCompanyCommandResponseShouldNotBeNull()
    {
        CreateCompanyCommandRequest command = new CreateCompanyCommandRequest(
           Name: "Karaca Ltd Şti",
           ServerName: "localhost",
           DatabaseName: "KaracaMuhasebeDb",
           UserId: "",
           Password: ""
        );

        CreateCompanyCommandHandler handler = new CreateCompanyCommandHandler(_companyService.Object);

        CreateCompanyCommandResponse response = await handler.Handle(command, default);
        response.ShouldNotBeNull();
        response.Message.ShouldNotBeEmpty();
    }
}
