using MediatR;
using MuhasebeAPI.Presentation.Abstraction; 

namespace MuhasebeAPI.Presentation.Controller;

public class MainRoleAndUserRelationshipsController : ApiController
{
    public MainRoleAndUserRelationshipsController(IMediator mediator) : base(mediator)  { }
}
