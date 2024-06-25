using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koton.Entities.Models
{
    public class OrderDetail : BaseEntity
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }   
        public double ShippingCost { get; set; }
        public double SalesPrice { get; set; }
        // Navigation properties
        public Order Order { get; set; }
        public Product Product { get; set; }


    }
}
