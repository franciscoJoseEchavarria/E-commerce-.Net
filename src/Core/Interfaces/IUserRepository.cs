using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NuevoProyecto.API.src.Core.Interfaces
;
using NuevoProyecto.API.src.Core.Entities
;


namespace NuevoProyecto.API.src.Core.Interfaces

{
    public interface IUserRepository : IGenericRepository<Users>
    {
        Task<Users> GetByEmailAsync(string email);
    }
}