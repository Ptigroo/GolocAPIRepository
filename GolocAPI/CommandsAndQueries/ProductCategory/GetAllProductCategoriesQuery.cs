using GolocAPI.Models;
using MediatR;

namespace GolocAPI.CommandsAndQueries;

public record GetAllProductCategoriesQuery() : IRequest<List<ProductCategoryModel>>;
