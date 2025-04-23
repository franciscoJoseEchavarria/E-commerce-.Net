using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NuevoProyecto.API.IServices
{
    public interface IUserService: IService<Users>
    {
        Task<Users> GetByEmailAsync(string email);
        Task<bool> ValidateCredentialsAsync(string email, string password);
    }
}