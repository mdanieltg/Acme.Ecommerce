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

        public Customer? Get(string customerId)
        {
            return _customerRepository.Get(customerId);
        }

        public async ValueTask<Customer?> GetAsync(string customerId)
        {
            return await _customerRepository.GetAsync(customerId);
        }

        public IEnumerable<Customer> GetAll()
        {
            return _customerRepository.GetAll();
        }

        public async ValueTask<IEnumerable<Customer>> GetAllAsync()
        {
            return await _customerRepository.GetAllAsync();
        }

        public bool Insert(Customer customer)
        {
            return _customerRepository.Insert(customer);
        }

        public async ValueTask<bool> InsertAsync(Customer customer)
        {
            return await _customerRepository.InsertAsync(customer);
        }

        public bool Update(Customer customer)
        {
            return _customerRepository.Update(customer);
        }

        public async ValueTask<bool> UpdateAsync(Customer customer)
        {
            return await _customerRepository.UpdateAsync(customer);
        }

        public bool Delete(string customerId)
        {
            return _customerRepository.Delete(customerId);
        }

        public async ValueTask<bool> DeleteAsync(string customerId)
        {
            return await _customerRepository.DeleteAsync(customerId);
        }
    }
}
