using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesler.Core.Entities;
using Tesler.Core.Repositories;

namespace Tesler.Data.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly DataContext _context;
        //public IUserRepository Users { get; }
        //public IPresenceRepository Presences { get; }
       public IRepository<User> Users {  get;}
        public IRepository<Presence> Presences { get;}
        public RepositoryManager(DataContext context, IRepository<User> userRepository, IRepository<Presence> presenceRepository)
        {
            _context = context;
            Users = userRepository;
            Presences = presenceRepository;
        }
        public async Task SaveAsync()
        {
           await _context.SaveChangesAsync();
        }

    }
}
