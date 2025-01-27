using Application.Features.Orders.Commands.PostNewOrder;
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
    public class OrderRepository : IOrdersRepository
    {
        private readonly IDbConnection _dbConnection;

        public OrderRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<Order>> GetOrdersByClient(int customerid)
        {
            using (var connection = _dbConnection)
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Option", 2);
                parameters.Add("CustomerId", customerid);

                using (var results = await connection.QueryMultipleAsync("dbo.StoreSample_Queries", parameters, commandType: CommandType.StoredProcedure))
                {
                    var orders = await results.ReadAsync<Order>();
                    return orders;
                }
            }
        }

        public async Task<int> PostNewOrder(PostNewOrderCommand order)
        {
            using (var connection = _dbConnection)
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Option", 1);
                parameters.Add("CustId", order.custid);
                parameters.Add("EmpId", order.empid);
                parameters.Add("OrderDate", order.orderdate);
                parameters.Add("RequiredDate", order.requireddate);
                parameters.Add("ShippedDate", order.shippeddate);
                parameters.Add("ShipperId", order.shipperid);
                parameters.Add("Freight", order.freight);
                parameters.Add("ShipName", order.shipname);
                parameters.Add("ShipAddress", order.shipaddress);
                parameters.Add("ShipCity", order.shipcity);
                parameters.Add("ShipCountry", order.shipcountry);
                parameters.Add("ProductId", order.productid);
                parameters.Add("UnitPrice", order.unitprice);
                parameters.Add("Quantity", order.quantity);
                parameters.Add("Discount", order.discount);

                using (var results = await connection.QueryMultipleAsync("dbo.StoreSample_Commands", parameters, commandType: CommandType.StoredProcedure))
                {
                    var orderCreated = await results.ReadFirstAsync<int>();
                    return orderCreated;
                }
            }
        }
    }
}
