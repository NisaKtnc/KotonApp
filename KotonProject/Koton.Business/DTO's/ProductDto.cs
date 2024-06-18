using Koton.Entities.Models;
using Microsoft.AspNetCore.Http;

namespace Koton.Business.DTO_s
{
    public class ProductDto : BaseEntity
    {

        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public string ProductImage { get; set; }
        public string ProductDescription { get; set; }
        public double SalesPrice { get; set; }
        public int ProductStock { get; set; }
        public int CategoryId { get; set; }
        public int ColorId { get; set; }
        public List<Koton.Entities.Models.File> Files { get; set; }

    }
}
