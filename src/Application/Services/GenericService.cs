using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using NuevoProyecto.API.src.Core.Interfaces; 
using NuevoProyecto.API.src.Core.Entities;
using NuevoProyecto.API.src.Core.Interfaces;
using NuevoProyecto.API.src.Application.DTOs;

namespace NuevoProyecto.API.src.Application.Services
{
    public class GenericService<TEntity, TDto>: IGenericService<TEntity, TDto>
        where TEntity : BaseEntity
        where TDto : class
    {
        
        protected readonly IGenericRepository<TEntity> _repository;
        protected readonly IMapper _mapper;

        public GenericService(IGenericRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<TDto>>(entities);
        }

        public async Task<TDto> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<TDto>(entity);
        }

        public virtual async Task <TDto> AddAsync(TDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            await _repository.AddAsync(entity);
            return _mapper.Map<TDto>(entity);
        }

        public async Task UpdateAsync(int id, TDto dto)
        {
            var existingEntity = await _repository.GetByIdAsync(id);
            _mapper.Map(dto, existingEntity);
            await _repository.UpdateAsync(existingEntity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(entity.Id);
        }
    }
}


