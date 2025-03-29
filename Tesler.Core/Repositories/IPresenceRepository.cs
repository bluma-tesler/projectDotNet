using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesler.Core.Entities;

namespace Tesler.Core.Repositories
{
    public interface IPresenceRepository
    {
        public List<Presence> GetAll();
        public Presence? GetById(int id);
        public Presence Add(Presence presence);
        public Presence Update(Presence presence);
        void Delete(int id);
    }
}
