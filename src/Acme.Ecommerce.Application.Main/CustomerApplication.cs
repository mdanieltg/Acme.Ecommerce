using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Acme.Ecommerce.Application.Dto;
using Acme.Ecommerce.Application.Interface;
using Acme.Ecommerce.Domain.Entity;
using Acme.Ecommerce.Domain.Interface;
using Acme.Ecommerce.Transversal.Common;
using AutoMapper;

namespace Acme.Ecommerce.Application.Main
{
    public class CustomerApplication : ICustomerApplication
    {
        private readonly ICustomerDomain _customerDomain;
        private readonly IMapper _mapper;

        public CustomerApplication(ICustomerDomain customerDomain, IMapper mapper)
        {
            _customerDomain = customerDomain;
            _mapper = mapper;
        }

        public Response<CustomerDto?> Get(string customerId)
        {
            var response = new Response<CustomerDto?>();
            try
            {
                Customer? customer = _customerDomain.Get(customerId);
                response.Payload = _mapper.Map<CustomerDto>(customer);

                if (response.Payload != null) response.IsSuccessful = true;
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }

            return response;
        }

        public async ValueTask<Response<CustomerDto?>> GetAsync(string customerId)
        {
            var response = new Response<CustomerDto?>();
            try
            {
                Customer? customer = await _customerDomain.GetAsync(customerId);
                response.Payload = _mapper.Map<CustomerDto>(customer);

                if (response.Payload != null) response.IsSuccessful = true;
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }

            return response;
        }

        public Response<IEnumerable<CustomerDto>> GetAll()
        {
            var response = new Response<IEnumerable<CustomerDto>>();
            try
            {
                IEnumerable<Customer> customers = _customerDomain.GetAll();
                response.Payload = _mapper.Map<IEnumerable<CustomerDto>>(customers);

                if (response.Payload != null) response.IsSuccessful = true;
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }

            return response;
        }

        public async ValueTask<Response<IEnumerable<CustomerDto>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<CustomerDto>>();
            try
            {
                IEnumerable<Customer> customers = await _customerDomain.GetAllAsync();
                response.Payload = _mapper.Map<IEnumerable<CustomerDto>>(customers);

                if (response.Payload != null) response.IsSuccessful = true;
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }

            return response;
        }

        public Response<bool> Insert(CustomerDto customerDto)
        {
            var response = new Response<bool>();
            try
            {
                var customer = _mapper.Map<Customer>(customerDto);
                response.Payload = _customerDomain.Insert(customer);

                if (response.Payload) response.IsSuccessful = true;
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }

            return response;
        }

        public async ValueTask<Response<bool>> InsertAsync(CustomerDto customerDto)
        {
            var response = new Response<bool>();
            try
            {
                var customer = _mapper.Map<Customer>(customerDto);
                response.Payload = await _customerDomain.InsertAsync(customer);

                if (response.Payload) response.IsSuccessful = true;
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }

            return response;
        }

        public Response<bool> Update(CustomerDto customerDto)
        {
            var response = new Response<bool>();
            try
            {
                var customer = _mapper.Map<Customer>(customerDto);
                response.Payload = _customerDomain.Update(customer);

                if (response.Payload) response.IsSuccessful = true;
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }

            return response;
        }

        public async ValueTask<Response<bool>> UpdateAsync(CustomerDto customerDto)
        {
            var response = new Response<bool>();
            try
            {
                var customer = _mapper.Map<Customer>(customerDto);
                response.Payload = await _customerDomain.UpdateAsync(customer);

                if (response.Payload) response.IsSuccessful = true;
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }

            return response;
        }

        public Response<bool> Delete(string customerId)
        {
            var response = new Response<bool>();
            try
            {
                response.Payload = _customerDomain.Delete(customerId);
                if (response.Payload) response.IsSuccessful = true;
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }

            return response;
        }

        public async ValueTask<Response<bool>> DeleteAsync(string customerId)
        {
            var response = new Response<bool>();
            try
            {
                response.Payload = await _customerDomain.DeleteAsync(customerId);
                if (response.Payload) response.IsSuccessful = true;
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }

            return response;
        }
    }
}
