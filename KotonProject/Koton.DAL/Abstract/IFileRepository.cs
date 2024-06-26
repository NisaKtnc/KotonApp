﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koton.DAL.Abstract
{
    public interface IFileRepository : IRepository<Entities.Models.File>
    {

        Task<IEnumerable<Entities.Models.File>> GetByProductId(int Id);
    }
}
