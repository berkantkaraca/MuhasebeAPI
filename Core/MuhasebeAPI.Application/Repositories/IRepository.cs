using Microsoft.EntityFrameworkCore;
using MuhasebeAPI.Domain.Abstractions;

namespace MuhasebeAPI.Application.Repositories;

public interface IRepository<T> where T : BaseEntity
{
    void SetDbContextInstance(DbContext context);
    DbSet<T> Table  { get; set; }
}
