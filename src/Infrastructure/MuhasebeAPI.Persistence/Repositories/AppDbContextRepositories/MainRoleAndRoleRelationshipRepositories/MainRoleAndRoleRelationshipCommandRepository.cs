using MuhasebeAPI.Domain.Entities.App;
using MuhasebeAPI.Persistence.Repositories.GenericRepositories.AppDbContextRepositories;
using MuhasebeAPI.Persistence.Contexts;
using MuhasebeAPI.Application.Repositories.AppDbContextRepositories.MainRoleAndRoleRelationshipRepositories;
namespace MuhasebeAPI.Persistence.Repositories.AppDbContextRepositories.MainRoleAndRoleRelationshipRepositories;

public class MainRoleAndRoleRelationshipCommandRepository : AppCommandRepository<MainRoleAndRoleRelationship>, IMainRoleAndRoleRelationshipCommandRepository
{
    public MainRoleAndRoleRelationshipCommandRepository(AppDbContext context) : base(context)
    {
    }
}
