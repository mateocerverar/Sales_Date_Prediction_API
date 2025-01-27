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
    internal class ProductRepository : IProductsRepository
    {
        private readonly IDbConnection _dbConnection;

        public ProductRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            using (var connection = _dbConnection)
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Option", 5);

                using (var results = await connection.QueryMultipleAsync("dbo.StoreSample_Queries", parameters, commandType: CommandType.StoredProcedure))
                {
                    var products = await results.ReadAsync<Product>();
                    return products;
                }
            }
        }
    }
}
