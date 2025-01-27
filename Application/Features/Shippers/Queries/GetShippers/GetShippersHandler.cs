using Application.Features.Products.Queries.GetProducts;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Shippers.Queries.GetShippers
{
    internal class GetShippersHandler : IRequestHandler<GetShippersQuery, IEnumerable<Shipper>>
    {
        private readonly IShippersRepository _shippersRepository;

        public GetShippersHandler(IShippersRepository shippersRepository)
        {
            _shippersRepository = shippersRepository;
        }

        public async Task<IEnumerable<Shipper>> Handle(GetShippersQuery request, CancellationToken cancellationToken)
        {
            var shippers = await _shippersRepository.GetShippers();
            return shippers;
        }
    }
}
