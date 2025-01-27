using Application.Features.Customers.Queries.GetSalesDatePrediction;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<Customer>> GetSalesDatePrediction()
        {
            var res = await _mediator.Send(new GetSalesDatePredictionQuery());
            return res;
        }
    }
}
