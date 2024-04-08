using GolocAPI.Models;
using MediatR;

namespace GolocAPI.CommandsAndQueries;

public record GetAllRentsQuery(string UserId) : IRequest<List<RentModel>>;
