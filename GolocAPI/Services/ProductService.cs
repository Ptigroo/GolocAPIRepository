using AutoMapper;
using GolocAPI.Entities;
using GolocAPI.Models;
using Infrastructure.Repositories;
namespace GolocAPI.Services;
public interface IProductService
{
    Task AddProduct(ProductPostModel productPostModel); 
    Task<ProductModel> GetProduct(Guid id);
    List<ProductModel> GetProducts();
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

    public async Task<ProductModel> GetProduct(Guid id)
    {
        Product product = await unitOfWork.ProductRepository.GetById(id);
        return mapper.Map<ProductModel>(product);
    }

    public List<ProductModel> GetProducts()
    {
        return unitOfWork.ProductRepository.GetAll().Select(p => mapper.Map<ProductModel>(p)).ToList();

    }
}
