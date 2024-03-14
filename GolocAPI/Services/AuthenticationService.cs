using AutoMapper;
using GolocAPI.Entities;
using GolocAPI.Models;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;

namespace GolocAPI.Services
{
    public interface IAuthenticationService
    {
        Task<TokenModel> Login(LoginModel login);
        Task<TokenModel> Register(RegisterModel register);
        List<UserModel> ListUsers();
    }
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<User> _manager;
        private readonly TokenService _tokenService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper mapper;

        public AuthenticationService(UserManager<User> manager, TokenService tokenService, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _manager = manager;
            _tokenService = tokenService;
            this._unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<TokenModel> Login(LoginModel login)
        {
            var user = await _unitOfWork.UserRepository.Login(login);
            if (user == null)
            {
                throw new Exception("User doesn't exist");
            }
            if (!await _manager.CheckPasswordAsync(user, login.Password))
            {
                throw new Exception("Credentials incorrect");
            }
            return new TokenModel{ Token = await _tokenService.GenerateToken(user) };
        }
        public async Task<TokenModel> Register(RegisterModel register)
        {
            var user = new User
            {
                Pseudo = register.Pseudo,
                UserName = register.Login,
                Email = register.Login,
            };
             await _unitOfWork.UserRepository.Register(user, register.Password);

            return await Login(new LoginModel
            {
                Login = register.Login,
                Password = register.Password
            });
        }
        public List<UserModel> ListUsers()
        {
            return _unitOfWork.UserRepository.GetAll().Select(u => mapper.Map<UserModel>(u)).ToList();

        }
    }
}
