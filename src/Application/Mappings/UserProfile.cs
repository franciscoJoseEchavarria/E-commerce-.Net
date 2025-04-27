using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using NuevoProyecto.API.Core.Entities;
using NuevoProyecto.API.Application.DTOs;

namespace NuevoProyecto.API.Application.Mappings
{
    public class UserProfile: Profile
    {
        
       public UserProfile()
    {
        CreateMap<Users, UserDto>();
        CreateMap<UserDto, Users>();
    }
        
    }
}