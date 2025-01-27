using Application.Interfaces;
using Dapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class CustomersRepository : ICustomersRepository
    {
        private readonly IDbConnection _dbConnection;

        public CustomersRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<Customer>> GetSalesDatePrediction()
        {
            using (var connection = _dbConnection)
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Option", 1);

                using (var results = await connection.QueryMultipleAsync("dbo.StoreSample_Queries", parameters, commandType: CommandType.StoredProcedure))
                {
                    var customers = await results.ReadAsync<Customer>();
                    return customers;
                }
            }
        }
    }
}
