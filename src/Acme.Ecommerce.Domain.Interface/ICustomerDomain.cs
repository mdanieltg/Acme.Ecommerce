using System.Collections.Generic;
using System.Threading.Tasks;
using Acme.Ecommerce.Domain.Entity;

namespace Acme.Ecommerce.Domain.Interface
{
    public interface ICustomerDomain
    {
        ValueTask<Customer?> Get(string customerId);
        ValueTask<IEnumerable<Customer>> GetAll();
        ValueTask<bool> Insert(Customer customer);
        ValueTask<bool> Update(Customer customer);
        ValueTask<bool> Delete(string customerId);
    }
}
