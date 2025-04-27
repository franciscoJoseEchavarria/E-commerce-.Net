using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NuevoProyecto.API.Core.Interfaces;
using NuevoProyecto.API.Core.Entities;


namespace NuevoProyecto.API.Core.Interfaces
{
    public interface IUserRepository : IGenericRepository<Users>
    {
        Task<Users> GetByEmailAsync(string email);
    }
}