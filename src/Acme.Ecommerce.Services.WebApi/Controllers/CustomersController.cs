using Acme.Ecommerce.Application.Dto;
using Acme.Ecommerce.Application.Interface;
using Acme.Ecommerce.Transversal.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Acme.Ecommerce.Services.WebApi.Controllers;

[ApiController]
[Route("api/customers")]
[Authorize]
public class CustomersController : ControllerBase
{
    private readonly ICustomerApplication _customerApplication;

    public CustomersController(ICustomerApplication customerApplication)
    {
        _customerApplication = customerApplication;
    }

    [HttpGet("{customerId}")]
    public async ValueTask<IActionResult> Get(string customerId)
    {
        if (string.IsNullOrEmpty(customerId)) return BadRequest();

        Response<CustomerDto?> response = await _customerApplication.Get(customerId);
        return response.IsSuccessful
            ? Ok(response.Payload)
            : BadRequest(response.Message);
    }

    [HttpGet]
    public async ValueTask<IActionResult> GetAll()
    {
        Response<IEnumerable<CustomerDto>> response = await _customerApplication.GetAll();
        return response.IsSuccessful
            ? Ok(response.Payload)
            : BadRequest(response.Message);
    }

    [HttpPost]
    public async ValueTask<IActionResult> Insert([FromBody] CustomerDto customerDto)
    {
        Response<bool> response = await _customerApplication.Insert(customerDto);
        return response.IsSuccessful
            ? Ok(response.Payload)
            : BadRequest(response.Message);
    }

    [HttpPut]
    public async ValueTask<IActionResult> Update([FromBody] CustomerDto customerDto)
    {
        Response<bool> response = await _customerApplication.Update(customerDto);
        return response.IsSuccessful
            ? Ok(response.Payload)
            : BadRequest(response.Message);
    }

    [HttpDelete("{customerId}")]
    public async ValueTask<IActionResult> Delete(string customerId)
    {
        if (string.IsNullOrEmpty(customerId)) return BadRequest();

        Response<bool> response = await _customerApplication.Delete(customerId);
        return response.IsSuccessful
            ? Ok(response.Payload)
            : BadRequest(response.Message);
    }
}
