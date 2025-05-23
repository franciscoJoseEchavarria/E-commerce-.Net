using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NuevoProyecto.API.src.Core.Entities

{
    public class Category : BaseEntity
    {
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<Product> Products { get; set; } = new List<Product>();
    
    public override bool IsValid()
    {
        return !string.IsNullOrEmpty(Name);
    }
}

}