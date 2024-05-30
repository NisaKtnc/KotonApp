
namespace Koton.Entities.Models
{
    public class Category : BaseEntity
    {
        public string CategoryName { get; set; }
        
        public ICollection<Product> Product { get; set; }
    }
}
