using MuhasebeAPI.Application.Repositories.UCAFRepositories;
using MuhasebeAPI.Domain.Entities.Company;

namespace MuhasebeAPI.Persistence.Repositories.UCAFRepositories;

public sealed class UCAFCommandRepository : CommandRepository<UniformChartOfAccount>, IUCAFCommandRepository
{
}
