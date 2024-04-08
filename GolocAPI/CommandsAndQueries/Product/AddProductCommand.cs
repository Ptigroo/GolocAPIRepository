using GolocAPI.CommandsAndQueries.Common;
using GolocAPI.Models;
using MediatR;
namespace GolocAPI.CommandsAndQueries;

public record AddProductCommand : ICommand<ProductModel>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public List<string> Images { get; set; }
    public double PricePerDay { get; set; }
    public Guid CategoryId { get; set; }
    public Guid OwnerId { get; set; }
}
