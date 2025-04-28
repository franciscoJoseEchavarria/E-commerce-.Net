using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using NuevoProyecto.API.src.Core.Entities;
using NuevoProyecto.API.src.Application.DTOs;

namespace NuevoProyecto.API.src.Application.Mappings
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