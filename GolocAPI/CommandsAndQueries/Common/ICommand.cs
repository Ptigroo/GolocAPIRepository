using MediatR;

namespace GolocAPI.CommandsAndQueries.Common;

public interface ICommand<T> : IRequest<T>
{
}
