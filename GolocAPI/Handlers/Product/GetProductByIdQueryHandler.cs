using AutoMapper;
using GolocAPI.CommandsAndQueries;
using GolocAPI.Entities;
using GolocAPI.Models;
using Infrastructure.Repositories;
using MediatR;

namespace GolocAPI.Handlers;
public class GetProductByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetProductByIdQuery, ProductModel>
{
    public async Task<ProductModel> Handle(GetProductByIdQuery productQuery, CancellationToken cancellationToken)
    {
        Product product = await unitOfWork.ProductRepository.GetById(productQuery.Id);
        return mapper.Map<ProductModel>(product);
    }
}
