using AutoMapper;
using GolocAPI.CommandsAndQueries;
using GolocAPI.Models;
using Infrastructure.Repositories;
using MediatR;
namespace GolocAPI.Handlers;
public class GetAllProductsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetAllProductsQuery, List<ProductModel>>
{
    public async Task<List<ProductModel>> Handle(GetAllProductsQuery productQuery, CancellationToken cancellationToken)
    {
        return (await unitOfWork.ProductRepository.GetAll()).Select(p => mapper.Map<ProductModel>(p)).ToList();
    }
}
