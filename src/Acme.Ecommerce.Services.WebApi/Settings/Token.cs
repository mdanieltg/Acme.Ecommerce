namespace Acme.Ecommerce.Services.WebApi.Settings;

public class Token
{
    public required string Secret { get; set; }
    public required string Issuer { get; set; }
    public required string Audience { get; set; }
}
