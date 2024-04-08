using GolocAPI.Models;
using MediatR;

namespace GolocAPI.CommandsAndQueries;

public record GetAllProductsQuery() : IRequest<List<ProductModel>>;
