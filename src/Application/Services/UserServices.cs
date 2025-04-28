

using Microsoft.EntityFrameworkCore;
using AutoMapper;
using NuevoProyecto.API.Infrastructure.Data;
using NuevoProyecto.API.Core.Interface;
using NuevoProyecto.API.Application.Services;
using NuevoProyecto.API.Core.Entities;
using NuevoProyecto.API.Application.DTOs;
using NuevoProyecto.API.Core.Interfaces;
using BCrypt.Net;



namespace NuevoProyecto.API.Application.Services
{
    public class UserServices: GenericService<Users, UserDto>, IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserServices(
            IGenericRepository<Users> genericRepository,
            IUserRepository userRepository,
            IMapper mapper
        ) : base(genericRepository, mapper)
        {
            _userRepository = userRepository;
        }

        // Método específico para obtener usuario por email
        public async Task<UserDto> GetByEmailAsync(string email)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            return _mapper.Map<UserDto>(user);
        }

        // Validar credenciales con BCrypt
        public async Task<bool> ValidateCredentialsAsync(string email, string password)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            if (user == null) return false;
            return BCrypt.Net.BCrypt.Verify(password, user.Password);
        }

    }
}