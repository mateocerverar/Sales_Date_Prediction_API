using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Orders.Commands.PostNewOrder
{
    public record PostNewOrderCommand(
        int custid,
        int empid,
        DateTime orderdate,
        DateTime requireddate,
        DateTime shippeddate,
        int shipperid,
        decimal freight,
        string shipname,
        string shipaddress,
        string shipcity,
        string shipcountry,

        int productid,
        decimal unitprice,
        int quantity,
        decimal discount
    ) : IRequest<int>;
}
