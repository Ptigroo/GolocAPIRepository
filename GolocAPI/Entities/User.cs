using Microsoft.AspNetCore.Identity;

namespace GolocAPI.Entities
{
    public class User : IdentityUser
    {
        public string Pseudo { get; set; }
        public List<Product> Products { get; set; }
        public List<ChatMessage> ChatMessgages { get; set; }
    }
}
