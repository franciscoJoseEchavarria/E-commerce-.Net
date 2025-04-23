using System;
using NuevoProyecto.API.Interface;
using NuevoProyecto.API.Models;
using NuevoProyecto.API.Data;
using Microsoft.EntityFrameworkCore;


namespace NuevoProyecto.API.Repository
{
    public class OrderRepository : IRepository <Order>
    {
        private readonly ApplicationDbContext _context;
        
        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

                public async Task<IEnumerable<Order>> GetAllAsync()
        {
            // Include related OrderItems when retrieving orders
            return await _context.Orders
                .Include(o => o.OrderItems)
                .ToListAsync();
        }
        
        public async Task<Order> GetByIdAsync(int id)
        {
            // Include related OrderItems when retrieving a specific order
            return await _context.Orders
                .Include(o => o.OrderItems)
                .FirstOrDefaultAsync(o => o.Id == id);
        }
        
        public async Task AddAsync(Order entity)
        {
            if (!entity.IsValid())
                throw new ArgumentException("Invalid order entity");
                
            // When adding an order, also add its order items
            await _context.Orders.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        
        public async Task UpdateAsync(Order entity)
        {
            if (!entity.IsValid())
                throw new ArgumentException("Invalid order entity");
                
            entity.UpdatedAt = DateTime.UtcNow;
            _context.Orders.Update(entity);
            await _context.SaveChangesAsync();
        }
        
        public async Task DeleteAsync(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order != null)
            {
                // When deleting an order, related OrderItems will also be deleted
                // if cascading delete is configured in your DbContext
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
            }
        }

    }
}