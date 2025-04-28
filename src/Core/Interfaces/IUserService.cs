
using NuevoProyecto.API.src.Core.Entities
;
using NuevoProyecto.API.src.Application.DTOs;

namespace NuevoProyecto.API.src.Core.Interfaces


{
    public interface IUserService:IGenericService<Users, UserDto>
    {
        Task<UserDto> GetByEmailAsync(string email);
        Task<bool> ValidateCredentialsAsync(string email, string password);
    }
}