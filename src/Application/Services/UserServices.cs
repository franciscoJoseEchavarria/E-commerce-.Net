

using Microsoft.EntityFrameworkCore;
using NuevoProyecto.API.Infrastructure.Data;
using NuevoProyecto.API.Core.Interface;

namespace NuevoProyecto.API.Application.Services
{
    public class UserServices: GenericService<Users, UserDto>, IUserService
    {
        private readonly IGenericRepository<Users> _repository;

        public UserServices(IGenericRepository<Users> repository, ApplicationDbContext context)
        {
            _repository = repository;
            _context = context;
        }

        public async Task<IEnumerable<Users>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }
        public async Task<Users> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }
        public async Task AddAsync(Users entity)
        {
            if (!entity.IsValid())
                throw new ArgumentException("Invalid user entity");

            await _repository.AddAsync(entity);
        }
        public async Task UpdateAsync(Users entity)
        {
            if (!entity.IsValid())
                throw new ArgumentException("Invalid user entity");

            entity.UpdatedAt = DateTime.UtcNow;
            await _repository.UpdateAsync(entity);
        }
        public async Task DeleteAsync(int id)
        {
            var user = await _repository.GetByIdAsync(id);
            if (user != null)
            {
                await _repository.DeleteAsync(user.Id);
            }
        }

        public async Task<Users> GetByEmailAsync(String email)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<bool> ValidateCredentialsAsync (String email, String password)
        {
            var user = await GetByEmailAsync(email);
            if (user == null)
                return false;
                return user.password == password;
        }
    }
}