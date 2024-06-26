using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koton.Entities.Models
{
    public class Order : BaseEntity
    {
        public int CustomerId { get; set; }
        public string OrderAddress { get; set; }
        public double OrderTotalPrice { get; set; } 
        public string OrderNote { get; set; }
        public int PaymentId { get; set; }
        // Navigation properties
        public Customer Customer { get; set; }
        public Payment Payments { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }

    }
}
