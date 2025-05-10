using System.Data;
using Acme.Ecommerce.Domain.Entity;
using Acme.Ecommerce.Infrastructure.Interface;
using Acme.Ecommerce.Transversal.Common;
using Dapper;

namespace Acme.Ecommerce.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private const string GetByUserAndPasswordSp = "UserGetByUserAndPassword";
        private readonly IConnectionFactory _connectionFactory;

        public UserRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public User Authenticate(string username, string password)
        {
            using IDbConnection connection = _connectionFactory.GetConnection;
            var parameters = new DynamicParameters();
            parameters.Add("UserName", username);
            parameters.Add("Password", password);

            var user = connection.QuerySingle<User>(GetByUserAndPasswordSp, parameters,
                commandType: CommandType.StoredProcedure);
            return user;
        }
    }
}
