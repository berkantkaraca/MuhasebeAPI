using MuhasebeAPI.Domain.Abstractions;

namespace MuhasebeAPI.Application.Repositories.GenericRepositories;

public interface ICommandRepository<T> where T : BaseEntity
{
    Task AddAsync(T entity, CancellationToken cancellationToken);
    Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken);
    void Update(T entity);
    void UpdateRange(IEnumerable<T> entities);
    void Remove(T entity);
    Task RemoveAsync(string id);
    void RemoveRange(IEnumerable<T> entities);
    Task<int> SaveAsync();
}
