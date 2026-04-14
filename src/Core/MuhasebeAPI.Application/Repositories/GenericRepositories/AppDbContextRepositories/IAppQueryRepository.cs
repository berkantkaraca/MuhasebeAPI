using MuhasebeAPI.Domain.Abstractions;

namespace MuhasebeAPI.Application.Repositories.GenericRepositories.AppDbContextRepositories;

public interface IAppQueryRepository<T> : IRepository<T>, IQueryRepository<T>
    where T : BaseEntity
{
}
