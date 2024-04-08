using GolocAPI.CommandsAndQueries.Authentication;
using GolocAPI.Entities;
using GolocAPI.Services;
using Infrastructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace GolocAPI.Handlers;
public class RegisterCommandHandler(IUnitOfWork unitOfWork, TokenService tokenService, UserManager<User> userManager) : IRequestHandler<RegisterCommand, Unit>
{
    public async Task<Unit> Handle(RegisterCommand registerQuery, CancellationToken cancellationToken)
    {
        User user = new()
        {
            Pseudo = registerQuery.Pseudo,
            UserName = registerQuery.Login,
            Email = registerQuery.Login,
        };
        await unitOfWork.UserRepository.Register(user, registerQuery.Password);
        return Unit.Value;
    }
}
