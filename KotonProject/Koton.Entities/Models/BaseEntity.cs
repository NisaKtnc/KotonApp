using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koton.Entities.Models
{
    public abstract class BaseEntity : IBaseEntity
    {
        public DateTime CreatedDate {  get; set; }  = DateTime.Now;
        public string CreatedUsername { get; set; } = "Nisa";
        public DateTime? ModifiedTime { get; set; }
        public string? ModifiedUsername { get; set; }
        public DateTime? DeletedTime { get; set; }
        public string DeletedUsername { get; set; } = "Niniko";
        public bool IsActive { get; set; } = false;
        public bool IsDeleted { get; set; } = false;
        public int Id { get; set; }

        public BaseEntity() 
        {
            
        }
    }
    
    
}

