using Microsoft.AspNetCore.Identity;
using JqdIdentityApp.Domain.Entities;
using JqdIdentityApp.Application.Services.Interfaces;

namespace JqdIdentityApp.Application.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AuthService(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> RegisterUserAsync(string email, string password)
        {
            var user = new User { UserName = email, Email = email };
            var result = await _userManager.CreateAsync(user, password);
            return result;
        }

        public async Task<bool> CheckPasswordSignInAsync(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null) return false;

            var result = await _signInManager.CheckPasswordSignInAsync(user, password, false);
            return result.Succeeded;
        }
    }
}
