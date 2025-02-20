﻿using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Orders.Queries.GetOrders
{
    public record GetOrdersQuery(int customerid) : IRequest<IEnumerable<Order>>;

}
