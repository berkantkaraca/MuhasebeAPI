using MuhasebeAPI.Domain.Abstractions;

namespace MuhasebeAPI.Application.Repositories.GenericRepositories.AppDbContextRepositories;

public interface IAppCommandRepository<T> : IRepository<T>, ICommandRepository<T>
    where T : BaseEntity
{
}
