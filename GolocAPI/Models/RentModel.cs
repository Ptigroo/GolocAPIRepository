namespace GolocAPI.Models;
public class RentModel
{
    public Guid Id { get; set; }
    public string ProductName { get; set; }
    public string RenterName { get; set; }
    public string OwnerName { get; set; }
    public string OwnerId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public double Price { get; set; }
    public List<ChatMessageModel> ChatMessages { get; set; }
}
public class RentPostModel
{
    public Guid ProductId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public double Price { get; set; }
    public string FirstMessage { get; set; }
}
