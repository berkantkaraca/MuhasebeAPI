using AutoMapper;
using MuhasebeAPI.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;
using MuhasebeAPI.Domain.Entities.App;

namespace MuhasebeAPI.Persistence.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateCompanyRequest, Company>().ReverseMap();
    }
}
