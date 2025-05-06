using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using NuevoProyecto.API.src.Core.Entities;
using NuevoProyecto.API.src.Application.DTOs;


namespace NuevoProyecto.API.src.Application.Mappings
{
    public class ProductProfile: Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));
            
            CreateMap<ProductCreateDto, Product>();
        
      
            CreateMap<ProductDto, Product>();
        }
    }
}