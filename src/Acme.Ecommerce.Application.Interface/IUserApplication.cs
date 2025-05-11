using System.Threading.Tasks;
using Acme.Ecommerce.Application.Dto;
using Acme.Ecommerce.Transverse.Common;

namespace Acme.Ecommerce.Application.Interface
{
    public interface IUserApplication
    {
        ValueTask<Response<UserDto>> Authenticate(string username, string password);
    }
}
