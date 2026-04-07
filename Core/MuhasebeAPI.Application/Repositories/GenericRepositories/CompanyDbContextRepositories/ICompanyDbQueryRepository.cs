using MuhasebeAPI.Domain.Abstractions;

namespace MuhasebeAPI.Application.Repositories.GenericRepositories.CompanyDbContextRepositories;

public interface ICompanyDbQueryRepository<T> : ICompanyDbRepository<T>, IQueryRepository<T>
    where T : BaseEntity
{
}
