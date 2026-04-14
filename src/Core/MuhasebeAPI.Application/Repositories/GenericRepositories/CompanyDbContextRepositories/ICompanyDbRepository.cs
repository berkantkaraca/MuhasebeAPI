using Microsoft.EntityFrameworkCore;
using MuhasebeAPI.Domain.Abstractions;

namespace MuhasebeAPI.Application.Repositories.GenericRepositories.CompanyDbContextRepositories;

public interface ICompanyDbRepository<T> : IRepository<T>
    where T : BaseEntity
{
    void SetDbContextInstance(DbContext context);
}
