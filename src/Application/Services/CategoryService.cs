using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using NuevoProyecto.API.src.Core.Entities;
using NuevoProyecto.API.src.Application.DTOs;
using NuevoProyecto.API.src.Core.Interfaces;
 // Add this line for ICategoryRepository



namespace NuevoProyecto.API.src.Application.Services
{
    public class CategoryService: GenericService<Category, CategoryDto, CategoryDto>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(
            IGenericRepository<Category> genericRepository,
            ICategoryRepository categoryRepository,
            IMapper mapper
        ) : base(genericRepository, mapper)
        {
            _categoryRepository = categoryRepository;
        }

        // Métodos específicos para la categoría pueden ir aquí
    }
    
}