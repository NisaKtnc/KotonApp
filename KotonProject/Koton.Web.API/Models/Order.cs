using Koton.Entities.Models;

namespace Koton.Web.API.Models
{
    public class Order
    {
        public int Id { get; set; }             
        public double TotalPrice { get; set; }
        public string DeliveryAddress { get; set; }
        public string Status { get; set; }
        public string OrderCargoCompany { get; set; }
        public int OrderCurrency { get; set; }
        public string OrderNote { get; set; }
        public double SalesPrice { get; set; }
        public double RefundAmount { get; set; }
        public double ShippingCost { get; set; }
        public double TaxRate { get; set; }
    }
}
