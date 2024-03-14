namespace GolocAPI.Models;
public class ChatMessageModel
{
    public string Message { get; set; }
    public Guid RentId { get; set; }
    public String SenderId { get; set; }
}
