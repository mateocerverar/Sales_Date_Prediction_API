using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Customers.Queries.GetSalesDatePrediction
{
    public class GetSalesDatePredictionHandler : IRequestHandler<GetSalesDatePredictionQuery, IEnumerable<Customer>>
    {
        private readonly ICustomersRepository _customersRepository;

        public GetSalesDatePredictionHandler(ICustomersRepository customersRepository)
        {
            _customersRepository = customersRepository;
        }

        public async Task<IEnumerable<Customer>> Handle(GetSalesDatePredictionQuery request, CancellationToken cancellationToken)
        {
            var customers = await _customersRepository.GetSalesDatePrediction();
            return customers;
        }
    }
}
