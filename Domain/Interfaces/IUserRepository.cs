
using JqdIdentityApp.Domain.Entities;

namespace JqdIdentityApp.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByUsernameAsync(string username);
        Task<User?> GetByEmailAsync(string email);
    }
}