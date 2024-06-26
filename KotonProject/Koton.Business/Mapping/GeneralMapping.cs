﻿using Koton.Business.DTO_s;
using AutoMapper;
using Koton.Entities.Models;

namespace Koton.Business.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {

            CreateMap<ProductDto,Product>().ReverseMap();
            
            CreateMap<CategoryDto,Category>().ReverseMap();      
            
            CreateMap<CustomerDto,Customer>().ReverseMap();

            CreateMap<OrderDto,Order>().ReverseMap();   

            CreateMap<FileDto,Koton.Entities.Models.File>().ReverseMap();   
            CreateMap<OrderDetail,OrderDetailDto>().ReverseMap();   

            
        }
    }
}
