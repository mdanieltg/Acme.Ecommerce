using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Acme.Ecommerce.Application.Dto;
using Acme.Ecommerce.Application.Interface;
using Acme.Ecommerce.Services.WebApi.Settings;
using Acme.Ecommerce.Transversal.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Acme.Ecommerce.Services.WebApi.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    private readonly IUserApplication _userApplication;
    private readonly AppSettings _appSettings;

    public UsersController(IUserApplication userApplication, AppSettings appSettings)
    {
        _userApplication = userApplication;
        _appSettings = appSettings;
    }

    [HttpPost]
    public IActionResult Authenticate([FromBody] UserDto userDto)
    {
        Response<UserDto> response = _userApplication.Authenticate(userDto.UserName, userDto.Password);
        if (!response.IsSuccessful)
            return NotFound(response.Message);

        response.Payload.Token = BuildToken(response);
        return Ok(response.Payload);
    }

    private string BuildToken(Response<UserDto> userDto)
    {
        byte[] key = Encoding.UTF8.GetBytes(_appSettings.Security.Token.Secret);

        SecurityTokenDescriptor tokenDescriptor = new()
        {
            Subject = new ClaimsIdentity([
                new Claim(ClaimTypes.Name, userDto.Payload.UserId.ToString())
            ]),
            Expires = DateTime.UtcNow.AddMinutes(1),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature),
            Issuer = _appSettings.Security.Token.Issuer,
            Audience = _appSettings.Security.Token.Audience
        };

        JwtSecurityTokenHandler tokenHandler = new();
        SecurityToken? token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}
