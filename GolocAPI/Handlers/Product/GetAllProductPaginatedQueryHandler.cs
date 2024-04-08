using AutoMapper;
using GolocAPI.CommandsAndQueries;
using GolocAPI.Entities;
using GolocAPI.Models;
using Infrastructure.Repositories;
using MediatR;
namespace GolocAPI.Handlers;
public class GetAllProductPaginatedQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetAllProductPaginatedQuery, PaginatedList<ProductModel>>
{
    public async Task<PaginatedList<ProductModel>> Handle(GetAllProductPaginatedQuery productQuery, CancellationToken cancellationToken)
    {
        PaginatedList<Product> products = unitOfWork.ProductRepository.GetAllPaginated(productQuery.pageNumber, productQuery
            .pageSize);
        return new PaginatedList<ProductModel>(products.Data.Select(p => mapper.Map<ProductModel>(p)).ToList(), products.TotalCount, products.CurrentPage, products.PageSize);
    }
}
