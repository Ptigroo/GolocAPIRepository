using GolocAPI.Models;
using MediatR;
namespace GolocAPI.CommandsAndQueries;

public record GetAllProductPaginatedQuery (int pageNumber, int pageSize) : IRequest<PaginatedList<ProductModel>>;
