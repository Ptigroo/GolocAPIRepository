using GolocAPI.Models;
using MediatR;

namespace GolocAPI.CommandsAndQueries;
public record GetProductCategoryByIdQuery(Guid id) : IRequest<ProductCategoryModel>;
