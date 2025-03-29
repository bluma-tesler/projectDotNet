using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesler.Core.DTO;
using Tesler.Core.Entities;

namespace Tesler.Core
{
    public class MappingProfile:Profile
    {
        public MappingProfile() 
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Presence, PresenceDTO>().ReverseMap();
        }
    }
}
