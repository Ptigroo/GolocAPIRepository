using AutoMapper;
using GolocAPI.Entities;
using GolocSharedLibrary.Models;

namespace GolocAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserModel>().ReverseMap();
        }
    }
}
