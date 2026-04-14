using MuhasebeAPI.Domain.Entities.App;
using MuhasebeAPI.Persistence.Repositories.GenericRepositories.AppDbContextRepositories;
using MuhasebeAPI.Persistence.Contexts;
using MuhasebeAPI.Application.Repositories.AppDbContextRepositories.UserAndCompanyRelationshipRepositories;
namespace MuhasebeAPI.Persistence.Repositories.AppDbContextRepositories.UserAndCompanyRelationshipRepositories;

public class UserAndCompanyRelationshipQueryRepository : AppQueryRepository<UserAndCompanyRelationship>, IUserAndCompanyRelationshipQueryRepository
{
    public UserAndCompanyRelationshipQueryRepository(AppDbContext context) : base(context)
    {
    }
}
