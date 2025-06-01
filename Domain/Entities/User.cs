using Microsoft.AspNetCore.Identity;

namespace JqdIdentityApp.Domain.Entities
{
    public class User : IdentityUser
    {
        public string FullName { get; set; } = "";
    }
}