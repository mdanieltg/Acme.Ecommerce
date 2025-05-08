using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Acme.Ecommerce.Domain.Entity;

namespace Acme.Ecommerce.Domain.Interface
{
    public interface ICustomerDomain
    {
        Customer? Get(string customerId);
        ValueTask<Customer?> GetAsync(string customerId);
        IEnumerable<Customer> GetAll();
        ValueTask<IEnumerable<Customer>> GetAllAsync();
        bool Insert(Customer customer);
        ValueTask<bool> InsertAsync(Customer customer);
        bool Update(Customer customer);
        ValueTask<bool> UpdateAsync(Customer customer);
        bool Delete(string customerId);
        ValueTask<bool> DeleteAsync(string customerId);
    }
}
