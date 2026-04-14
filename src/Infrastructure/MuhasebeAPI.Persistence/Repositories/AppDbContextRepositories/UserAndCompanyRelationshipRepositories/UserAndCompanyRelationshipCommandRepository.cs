using MuhasebeAPI.Domain.Entities.App;
using MuhasebeAPI.Persistence.Repositories.GenericRepositories.AppDbContextRepositories;
using MuhasebeAPI.Persistence.Contexts;
using MuhasebeAPI.Application.Repositories.AppDbContextRepositories.UserAndCompanyRelationshipRepositories;
namespace MuhasebeAPI.Persistence.Repositories.AppDbContextRepositories.UserAndCompanyRelationshipRepositories;

public class UserAndCompanyRelationshipCommandRepository : AppCommandRepository<UserAndCompanyRelationship>, IUserAndCompanyRelationshipCommandRepository
{
    public UserAndCompanyRelationshipCommandRepository(AppDbContext context) : base(context)
    {
    }
}
