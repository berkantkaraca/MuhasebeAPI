using MuhasebeAPI.Domain.Entities.App;

namespace MuhasebeAPI.Application.Features.AppFeatures.CompanyFeatures.Queries.GetAllCompany;

public sealed record GetAllCompanyQueryResponse(List<Company> Companies);
