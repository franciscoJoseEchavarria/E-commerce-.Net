using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NuevoProyecto.API.Core.Entities;

namespace NuevoProyecto.API.Core.Interface
{
    public interface IGenericService <TEntity, TDto>

    where TEntity: BaseEntity
    where TDto: class
    

    {
        Task<IEnumerable<TDto>> GetAllAsync();
        Task<TDto> GetByIdAsync(int id);
        Task<TDto> AddAsync(TDto dto);
        Task UpdateAsync(int id, TDto dto);
        Task DeleteAsync(int id);
    }
 
}