using System.Data;

namespace Acme.Ecommerce.Transverse.Common
{
    public interface IConnectionFactory
    {
        IDbConnection GetConnection { get; }
    }
}
