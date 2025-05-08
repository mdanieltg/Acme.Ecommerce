using System.Collections.Generic;
using System.Threading.Tasks;
using Acme.Ecommerce.Application.Dto;
using Acme.Ecommerce.Transversal.Common;

namespace Acme.Ecommerce.Application.Interface
{
    public interface ICustomerApplication
    {
        Response<CustomerDto?> Get(string customerId);
        ValueTask<Response<CustomerDto?>> GetAsync(string customerId);
        Response<IEnumerable<CustomerDto>> GetAll();
        ValueTask<Response<IEnumerable<CustomerDto>>> GetAllAsync();
        Response<bool> Insert(CustomerDto customer);
        ValueTask<Response<bool>> InsertAsync(CustomerDto customerDto);
        Response<bool> Update(CustomerDto customerDto);
        ValueTask<Response<bool>> UpdateAsync(CustomerDto customerDto);
        Response<bool> Delete(string customerId);
        ValueTask<Response<bool>> DeleteAsync(string customerId);
    }
}
