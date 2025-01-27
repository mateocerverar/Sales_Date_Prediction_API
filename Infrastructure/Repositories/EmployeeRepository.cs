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
    public class EmployeeRepository : IEmployeesRepository
    {
        private readonly IDbConnection _dbConnection;

        public EmployeeRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            using (var connection = _dbConnection)
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Option", 3);

                using (var results = await connection.QueryMultipleAsync("dbo.StoreSample_Queries", parameters, commandType: CommandType.StoredProcedure))
                {
                    var employees = await results.ReadAsync<Employee>();
                    return employees;
                }
            }
        }
    }
}
