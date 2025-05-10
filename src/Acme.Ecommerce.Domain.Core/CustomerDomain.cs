using System.Collections.Generic;
using System.Threading.Tasks;
using Acme.Ecommerce.Domain.Entity;
using Acme.Ecommerce.Domain.Interface;
using Acme.Ecommerce.Infrastructure.Interface;

namespace Acme.Ecommerce.Domain.Core
{
    public class CustomerDomain : ICustomerDomain
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerDomain(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async ValueTask<Customer?> Get(string customerId)
        {
            return await _customerRepository.Get(customerId);
        }

        public async ValueTask<IEnumerable<Customer>> GetAll()
        {
            return await _customerRepository.GetAll();
        }

        public async ValueTask<bool> Insert(Customer customer)
        {
            return await _customerRepository.Insert(customer);
        }

        public async ValueTask<bool> Update(Customer customer)
        {
            return await _customerRepository.Update(customer);
        }

        public async ValueTask<bool> Delete(string customerId)
        {
            return await _customerRepository.Delete(customerId);
        }
    }
}
