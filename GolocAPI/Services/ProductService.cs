using AutoMapper;
using GolocAPI.Entities;
using GolocSharedLibrary.Models;
using Infrastructure.Repositories;

namespace GolocAPI.Services
{
    public interface IProductService
    {
        Task AddProduct(ProductPostModel productPostModel); 
        Task<ProductModel> GetProduct();
        Task<List<ProductModel>> GetProducts();
    }
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task AddProduct(ProductPostModel productPostModel)
        {
            await unitOfWork.ProductRepository.Create(mapper.Map<Product>(productPostModel));
            await unitOfWork.Save();
        }

        public Task<ProductModel> GetProduct()
        {
            throw new NotImplementedException();
        }

        public async Task<List<ProductModel>> GetProducts()
        {
            return unitOfWork.ProductRepository.GetAll().Select(p => mapper.Map<ProductModel>(p)).ToList();
            
        }
    }
}
