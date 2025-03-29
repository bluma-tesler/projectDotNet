using Tesler.Core.Entities;

namespace Tesler.API.Models
{
    public class PresencePostModel
    {
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public string EntryTime { get; set; }
        public string DepartureTime { get; set; }
        public string Request { get; set; }
    }
}
