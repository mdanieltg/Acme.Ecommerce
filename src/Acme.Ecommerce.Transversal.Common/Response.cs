namespace Acme.Ecommerce.Transversal.Common
{
    public class Response<T>
    {
        public T Payload { get; set; } = default!;
        public bool IsSuccessful { get; set; }
        public string? Message { get; set; }
    }
}
