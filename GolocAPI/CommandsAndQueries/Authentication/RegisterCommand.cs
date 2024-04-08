using GolocAPI.CommandsAndQueries.Common;
using MediatR;
namespace GolocAPI.CommandsAndQueries.Authentication;

public record RegisterCommand(string Pseudo, string Login, string Password) : ICommand<Unit>;
