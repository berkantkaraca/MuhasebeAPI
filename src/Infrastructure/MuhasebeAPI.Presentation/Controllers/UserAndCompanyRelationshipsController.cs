using MediatR;
using MuhasebeAPI.Presentation.Abstraction; 

namespace MuhasebeAPI.Presentation.Controller;

public class UserAndCompanyRelationshipsController : ApiController
{
    public UserAndCompanyRelationshipsController(IMediator mediator) : base(mediator)  { }
}
