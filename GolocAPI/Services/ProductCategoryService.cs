using AutoMapper;
using GolocAPI.Entities;
using GolocAPI.Models;
using Infrastructure.Repositories;

namespace GolocAPI.Services
{
    public interface IProductCategoryService
    {
        Task AddCategory(ProductCategoryPostModel categoryPostModel);
        List<ProductCategoryModel> GetAll();
    }
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ProductCategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task AddCategory(ProductCategoryPostModel categoryPostModel)
        {
            await unitOfWork.ProductCategoryRepository.Create(mapper.Map<ProductCategory>(categoryPostModel));
            await unitOfWork.Save();
        }

        public List<ProductCategoryModel> GetAll()
        {
            return unitOfWork.ProductCategoryRepository.GetAll().Select(pc => mapper.Map<ProductCategoryModel>(pc)).ToList();
            
        }
    }
}
