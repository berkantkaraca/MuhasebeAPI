using MuhasebeAPI.Domain.Entities.App;
using MuhasebeAPI.Persistence.Repositories.GenericRepositories.AppDbContextRepositories;
using MuhasebeAPI.Persistence.Contexts;
using MuhasebeAPI.Application.Repositories.AppDbContextRepositories.MainRoleAndUserRelationshipRepositories;
namespace MuhasebeAPI.Persistence.Repositories.AppDbContextRepositories.MainRoleAndUserRelationshipRepositories;

public class MainRoleAndUserRelationshipQueryRepository : AppQueryRepository<MainRoleAndUserRelationship>, IMainRoleAndUserRelationshipQueryRepository
{
    public MainRoleAndUserRelationshipQueryRepository(AppDbContext context) : base(context)
    {
    }
}
