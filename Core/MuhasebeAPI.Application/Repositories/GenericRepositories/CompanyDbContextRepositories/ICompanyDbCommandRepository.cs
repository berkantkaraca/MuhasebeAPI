using MuhasebeAPI.Domain.Abstractions;

namespace MuhasebeAPI.Application.Repositories.GenericRepositories.CompanyDbContextRepositories;

public interface ICompanyDbCommandRepository<T> : ICompanyDbRepository<T>, ICommandRepository<T>
    where T : BaseEntity
{   
}
