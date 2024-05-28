using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koton.Entities.Models
{
    public class Size : BaseEntity
    {
        public string SizeName { get; set; }
        public double SizeMeasure { get; set; }


        public ICollection<Product> Product { get; set;}
    }
}
