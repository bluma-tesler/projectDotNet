using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesler.Core.Entities;
using Tesler.Core.Repositories;
using Microsoft.EntityFrameworkCore;
namespace Tesler.Data.Repositories
{
    public class PresenceRepository:IPresenceRepository
    {
        private readonly DataContext _context;
        public PresenceRepository(DataContext context)
        {
            _context = context;
        }
        public List<Presence> GetAll()
        {
            return _context.Presences.Include(u => u.User).ToList();
        }
        public Presence? GetById(int id)
        {
            return _context.Presences.FirstOrDefault(x => x.Id == id);
        }
        public Presence Add(Presence presence)
        {
            _context.Presences.Add(presence);
            _context.SaveChanges();
            return presence;
        }

        public Presence Update(Presence presence)
        {
            var existingPresence = GetById(presence.Id);
            if (existingPresence is null)
            {
                throw new Exception("Presence not found");
            }
            existingPresence.EntryTime = presence.EntryTime;
            existingPresence.DepartureTime = presence.DepartureTime;
            _context.SaveChanges();
            return existingPresence;
        }

        public void Delete(int id)
        {
            var existingPresence = GetById(id);
            if (existingPresence is not null)
            {
                _context.Presences.Remove(existingPresence);
            }
            _context.SaveChanges();
        }
    }
}
