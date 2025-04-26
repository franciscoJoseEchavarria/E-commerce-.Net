using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NuevoProyecto.API.Models
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = TimeZoneInfo.ConvertTimeFromUtc(
            DateTime.UtcNow, 
            TimeZoneInfo.FindSystemTimeZoneById("SA Pacific Standard Time")
        );
        public DateTime? UpdatedAt { get; set; } = TimeZoneInfo.ConvertTimeFromUtc(
            DateTime.UtcNow, 
            TimeZoneInfo.FindSystemTimeZoneById("SA Pacific Standard Time")
        );
        
        
        // Método abstracto que todas las entidades deben implementar
        public abstract bool IsValid();
    }
}