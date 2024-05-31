namespace Koton.Web.API.Models
{
    public class Products
    {
        public int ProductId { get; set; }
        public int ReviewId { get; set; }
        public string ProductName { get; set; }
        public int SizeId { get; set; }
        public int CategoryId { get; set; }
        public int ProductStock { get; set; }
        public double ProductPrice { get; set; }
        public string ProductImage { get; set; }
        public string ProductDescription { get; set; }
        public double SalesPrice { get; set; }
        public string ProductCode { get; set; }    
        
    }
}
