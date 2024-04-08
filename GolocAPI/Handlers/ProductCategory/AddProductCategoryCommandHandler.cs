using AutoMapper;
using GolocAPI.Commands;
using GolocAPI.Entities;
using GolocAPI.Models;
using Infrastructure.Repositories;
using MediatR;
namespace GolocAPI.Handlers;
public class AddProductCategoryCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) : IRequestHandler<AddProductCategoryCommand, ProductCategoryModel>
{
    public async Task<ProductCategoryModel> Handle(AddProductCategoryCommand productCategory, CancellationToken cancellationToken)
    {
        return mapper.Map<ProductCategoryModel>(await unitOfWork.ProductCategoryRepository.Create(mapper.Map<ProductCategory>(productCategory)));
    }
}
