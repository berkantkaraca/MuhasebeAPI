using MuhasebeAPI.Domain.Abstractions;
using System.Linq.Expressions;

namespace MuhasebeAPI.Application.Repositories.GenericRepositories;

public interface IQueryRepository<T> where T : BaseEntity
{
    IQueryable<T> GetAll(bool tracking = true);
    IQueryable<T> GetWhere(Expression<Func<T, bool>> expression, bool tracking = true);
    Task<T?> GetByIdAsync(string id, bool tracking = true);
    Task<T?> GetFirstByExpiressionAsync(Expression<Func<T, bool>> expression, bool tracking = true);
    Task<T?> GetFirstAsync(bool tracking = true);
}
