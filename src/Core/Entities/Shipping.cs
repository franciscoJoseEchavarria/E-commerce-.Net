using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NuevoProyecto.API.Core.Entities
{
    public class Shipping:BaseEntity
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }
        
        public string ShippingAddress { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string RecipientName { get; set; }
        public string RecipientPhone { get; set; }
        
        public string Status { get; set; } = "Pending";  // Pending, Shipped, Delivered, Returned
        public string? TrackingNumber { get; set; }
            public override bool IsValid()
        {
            return OrderId > 0 && 
                   !string.IsNullOrEmpty(ShippingAddress) && 
                   !string.IsNullOrEmpty(City) && 
                   !string.IsNullOrEmpty(Country) && 
                   !string.IsNullOrEmpty(RecipientName);
        }
    }
}