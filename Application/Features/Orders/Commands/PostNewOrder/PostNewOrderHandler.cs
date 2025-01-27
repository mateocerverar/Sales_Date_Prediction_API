using Application.Features.Orders.Queries.GetOrders;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Orders.Commands.PostNewOrder
{
    public class PostNewOrderHandler : IRequestHandler<PostNewOrderCommand, int>
    {
        private readonly IOrdersRepository _ordersRepository;

        public PostNewOrderHandler(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        public async Task<int> Handle(PostNewOrderCommand request, CancellationToken cancellationToken)
        {
            var orders = await _ordersRepository.PostNewOrder(request);
            return orders;
        }
    }
}
