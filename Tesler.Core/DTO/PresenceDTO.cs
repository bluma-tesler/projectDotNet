using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesler.Core.Entities;

namespace Tesler.Core.DTO
{
    public class PresenceDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public UserDTO User { get; set; }
        public DateTime Date { get; set; }
        public string EntryTime { get; set; }
        public string DepartureTime { get; set; }
        public string Request { get; set; }
    }
}
