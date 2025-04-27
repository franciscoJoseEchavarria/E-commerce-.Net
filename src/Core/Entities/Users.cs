using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NuevoProyecto.API.Core.Entities
{
    public class Users:BaseEntity
    {
        
        public string UserName { get; set; }
        public string Email { get; set; }
        public string password { get; set; }
        public string address { get; set; }
        public string phone { get; set; }

        public string city { get; set; }
        public override bool IsValid()
        {
            return !string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(Email);            
        }

        //ok
    }
}