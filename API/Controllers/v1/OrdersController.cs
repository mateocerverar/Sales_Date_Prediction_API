using Application.Features.Customers.Queries.GetSalesDatePrediction;
using Application.Features.Orders.Commands.PostNewOrder;
using Application.Features.Orders.Queries.GetOrders;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{customerid}")]
        public async Task<IEnumerable<Order>> GetOrders(int customerid)
        {
            var res = await _mediator.Send(new GetOrdersQuery(customerid));
            return res;
        }

        [HttpPost]
        public async Task<int> PostNewOrder([FromBody] PostNewOrderCommand order)
        {
            var res = await _mediator.Send(order);
            return res;
        }
    }
}
