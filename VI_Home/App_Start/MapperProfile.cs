using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VI_Home.Common.DTO;
using VI_Home.Common.Models;

namespace VI_Home.App_Start
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
                    
            CreateMap<ProductDTO, ProductViewModel>()
            .ReverseMap();
        }
    }
}