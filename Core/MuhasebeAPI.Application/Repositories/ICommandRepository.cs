using MuhasebeAPI.Domain.Abstractions;

namespace MuhasebeAPI.Application.Repositories;

public interface ICommandRepository<T> : IRepository<T> where T : BaseEntity
{
    Task AddAsync(T entity);
    Task AddRangeAsync(IEnumerable<T> entities);
    void Update(T entity);
    void UpdateRange(IEnumerable<T> entities);
    void Remove(T entity);
    Task RemoveAsync(string id);
    void RemoveRange(IEnumerable<T> entities);
    Task<int> SaveAsync();
}
