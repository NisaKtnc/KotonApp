﻿using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Koton.Entities.Models
{
    public class Product : BaseEntity
    {
        public int? ReviewId { get; set; }
        public string ProductName { get; set; }
        public int? SizeId { get; set; }
        public int CategoryId { get; set; } 
        public int ProductStock {  get; set; }
        public double ProductPrice { get; set; }
        public string ProductImage { get; set; }   
        public string ProductDescription { get; set; }
        public double SalesPrice { get; set; }
        public int ColorId { get; set; }

        public ICollection<Cart> Carts{ get; set; }
        public Category Category {  get; set; }
        public Color Color {  get; set; }
        public Size Sizes { get; set; }
        public ICollection<Review> Review { get; set; }
        public ICollection<File> Files { get; set; }    


    }
}
