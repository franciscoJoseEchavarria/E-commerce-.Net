using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NuevoProyecto.API.src.Core.Entities

{
    public class Order : BaseEntity
    {
        public int UserId { get; set; }
    // public User User { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } = "Pending";
        
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        //  public Shipping Shipping { get; set; }
        // public Payment Payment { get; set; }
        
        public override bool IsValid()
        {
            return UserId > 0 && TotalAmount >= 0;
        }
    }
}