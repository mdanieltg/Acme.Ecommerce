using System.Threading.Tasks;
using Acme.Ecommerce.Domain.Entity;

namespace Acme.Ecommerce.Infrastructure.Interface
{
    public interface IUserRepository
    {
        ValueTask<User> Authenticate(string username, string password);
    }
}
