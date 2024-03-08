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
            CreateMap<Product, ProductModel>().AfterMap((product, model)=> model.Owner = new UserModel() { Id = product.Owner.Id,}).ReverseMap();
            CreateMap<Product, ProductPostModel>().ReverseMap();
            CreateMap<ProductCategory, ProductCategoryModel>().ReverseMap();
            CreateMap<ProductCategory, ProductCategoryPostModel>().ReverseMap();
        }
    }
}
