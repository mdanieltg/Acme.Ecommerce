using System.Threading.Tasks;
using Acme.Ecommerce.Domain.Entity;

namespace Acme.Ecommerce.Domain.Interface
{
    public interface IUserDomain
    {
        ValueTask<User> Authenticate(string username, string password);
    }
}
