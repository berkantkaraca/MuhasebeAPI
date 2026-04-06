using MediatR;

namespace MuhasebeAPI.Application.Messaging.Command;

public interface ICommand<out TResponse> : IRequest<TResponse>
{
}
