using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tesler.Core.Entities
{
    public class Presence
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime Date { get; set; }
        public string EntryTime { get; set; }
        public string DepartureTime { get; set; }
        public string Request { get; set; }
        
    }
}
