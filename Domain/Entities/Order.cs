using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Order
    {
        public int orderid { get; set; }
        public DateTime requireddate { get; set; }
        public DateTime shippeddate { get; set; }
        public string shipname { get; set; } = String.Empty;
        public string shipaddress { get; set; } = String.Empty;
        public string shipcity { get; set; } = String.Empty;
    }
}
