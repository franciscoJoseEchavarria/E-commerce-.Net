using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NuevoProyecto.API.Services
{
    public class UserServices: IUserService
    {
        private readonly IRepository<Users> _repository;
        private readonly AplicationDbContext _context;

        public UserServices(IRepository<Users> repository, AplicationDbContext context)
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
                await _repository.DeleteAsync(user);
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
                return user.Password == password;
        }
    }
}