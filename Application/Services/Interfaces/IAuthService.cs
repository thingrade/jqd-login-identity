using Microsoft.AspNetCore.Identity;

namespace JqdIdentityApp.Application.Services.Interfaces
{
    public interface IAuthService
    {
        Task<IdentityResult> RegisterUserAsync(string email, string password);
        Task<bool> CheckPasswordSignInAsync(string email, string password);
    }
}