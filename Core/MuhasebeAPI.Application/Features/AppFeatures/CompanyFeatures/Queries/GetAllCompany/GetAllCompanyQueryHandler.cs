using Microsoft.EntityFrameworkCore;
using MuhasebeAPI.Application.Messaging.Query;
using MuhasebeAPI.Application.Services.AppServices;

namespace MuhasebeAPI.Application.Features.AppFeatures.CompanyFeatures.Queries.GetAllCompany;

public sealed class GetAllCompanyQueryHandler : IQueryHander<GetAllCompanyQueryRequest, GetAllCompanyQueryResponse>
{
    private readonly ICompanyService _companyService;

    public GetAllCompanyQueryHandler(ICompanyService companyService)
    {
        _companyService = companyService;
    }

    public async Task<GetAllCompanyQueryResponse> Handle(GetAllCompanyQueryRequest request, CancellationToken cancellationToken)
    {
        return new GetAllCompanyQueryResponse(await _companyService.GetAll().ToListAsync());
    }
}
