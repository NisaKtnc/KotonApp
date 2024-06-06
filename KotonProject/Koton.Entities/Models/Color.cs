using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koton.Entities.Models
{
    public class Color : BaseEntity
    {
        public string Name { get; set; }            
        public string HexCode { get; set; } 
    }
}
