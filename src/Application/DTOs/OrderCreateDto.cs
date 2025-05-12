using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NuevoProyecto.API.src.Application.DTOs
{
    public class OrderCreateDto
    {
        public int UserId { get; set; }
        public List<OrderItemCreateDto> Items { get; set; } = new List<OrderItemCreateDto>();
    
    }
}