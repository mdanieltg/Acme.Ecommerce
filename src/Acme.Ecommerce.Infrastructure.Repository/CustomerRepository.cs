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
        private readonly IConnectionFactory _connectionFactory;

        public CustomerRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public Customer? Get(string customerId)
        {
            using IDbConnection connection = _connectionFactory.GetConnection;
            var query = "CustomerGetById";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", customerId);

            var result = connection.QuerySingle<Customer?>(query, parameters, commandType: CommandType.StoredProcedure);
            return result;
        }

        public async ValueTask<Customer?> GetAsync(string customerId)
        {
            using IDbConnection connection = _connectionFactory.GetConnection;
            var query = "CustomerGetById";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", customerId);

            var result = await connection.QuerySingleAsync<Customer?>(query, parameters,
                commandType: CommandType.StoredProcedure);
            return result;
        }

        public IEnumerable<Customer> GetAll()
        {
            using IDbConnection connection = _connectionFactory.GetConnection;
            var query = "CustomerList";

            IEnumerable<Customer> result = connection.Query<Customer>(query, commandType: CommandType.StoredProcedure);
            return result;
        }

        public async ValueTask<IEnumerable<Customer>> GetAllAsync()
        {
            using IDbConnection connection = _connectionFactory.GetConnection;
            var query = "CustomerList";

            IEnumerable<Customer> result = await connection.QueryAsync<Customer>(query,
                commandType: CommandType.StoredProcedure);
            return result;
        }

        public bool Insert(Customer customer)
        {
            using IDbConnection connection = _connectionFactory.GetConnection;
            var query = "CustomerInsert";
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

            int result = connection.Execute(query, parameters, commandType: CommandType.StoredProcedure);
            return result > 0;
        }

        public async ValueTask<bool> InsertAsync(Customer customer)
        {
            using IDbConnection connection = _connectionFactory.GetConnection;
            var query = "CustomerInsert";
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

            int result = await connection.ExecuteAsync(query, parameters, commandType: CommandType.StoredProcedure);
            return result > 0;
        }

        public bool Update(Customer customer)
        {
            using IDbConnection connection = _connectionFactory.GetConnection;
            var query = "CustomerUpdate";
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

            int result = connection.Execute(query, parameters, commandType: CommandType.StoredProcedure);
            return result > 0;
        }

        public async ValueTask<bool> UpdateAsync(Customer customer)
        {
            using IDbConnection connection = _connectionFactory.GetConnection;
            var query = "CustomerUpdate";
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

            int result = await connection.ExecuteAsync(query, parameters, commandType: CommandType.StoredProcedure);
            return result > 0;
        }

        public bool Delete(string customerId)
        {
            using IDbConnection connection = _connectionFactory.GetConnection;
            var query = "CustomerDelete";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", customerId);

            int result = connection.Execute(query, parameters, commandType: CommandType.StoredProcedure);
            return result > 0;
        }

        public async ValueTask<bool> DeleteAsync(string customerId)
        {
            using IDbConnection connection = _connectionFactory.GetConnection;
            var query = "CustomerDelete";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", customerId);

            int result = await connection.ExecuteAsync(query, parameters, commandType: CommandType.StoredProcedure);
            return result > 0;
        }
    }
}
