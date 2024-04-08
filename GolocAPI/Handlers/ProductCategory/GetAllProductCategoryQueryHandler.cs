using AutoMapper;
using GolocAPI.Models;
using Infrastructure.Repositories;
using MediatR;

namespace GolocAPI.Handlers;

public class GetAllProductCategoryRequest : IRequest<List<ProductCategoryModel>>
{
}
public class GetAllProductCategoryQueryHandler(IMapper mapper, IUnitOfWork unitOfWork) : IRequestHandler<GetAllProductCategoryRequest, List<ProductCategoryModel>>
{
    public async Task<List<ProductCategoryModel>> Handle(GetAllProductCategoryRequest request, CancellationToken cancellationToken)
    {
        return (await unitOfWork.ProductCategoryRepository.GetAll()).Select(pc => mapper.Map<ProductCategoryModel>(pc)).ToList();
    }
}
