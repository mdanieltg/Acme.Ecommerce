using Acme.Ecommerce.Domain.Entity;

namespace Acme.Ecommerce.Domain.Interface
{
    public interface IUserDomain
    {
        User Authenticate(string username, string password);
    }
}
