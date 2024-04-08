using GolocAPI.CommandsAndQueries.Common;
using GolocAPI.Models;
using MediatR;
namespace GolocAPI.CommandsAndQueries.Authentication;

public record AddRentCommand(Guid ProductId, DateTime StartDate, DateTime EndDate, double Price, string FirstMessage) : ICommand<RentModel>
{
    public string RenterId { get; set; }
}
