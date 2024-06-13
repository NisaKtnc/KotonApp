using Koton.Business.Abstract;
using Koton.DAL.Abstract;
using Koton.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koton.Business.Concrete
{
    public class ColorService : IColorService
    {
        private readonly IColorRepository _colorRepository;

        public ColorService(IColorRepository colorRepository) 
        { 
            this._colorRepository = colorRepository;
        }
        public async Task<IEnumerable<Color>> GetAllColorAsync()
        {
            return await _colorRepository.GetAllAsync();
        }
    }
}
