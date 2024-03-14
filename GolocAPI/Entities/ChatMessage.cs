using GolocAPI.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;
namespace GolocAPI.Entities;
public class ChatMessage : BaseEntity
{
    public string Message { get; set; }
    public String SenderId { get; set; }
    public User Sender { get; set; }
    public Guid RentID { get; set; }
    public Rent Rent { get; set; }
}
