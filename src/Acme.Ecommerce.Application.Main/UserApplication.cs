using System;
using System.Threading.Tasks;
using Acme.Ecommerce.Application.Dto;
using Acme.Ecommerce.Application.Interface;
using Acme.Ecommerce.Domain.Entity;
using Acme.Ecommerce.Domain.Interface;
using Acme.Ecommerce.Transversal.Common;
using AutoMapper;

namespace Acme.Ecommerce.Application.Main
{
    public class UserApplication : IUserApplication
    {
        private readonly IUserDomain _userDomain;
        private readonly IMapper _mapper;

        public UserApplication(IUserDomain userDomain, IMapper mapper)
        {
            _userDomain = userDomain;
            _mapper = mapper;
        }

        public async ValueTask<Response<UserDto>> Authenticate(string username, string password)
        {
            var response = new Response<UserDto>();
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                response.Message = "Username or password is empty";
                return response;
            }

            try
            {
                User user = await _userDomain.Authenticate(username, password);
                response.Payload = _mapper.Map<UserDto>(user);
                response.IsSuccessful = true;
            }
            catch (InvalidOperationException)
            {
                response.Message = "Invalid credentials";
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }

            return response;
        }
    }
}
