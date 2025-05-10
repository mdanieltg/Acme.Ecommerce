using Acme.Ecommerce.Application.Dto;
using Acme.Ecommerce.Transversal.Common;

namespace Acme.Ecommerce.Application.Interface
{
    public interface IUserApplication
    {
        Response<UserDto> Authenticate(string username, string password);
    }
}
