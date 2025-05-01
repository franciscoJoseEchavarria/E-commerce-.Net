

using Microsoft.EntityFrameworkCore;
using AutoMapper;
using NuevoProyecto.API.src.Infrastructure.Data;
using NuevoProyecto.API.src.Core.Interfaces;
using NuevoProyecto.API.src.Application.Services;
using NuevoProyecto.API.src.Core.Entities;
using NuevoProyecto.API.src.Application.DTOs;
using NuevoProyecto.API.src.Core.Interfaces;
using BCrypt.Net;



namespace NuevoProyecto.API.src.Application.Services
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

    // Método específico para registro
    public async Task<UserDto> RegisterAsync(RegisterDto registerDto)
    {
        // Validaciones adicionales
        if (registerDto.Password != registerDto.ConfirmPassword)
            throw new ArgumentException("Las contraseñas no coinciden.");

        var user = _mapper.Map<Users>(registerDto);
        user.Password = BCrypt.Net.BCrypt.HashPassword(registerDto.Password);
        
        await _userRepository.AddAsync(user);
        return _mapper.Map<UserDto>(user);
    }
    }
}