using JqdIdentityApp.Domain.Entities;

namespace JqdIdentityApp.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<User?> GetUserByUsernameAsync(string username);
        Task<User?> GetUserByEmailAsync(string email);
    }
}