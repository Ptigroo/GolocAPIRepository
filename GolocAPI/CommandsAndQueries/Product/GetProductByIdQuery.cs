using GolocAPI.Models;
using MediatR;

namespace GolocAPI.CommandsAndQueries;

public record GetProductByIdQuery(Guid Id) : IRequest<ProductModel>;
