﻿using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Customers.Queries.GetSalesDatePrediction
{
    public record GetSalesDatePredictionQuery : IRequest<IEnumerable<Customer>>;

}
