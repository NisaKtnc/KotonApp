using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koton.Entities.Models
{
    public class OrderType : BaseEntity
    {
        public int OrderId { get; set; }
        public string OrderTypeName { get; set; }
        public string OrderTypeDescription { get; set; }
        public Order Orders { get; set; } 

    }
}
