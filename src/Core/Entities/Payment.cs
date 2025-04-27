using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NuevoProyecto.API.Core.Entities
{
    public class Payment:BaseEntity
    {
        public int OrderId { get; set; }
       public Order Order { get; set; }
        
        public string PaymentMethod { get; set; }  // Credit Card, PayPal, etc.
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; } = DateTime.UtcNow;
        public string Status { get; set; } = "Pending";  // Pending, Completed, Failed, Refunded
        public string TransactionId { get; set; }  // ID from payment gateway
        
        // Additional fields for specific payment methods
        public string? CardLastFourDigits { get; set; }
        public string? CardHolderName { get; set; }

        public override bool IsValid()
        {
            return OrderId > 0 && Amount > 0;
        }
    }
}