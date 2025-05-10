using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Acme.Ecommerce.Domain.Entity;
using Acme.Ecommerce.Infrastructure.Interface;
using Acme.Ecommerce.Transversal.Common;
using Dapper;

namespace Acme.Ecommerce.Infrastructure.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private const string ListSp = "CustomerList";
        private const string GetBytIdSp = "CustomerGetById";
        private const string InsertSp = "CustomerInsert";
        private const string UpdateSp = "CustomerUpdate";
        private const string DeleteSp = "CustomerDelete";
        private readonly IConnectionFactory _connectionFactory;

        public CustomerRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async ValueTask<Customer?> Get(string customerId)
        {
            using IDbConnection connection = _connectionFactory.GetConnection;
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", customerId);

            var result = await connection.QuerySingleOrDefaultAsync<Customer>(GetBytIdSp, parameters,
                commandType: CommandType.StoredProcedure);
            return result;
        }

        public async ValueTask<IEnumerable<Customer>> GetAll()
        {
            using IDbConnection connection = _connectionFactory.GetConnection;
            IEnumerable<Customer> result = await connection.QueryAsync<Customer>(ListSp,
                commandType: CommandType.StoredProcedure);
            return result;
        }

        public async ValueTask<bool> Insert(Customer customer)
        {
            using IDbConnection connection = _connectionFactory.GetConnection;
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", customer.CustomerId);
            parameters.Add("CompanyName", customer.CompanyName);
            parameters.Add("ContactName", customer.ContactName);
            parameters.Add("ContactTitle", customer.ContactTitle);
            parameters.Add("Address", customer.Address);
            parameters.Add("City", customer.City);
            parameters.Add("Region", customer.Region);
            parameters.Add("PostalCode", customer.PostalCode);
            parameters.Add("Country", customer.Country);
            parameters.Add("Phone", customer.Phone);
            parameters.Add("Fax", customer.Fax);

            int result = await connection.ExecuteAsync(InsertSp, parameters, commandType: CommandType.StoredProcedure);
            return result > 0;
        }

        public async ValueTask<bool> Update(Customer customer)
        {
            using IDbConnection connection = _connectionFactory.GetConnection;
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", customer.CustomerId);
            parameters.Add("CompanyName", customer.CompanyName);
            parameters.Add("ContactName", customer.ContactName);
            parameters.Add("ContactTitle", customer.ContactTitle);
            parameters.Add("Address", customer.Address);
            parameters.Add("City", customer.City);
            parameters.Add("Region", customer.Region);
            parameters.Add("PostalCode", customer.PostalCode);
            parameters.Add("Country", customer.Country);
            parameters.Add("Phone", customer.Phone);
            parameters.Add("Fax", customer.Fax);

            int result = await connection.ExecuteAsync(UpdateSp, parameters, commandType: CommandType.StoredProcedure);
            return result > 0;
        }

        public async ValueTask<bool> Delete(string customerId)
        {
            using IDbConnection connection = _connectionFactory.GetConnection;
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", customerId);

            int result = await connection.ExecuteAsync(DeleteSp, parameters, commandType: CommandType.StoredProcedure);
            return result > 0;
        }
    }
}
