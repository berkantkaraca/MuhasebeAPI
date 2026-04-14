using MuhasebeAPI.Application.Repositories.AppDbContextRepositories.MainRoleRepositories;
using MuhasebeAPI.Domain.Entities.App;
using MuhasebeAPI.Persistence.Contexts;
using MuhasebeAPI.Persistence.Repositories.GenericRepositories.AppDbContextRepositories;

namespace MuhasebeAPI.Persistence.Repositories.AppDbContextRepositories.MainRoleRepositories;

public sealed class MainRoleQueryRepository : AppQueryRepository<MainRole>, IMainRoleQueryRepository
{
    public MainRoleQueryRepository(AppDbContext context) : base(context)
    {
    }
}
