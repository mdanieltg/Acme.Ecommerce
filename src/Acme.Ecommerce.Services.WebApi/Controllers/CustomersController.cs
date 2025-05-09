using Acme.Ecommerce.Application.Dto;
using Acme.Ecommerce.Application.Interface;
using Acme.Ecommerce.Transversal.Common;
using Microsoft.AspNetCore.Mvc;

namespace Acme.Ecommerce.Services.WebApi.Controllers;

[ApiController]
[Route("api/customers")]
public class CustomersController : ControllerBase
{
    private readonly ICustomerApplication _customerApplication;

    public CustomersController(ICustomerApplication customerApplication)
    {
        _customerApplication = customerApplication;
    }

    [HttpGet("{customerId}")]
    public async ValueTask<IActionResult> GetAsync(string customerId)
    {
        if (string.IsNullOrEmpty(customerId)) return BadRequest();

        Response<CustomerDto?> response = await _customerApplication.GetAsync(customerId);
        return response.IsSuccessful
            ? Ok(response.Payload)
            : BadRequest(response.Message);
    }

    [HttpGet]
    public async ValueTask<IActionResult> GetAllAsync()
    {
        Response<IEnumerable<CustomerDto>> response = await _customerApplication.GetAllAsync();
        return response.IsSuccessful
            ? Ok(response.Payload)
            : BadRequest(response.Message);
    }

    [HttpPost]
    public async ValueTask<IActionResult> InsertAsync([FromBody] CustomerDto customerDto)
    {
        Response<bool> response = await _customerApplication.InsertAsync(customerDto);
        return response.IsSuccessful
            ? Ok(response.Payload)
            : BadRequest(response.Message);
    }

    [HttpPut]
    public async ValueTask<IActionResult> UpdateAsync([FromBody] CustomerDto customerDto)
    {
        Response<bool> response = await _customerApplication.UpdateAsync(customerDto);
        return response.IsSuccessful
            ? Ok(response.Payload)
            : BadRequest(response.Message);
    }

    [HttpDelete("{customerId}")]
    public async ValueTask<IActionResult> DeleteAsync(string customerId)
    {
        if (string.IsNullOrEmpty(customerId)) return BadRequest();

        Response<bool> response = await _customerApplication.DeleteAsync(customerId);
        return response.IsSuccessful
            ? Ok(response.Payload)
            : BadRequest(response.Message);
    }
}
