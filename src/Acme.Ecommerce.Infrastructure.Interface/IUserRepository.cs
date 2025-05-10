using Acme.Ecommerce.Domain.Entity;

namespace Acme.Ecommerce.Infrastructure.Interface
{
    public interface IUserRepository
    {
        User Authenticate(string username, string password);
    }
}
