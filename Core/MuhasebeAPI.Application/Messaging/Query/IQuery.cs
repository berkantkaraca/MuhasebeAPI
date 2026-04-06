using MediatR;

namespace MuhasebeAPI.Application.Messaging.Query;

public interface IQuery<out TResponse> : IRequest<TResponse>
{
}
