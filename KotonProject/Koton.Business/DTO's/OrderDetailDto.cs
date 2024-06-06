using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koton.Business.DTO_s
{
    public class OrderDetailDto
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double ShippingCost { get; set; }
        public string ReturnStatus { get; set; }
        public double RefundAmount { get; set; }
        public string Note { get; set; }
        public double SalesPrice { get; set; }
        public int Currency { get; set; }
        public double TaxRate { get; set; }
    }
}
