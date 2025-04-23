using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuevoProyecto.API.Models;
using NuevoProyecto.API.Data;
using NuevoProyecto.API.Interface;

namespace NuevoProyecto.API.Repository
{
    public class UserRepository: IRepository<Users>
    {
        
          private readonly ApplicationDbContext _context;
        
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Users>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }
        
        public async Task<Users> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }
        
        public async Task AddAsync(Users entity)
        {
            if (!entity.IsValid())
                throw new ArgumentException("Invalid user entity");
                
            await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        
        public async Task UpdateAsync(Users entity)
        {
            if (!entity.IsValid())
                throw new ArgumentException("Invalid user entity");
                
            entity.UpdatedAt = DateTime.UtcNow;
            _context.Users.Update(entity);
            await _context.SaveChangesAsync();
        }
        
        public async Task DeleteAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}