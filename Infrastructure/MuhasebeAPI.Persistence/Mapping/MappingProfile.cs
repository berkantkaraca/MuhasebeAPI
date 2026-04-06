using AutoMapper;
using MuhasebeAPI.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;
using MuhasebeAPI.Application.Features.AppFeatures.RoleFeatures.Commands.CreateRole;
using MuhasebeAPI.Application.Features.CompanyFeatures.UCAFFeatures.Commands.CreateUCAF;
using MuhasebeAPI.Domain.Entities.App;
using MuhasebeAPI.Domain.Entities.App.Identity;
using MuhasebeAPI.Domain.Entities.Company;

namespace MuhasebeAPI.Persistence.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateCompanyRequest, Company>();
        CreateMap<CreateUCAFRequest, UniformChartOfAccount>();
        CreateMap<CreateRoleRequest, AppRole>();
    }
}
