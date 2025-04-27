using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using NuevoProyecto.API.Core.Entities;
using NuevoProyecto.API.Core.Interfaces;
using NuevoProyecto.API.Infrastructure.Data; 
using NuevoProyecto.API.Infrastructure.Repositories;
using NuevoProyecto.API.Core.Interfaces;


namespace NuevoProyecto.API.Infrastructure.Repositories
{
    public class UserRepository: GenericRepository<Users>,  IUserRepository
    {
        
    public UserRepository(ApplicationDbContext context) : base(context) { }

    public async Task<Users> GetByEmailAsync(string email)
    {
        return await _context.Set<Users>().FirstOrDefaultAsync(u => u.Email == email);
    }

        
    }
}