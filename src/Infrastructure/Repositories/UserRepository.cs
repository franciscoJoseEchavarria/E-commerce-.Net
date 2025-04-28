using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using NuevoProyecto.API.src.Core.Entities
;
using NuevoProyecto.API.src.Core.Interfaces
;
using NuevoProyecto.API.src.Infrastructure.Data
; 
using NuevoProyecto.API.src.Infrastructure.Repositories
;
using NuevoProyecto.API.src.Core.Interfaces
;


namespace NuevoProyecto.API.src.Infrastructure.Repositories

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