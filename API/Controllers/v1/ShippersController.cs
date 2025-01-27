using Application.Features.Customers.Queries.GetSalesDatePrediction;
using Application.Features.Shippers.Queries.GetShippers;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ShippersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<Shipper>> GetShippers()
        {
            var res = await _mediator.Send(new GetShippersQuery());
            return res;
        }
    }
}
