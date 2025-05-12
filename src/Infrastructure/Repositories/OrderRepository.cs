using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NuevoProyecto.API.src.Core.Entities;
using NuevoProyecto.API.src.Infrastructure.Data; // Ensure this is the correct namespace for ApplicationDbContext
using NuevoProyecto.API.src.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace NuevoProyecto.API.src.Infrastructure.Repositories
{
    public class OrderRepository: GenericRepository<Order>, IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> GetOrdersByUserIdAsync(int userId)
        {
            return await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .Where(o => o.UserId == userId)
                .ToListAsync();
        }
    }
}