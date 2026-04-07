using Microsoft.EntityFrameworkCore;
using MuhasebeAPI.Domain.Abstractions;

namespace MuhasebeAPI.Application.Repositories.GenericRepositories;

public interface IRepository<T> where T : BaseEntity
{
    DbSet<T> Table  { get; set; }
}
 