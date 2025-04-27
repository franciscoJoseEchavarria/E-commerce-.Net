
using NuevoProyecto.API.Core.Entities;
using NuevoProyecto.API.Application.DTOs;

namespace NuevoProyecto.API.Core.Interface
{
    public interface IUserService:IGenericService<Users, UserDto>
    {
        Task<Users> GetByEmailAsync(string email);
        Task<bool> ValidateCredentialsAsync(string email, string password);
    }
}