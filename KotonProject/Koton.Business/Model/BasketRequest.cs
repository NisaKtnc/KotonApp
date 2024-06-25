using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koton.Business.Model
{
    public class BasketRequest
    {
        public int ProductId { get; set; }
        public int Count { get; set; }
    }
}
