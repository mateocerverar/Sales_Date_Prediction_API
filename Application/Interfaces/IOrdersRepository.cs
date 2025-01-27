using Application.Features.Orders.Commands.PostNewOrder;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IOrdersRepository
    {
        Task<IEnumerable<Order>> GetOrdersByClient(int customerid);
        Task<int> PostNewOrder(PostNewOrderCommand order);

    }
}
