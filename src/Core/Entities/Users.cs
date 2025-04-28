using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NuevoProyecto.API.src.Core.Entities

{
    public class Users:BaseEntity
    {
        
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public string City { get; set; }
        public override bool IsValid()
        {
            return !string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(Email);            
        }

        //ok
    }
}