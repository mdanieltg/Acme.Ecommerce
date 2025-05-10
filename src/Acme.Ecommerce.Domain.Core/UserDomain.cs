using System.Threading.Tasks;
using Acme.Ecommerce.Domain.Entity;
using Acme.Ecommerce.Domain.Interface;
using Acme.Ecommerce.Infrastructure.Interface;

namespace Acme.Ecommerce.Domain.Core
{
    public class UserDomain : IUserDomain
    {
        private readonly IUserRepository _userRepository;

        public UserDomain(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async ValueTask<User> Authenticate(string username, string password)
        {
            return await _userRepository.Authenticate(username, password);
        }
    }
}
