using Koton.Business.DTO_s;
using AutoMapper;
using Koton.Entities.Models;

namespace Koton.Business.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {

            CreateMap<ProductDto,Product>().ReverseMap();
            
                    
        }
    }
}
