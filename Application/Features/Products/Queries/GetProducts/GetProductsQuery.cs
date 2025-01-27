using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Queries.GetProducts
{
    public record GetProductsQuery : IRequest<IEnumerable<Product>>;

}
