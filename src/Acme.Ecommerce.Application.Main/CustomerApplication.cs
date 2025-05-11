using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Acme.Ecommerce.Application.Dto;
using Acme.Ecommerce.Application.Interface;
using Acme.Ecommerce.Domain.Entity;
using Acme.Ecommerce.Domain.Interface;
using Acme.Ecommerce.Transverse.Common;
using AutoMapper;

namespace Acme.Ecommerce.Application.Main
{
    public class CustomerApplication : ICustomerApplication
    {
        private readonly ICustomerDomain _customerDomain;
        private readonly IMapper _mapper;
        private readonly IAppLogger<CustomerApplication> _logger;

        public CustomerApplication(ICustomerDomain customerDomain, IMapper mapper,
            IAppLogger<CustomerApplication> logger)
        {
            _customerDomain = customerDomain;
            _mapper = mapper;
            _logger = logger;
        }

        public async ValueTask<Response<CustomerDto?>> Get(string customerId)
        {
            var response = new Response<CustomerDto?>();
            try
            {
                Customer? customer = await _customerDomain.Get(customerId);
                response.Payload = _mapper.Map<CustomerDto>(customer);

                if (response.Payload != null) response.IsSuccessful = true;
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }

            return response;
        }

        public async ValueTask<Response<IEnumerable<CustomerDto>>> GetAll()
        {
            var response = new Response<IEnumerable<CustomerDto>>();
            try
            {
                IEnumerable<Customer> customers = await _customerDomain.GetAll();
                response.Payload = _mapper.Map<IEnumerable<CustomerDto>>(customers);

                if (response.Payload != null)
                {
                    response.IsSuccessful = true;
                    _logger.LogInformation("Successfully retrieved all customers");
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                _logger.LogError(e.Message);
            }

            return response;
        }

        public async ValueTask<Response<bool>> Insert(CustomerDto customerDto)
        {
            var response = new Response<bool>();
            try
            {
                var customer = _mapper.Map<Customer>(customerDto);
                response.Payload = await _customerDomain.Insert(customer);

                if (response.Payload) response.IsSuccessful = true;
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }

            return response;
        }

        public async ValueTask<Response<bool>> Update(CustomerDto customerDto)
        {
            var response = new Response<bool>();
            try
            {
                var customer = _mapper.Map<Customer>(customerDto);
                response.Payload = await _customerDomain.Update(customer);

                if (response.Payload) response.IsSuccessful = true;
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }

            return response;
        }

        public async ValueTask<Response<bool>> Delete(string customerId)
        {
            var response = new Response<bool>();
            try
            {
                response.Payload = await _customerDomain.Delete(customerId);
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
