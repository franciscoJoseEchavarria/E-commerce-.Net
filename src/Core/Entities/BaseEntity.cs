using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NuevoProyecto.API.src.Core.Entities

{
    public abstract class BaseEntity
    {
    public int Id { get; set; }
    
    private DateTime _createdAt = DateTime.UtcNow; // Usa UTC directamente
    public DateTime CreatedAt 
    {
        get => _createdAt;
        set => _createdAt = DateTime.SpecifyKind(value, DateTimeKind.Utc);
    }
    
    private DateTime? _updatedAt;
    public DateTime? UpdatedAt 
    {
        get => _updatedAt;
        set => _updatedAt = value.HasValue 
            ? DateTime.SpecifyKind(value.Value, DateTimeKind.Utc) 
            : null;
    }
    
    public abstract bool IsValid();
}
}