using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NuevoProyecto.API.src.Core.Entities;
using NuevoProyecto.API.src.Core.Interfaces;
using NuevoProyecto.API.src.Infrastructure.Data;


namespace NuevoProyecto.API.src.Infrastructure.Repositories
{
    public class CategoryRepository: GenericRepository<Category>, ICategoryRepository
    {
        
        public CategoryRepository (ApplicationDbContext context) : base(context) { }

    }
}