﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koton.Entities.Models
{
    public class CustomerRole
    {
        public int CustomerId { get; set; }
        public int RoleId { get; set; }
        public Customer Customer { get; set; }
        public Role Role { get; set; }
    }
}
