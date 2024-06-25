using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koton.Business.Model
{
    public class BasketItemModel
    {
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
        public byte[] Content { get; set; }

    }
}
