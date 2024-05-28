namespace Koton.Web.API.Models
{
    public class Products
    {
        public int ProductsId { get; set; }
        public int ReviewsId { get; set; }
        public string ProductName { get; set; }
        public int SizeId { get; set; }
        public int CategoriesId { get; set; }
        public int ProductStock { get; set; }
        public double ProductPrice { get; set; }
        public string ProductImage { get; set; }
        public string ProductDescription { get; set; }
        public double SalesPrice { get; set; }
    }
}
