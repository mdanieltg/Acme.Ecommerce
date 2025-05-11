using System.Collections.Generic;
using System.Threading.Tasks;
using Acme.Ecommerce.Application.Dto;
using Acme.Ecommerce.Transverse.Common;

namespace Acme.Ecommerce.Application.Interface
{
    public interface ICustomerApplication
    {
        ValueTask<Response<CustomerDto?>> Get(string customerId);
        ValueTask<Response<IEnumerable<CustomerDto>>> GetAll();
        ValueTask<Response<bool>> Insert(CustomerDto customerDto);
        ValueTask<Response<bool>> Update(CustomerDto customerDto);
        ValueTask<Response<bool>> Delete(string customerId);
    }
}
