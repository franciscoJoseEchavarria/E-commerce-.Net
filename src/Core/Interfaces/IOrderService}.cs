using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NuevoProyecto.API.src.Core.Entities;
using NuevoProyecto.API.src.Application.DTOs;

namespace NuevoProyecto.API.src.Core.Interfaces
{
    public interface IOrderService: IGenericService<Order, OrderDto, OrderCreateDto>
    {
        Task<IEnumerable<OrderDto>> GetOrdersByUserIdAsync(int userId);
    }
}