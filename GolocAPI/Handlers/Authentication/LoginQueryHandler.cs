using GolocAPI.CommandsAndQueries.Authentication;
using GolocAPI.Entities;
using GolocAPI.Models;
using GolocAPI.Services;
using Infrastructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace GolocAPI.Handlers;
public class LoginQueryHandler(IUnitOfWork unitOfWork, TokenService tokenService, UserManager<User> userManager) : IRequestHandler<LoginQuery, TokenModel>
{
    public async Task<TokenModel> Handle(LoginQuery loginQuery, CancellationToken cancellationToken)
    {

        var user = await unitOfWork.UserRepository.Login(loginQuery);
        if (user == null)
        {
            throw new Exception("User doesn't exist");
        }
        if (!await userManager.CheckPasswordAsync(user, loginQuery.Password))
        {
            throw new Exception("Credentials incorrect");
        }
        return new TokenModel { Token = await tokenService.GenerateToken(user) };
    }
}
