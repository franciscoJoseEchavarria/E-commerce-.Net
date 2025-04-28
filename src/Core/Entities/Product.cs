using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace NuevoProyecto.API.src.Core.Entities

{
    public class Product:BaseEntity
    {
        
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        // Implementación del método abstracto
        public override bool IsValid()
        {
            return !string.IsNullOrEmpty(Name) && Price > 0 && Stock >= 0;
        }
    }
}