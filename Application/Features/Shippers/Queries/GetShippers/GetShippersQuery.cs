using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Shippers.Queries.GetShippers
{
     public record GetShippersQuery : IRequest<IEnumerable<Shipper>>;
}
