using MediatR;

namespace MuhasebeAPI.Application.Messaging.Query;

public interface IQueryHander<in TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
    where TQuery : IQuery<TResponse>
{
}
