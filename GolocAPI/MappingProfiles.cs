using AutoMapper;
using GolocAPI.Entities;
using GolocAPI.Models;

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
            CreateMap<Rent, RentModel>().AfterMap((rent, model) => { model.RenterName = rent.Renter.Pseudo;
                model.ProductName = rent.Product.Name;
                model.OwnerName = rent.Product.Owner.Pseudo;
                model.OwnerId = rent.Product.Owner.Id;
                if (rent.Messages != null)
                {
                    var modelMessages = new List<ChatMessageModel>();
                    foreach (var message in rent.Messages.OrderBy(message => message.CreationDate))
                    {
                        modelMessages.Add(new ChatMessageModel() { Message = message.Message, SenderId = message.SenderId });
                    }
                    model.ChatMessages = modelMessages;

                }
            });
            CreateMap<RentPostModel, Rent>();
            CreateMap<ChatMessageModel, ChatMessage>().ReverseMap();
        }
    }
}
