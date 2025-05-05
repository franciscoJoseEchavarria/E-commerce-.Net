using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NuevoProyecto.API.src.Core.Entities
;

namespace NuevoProyecto.API.src.Core.Interfaces

{
    public interface IGenericService <TEntity, TDto, TCreateDto>

    where TEntity: BaseEntity
    where TDto: class
    where TCreateDto: class
    

    {
        Task<IEnumerable<TDto>> GetAllAsync();
        Task<TDto> GetByIdAsync(int id);
        Task<TDto> AddAsync(TCreateDto createDto);
        Task UpdateAsync(int id, TDto dto);
        Task DeleteAsync(int id);
    }
 
}