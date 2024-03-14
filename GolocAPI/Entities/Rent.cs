using GolocAPI.Entities.Common;
namespace GolocAPI.Entities;
public class Rent : BaseEntity
{
    public Guid ProductId { get; set; }
    public Product Product { get; set; }
    public String RenterId { get; set; }
    public User Renter { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public double Price { get; set; }
    public List<ChatMessage> Messages { get; set; }
}
