using MuhasebeAPI.Application.Features.CompanyFeatures.UCAFFeatures.Commands.CreateUCAF;
using MuhasebeAPI.Domain.Entities.Company;

namespace MuhasebeAPI.Application.Services.CompanyServices;

public interface IUCAFService
{
    Task CreateUcafAsync(CreateUCAFCommandRequest request, CancellationToken cancellationToken);
    Task<UniformChartOfAccount> GetByCode(string code);
}
