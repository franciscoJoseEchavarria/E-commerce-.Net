using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NuevoProyecto.API.src.Core.Entities
;

namespace NuevoProyecto.API.src.Core.Interfaces

{
    public interface IGenericRepository <T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }

    //ok
    
}