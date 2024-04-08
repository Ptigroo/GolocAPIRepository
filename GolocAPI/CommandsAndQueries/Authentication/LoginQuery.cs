using GolocAPI.Models;
using MediatR;

namespace GolocAPI.CommandsAndQueries.Authentication;
public record LoginQuery(string Login, string Password) : IRequest<TokenModel>;
