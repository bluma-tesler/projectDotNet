using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesler.Core.Entities;

namespace Tesler.Core.Repositories
{
    public interface IRepositoryManager
    {
        //IUserRepository Users { get; }
        //IPresenceRepository Presences { get; }
        IRepository<User> Users { get; }
        IRepository<Presence> Presences { get; }
        Task SaveAsync();
    }
}
