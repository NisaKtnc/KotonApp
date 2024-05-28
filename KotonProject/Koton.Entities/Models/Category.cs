using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koton.Entities.Models
{
    public class Category : BaseEntity
    {
        public string CategoryName { get; set; }
        
        public ICollection<Product> Product { get; set; }
    }
}
