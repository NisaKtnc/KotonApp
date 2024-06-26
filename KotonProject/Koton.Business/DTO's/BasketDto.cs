using Koton.Business.Model;
using Koton.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koton.Business.DTO_s
{
    public class BasketDto
    {
        public BasketDto()
        {
            BasketItems = new();
        }
        public List<BasketItemModel>  BasketItems { get; set; }
        public double TotalPrice => BasketItems.Sum(x => x.Price);
        public string OrderNote { get; set; }
        public string OrderAddress { get; set; }
    }
}
