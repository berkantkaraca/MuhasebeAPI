using MuhasebeAPI.Application.Repositories.AppDbContextRepositories.MainRoleReporistories;
using MuhasebeAPI.Domain.Entities.App;
using MuhasebeAPI.Persistence.Contexts;
using MuhasebeAPI.Persistence.Repositories.GenericRepositories.AppDbContextRepositories;

namespace MuhasebeAPI.Persistence.Repositories.AppDbContextRepositories.MainRoleRepositories;

public sealed class MainRoleCommandRepository : AppCommandRepository<MainRole>, IMainRoleCommandRepository
{
    public MainRoleCommandRepository(AppDbContext context) : base(context) {}
}
