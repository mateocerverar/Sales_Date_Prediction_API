using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Customer
    {
        public int custid { get; set; }
        public string customername { get; set; } = string.Empty;
        public DateTime lastorderdate { get; set; }
        public DateTime nextpredictedorder { get; set; }
    }
}
