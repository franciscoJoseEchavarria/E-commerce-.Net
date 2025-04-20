using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NuevoProyecto.API.Models
{
    public class OrderItem:BaseEntity
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal PriceAtTime { get; set; }
        
        // Propiedades de navegación
        // public Order Order { get; set; }
        // public Product Product { get; set; }

        public override bool IsValid()
        {
            return OrderId > 0 && ProductId > 0 && Quantity > 0 && PriceAtTime > 0;
        }
    }
}