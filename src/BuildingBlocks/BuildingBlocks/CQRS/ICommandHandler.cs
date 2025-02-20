using MediatR;

namespace BuildingBlocks.CQRS
{
    public interface ICommandHandler<in TCommand> // Does NOT return any response
        : ICommandHandler<TCommand, Unit>
        where TCommand : ICommand<Unit>
    {

    }

    public interface ICommandHandler<in TCommand, TResponse> // Producing response (TResponse)
        : IRequestHandler<TCommand, TResponse>
        where TCommand : ICommand<TResponse>
        where TResponse : notnull
    {
    }
}
