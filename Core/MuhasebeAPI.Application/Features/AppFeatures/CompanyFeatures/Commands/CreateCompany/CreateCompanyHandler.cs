using MediatR;
using MuhasebeAPI.Application.Services.AppServices;
using MuhasebeAPI.Domain.Entities.App;

namespace MuhasebeAPI.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;

public sealed class CreateCompanyHandler : IRequestHandler<CreateCompanyRequest, CreateCompanyResponse>
{
    private readonly ICompanyService _companyService;

    public CreateCompanyHandler(ICompanyService companyService)
    {
        _companyService = companyService;
    }

    public async Task<CreateCompanyResponse> Handle(CreateCompanyRequest request, CancellationToken cancellationToken)
    {
        Company? company = await _companyService.GetCompanyByName(request.Name ?? string.Empty);

        if (company != null) 
            throw new Exception("Bu şirket adı daha önce kullanılmış!");

        await _companyService.CreateCompany(request);
        return new();
    }
}

