using Koton.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koton.Business.DTO_s
{
    public class OrderDto : BaseEntity
    { 
       
        public List<OrderDetailDto> Items { get; set; }
        public int CustomerId { get; set; }
        public string OrderStatus { get; set; }
        public string OrderAddress { get; set; }
        public double OrderTotalPrice { get; set; }
        public string OrderCargoCompany { get; set; }
        public string OrderNote { get; set; }
        public int PaymentId { get; set; }
        public string OrderInvoiceAddress { get; set; }
        public int OrderCurrency { get; set; }


    }
}
