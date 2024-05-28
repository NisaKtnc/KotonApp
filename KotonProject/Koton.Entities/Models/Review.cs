using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koton.Entities.Models
{
    public class Review : BaseEntity
    {
        
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public double Ratings { get; set; }
        public string ReviewsTitle { get; set; }
        public string ReviewsDescription { get; set; }
        public string ReviewsStatus { get; set; }
        public string ReviewsImage { get; set; }
        public Customer Customer { get; set; }
        public Product Product { get; set; }

    }
}
