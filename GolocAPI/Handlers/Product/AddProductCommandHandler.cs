using AutoMapper;
using GolocAPI.CommandsAndQueries.Authentication;
using GolocAPI.CommandsAndQueries;
using GolocAPI.Entities;
using GolocAPI.Models;
using Infrastructure.Repositories;
using MediatR;
namespace GolocAPI.Handlers;
public class AddProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<AddProductCommand, ProductModel>
{
    public async Task<ProductModel> Handle(AddProductCommand productCommand, CancellationToken cancellationToken)
    {
        Product product =  await unitOfWork.ProductRepository.Create(mapper.Map<Product>(productCommand));
        await unitOfWork.Save(cancellationToken);
        return mapper.Map<ProductModel>(product);
    }
}
