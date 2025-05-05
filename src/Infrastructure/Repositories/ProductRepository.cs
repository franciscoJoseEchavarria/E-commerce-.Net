using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NuevoProyecto.API.src.Infrastructure.Data; // Ensure this is the correct namespace for ApplicationDbContext
using NuevoProyecto.API.src.Application.DTOs;
using NuevoProyecto.API.src.Core.Entities;
using NuevoProyecto.API.src.Core.Interfaces;

namespace NuevoProyecto.API.src.Infrastructure.Repositories
{
    public class ProductRepository: GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context) { }
        
        // You can add any specific methods for Product here if needed
        // For example, if you want to get products by a specific property
        // public async Task<IEnumerable<Product>> GetBySomePropertyAsync(string property)
        // {
        //     return await _context.Set<Product>().Where(c => c.SomeProperty == property).ToListAsync();
        // }
    
        
    }
}