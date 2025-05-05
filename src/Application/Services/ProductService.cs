using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using NuevoProyecto.API.src.Core.Entities;
using NuevoProyecto.API.src.Application.DTOs;
using NuevoProyecto.API.src.Core.Interfaces;

namespace NuevoProyecto.API.src.Application.Services
{
    public class ProductService: GenericService<Product, ProductDto, ProductCreateDto>, IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(
            IGenericRepository<Product> genericRepository,
            IProductRepository productRepository,
            IMapper mapper
        ) : base(genericRepository, mapper)
        {
            _productRepository = productRepository;
        }

        
    }
    
}