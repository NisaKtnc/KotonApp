﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koton.Entities.Models
{
    public class Role : BaseEntity
    {
        public string RoleName { get; set; }    
        public ICollection<CustomerRole> CustomerRoles { get; set; }
    }
}
