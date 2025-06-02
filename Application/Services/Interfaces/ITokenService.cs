using JqdIdentityApp.Domain.Entities;

namespace JqdIdentityApp.Application.Services.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
