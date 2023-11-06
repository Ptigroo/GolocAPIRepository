using Microsoft.AspNetCore.Identity;

namespace GolocAPI.Entities
{
    public class User : IdentityUser
    {
        public string Pseudo { get; set; }
    }
}
