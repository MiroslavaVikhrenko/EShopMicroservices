using MediatR;

namespace BuildingBlocks.CQRS
{
    public interface ICommand : ICommand<Unit> // Empty Command - does NOT return any response
    {

    }
    public interface ICommand<out TResponse> : IRequest<TResponse> // Producing response (TResponse)
    {
    }
}
