using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesler.Core.DTO;
using Tesler.Core.Entities;

namespace Tesler.Core
{
    public class Mapping
    {
        public UserDTO MapToUserDTO(User user)
        {
            return new UserDTO { Id = user.Id, Name = user.Name, Role = user.Role, Email = user.Email, Password = user.Password};
        }
        public PresenceDTO MapToPresenceDTO(Presence presence)
        {
            return new PresenceDTO { Id = presence.Id, UserId = presence.UserId, Date = presence.Date, EntryTime = presence.EntryTime, DepartureTime = presence.DepartureTime, Request = presence.Request };
        }
    }
}
