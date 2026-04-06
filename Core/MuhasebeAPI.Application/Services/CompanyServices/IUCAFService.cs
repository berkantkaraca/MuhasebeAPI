using MuhasebeAPI.Application.Features.CompanyFeatures.UCAFFeatures.Commands.CreateUCAF;

namespace MuhasebeAPI.Application.Services.CompanyServices;

public interface IUCAFService
{
    Task CreateUcafAsync(CreateUCAFCommandRequest request);
}
