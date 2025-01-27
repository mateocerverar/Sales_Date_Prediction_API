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
    internal class ShipperRepository : IShippersRepository
    {
        private readonly IDbConnection _dbConnection;

        public ShipperRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<Shipper>> GetShippers()
        {
            using (var connection = _dbConnection)
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Option", 4);

                using (var results = await connection.QueryMultipleAsync("dbo.StoreSample_Queries", parameters, commandType: CommandType.StoredProcedure))
                {
                    var shippers = await results.ReadAsync<Shipper>();
                    return shippers;
                }
            }
        }
    }
}
