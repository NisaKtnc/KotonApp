using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koton.Entities.Models
{
    public class Payment : BaseEntity
    {
        public string PaymentMethod { get; set; }
        public string PaymentGateway { get; set; }


        public ICollection<Order> Order { get; set; }
    }
}
