using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesler.Core.Entities;

namespace Tesler.Core.Services
{
    public interface IPresenceService
    {
        Task<List<Presence>> GetListAsync();
        Task<Presence?> GetByIdAsync(int id);
        Task<Presence> AddAsync(Presence presence);
        Task<Presence> UpdateAsync(Presence presence);
        Task DeleteAsync(int id);
    }
}
