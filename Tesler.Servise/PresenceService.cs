using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesler.Core.Entities;
using Tesler.Core.Repositories;
using Tesler.Core.Services;

namespace Tesler.Servise
{
    public class PresenceService : IPresenceService
    {
        private readonly IRepository<Presence> _presenceRepository;
        private readonly IRepositoryManager _repositoryManager;
        public PresenceService(IRepository<Presence> presenceRepository, IRepositoryManager repositoryManager)
        {
            _presenceRepository = presenceRepository;
            _repositoryManager = repositoryManager;
        }
        public async Task<List<Presence>> GetListAsync()
        {
            return (await _presenceRepository.GetAllAsync()).ToList();
        }
        public async Task<Presence?> GetByIdAsync(int id)
        {
            return await _presenceRepository.GetByIdAsync(id);
        }

        public async Task<Presence> AddAsync(Presence presence)
        {
            var addedPresence=_presenceRepository.Add(presence);
            await _repositoryManager.SaveAsync();
            return addedPresence;
        }

        public async Task<Presence> UpdateAsync(Presence presence)
        {
            var updatedPresence=_presenceRepository.Update(presence);
            await _repositoryManager.SaveAsync();
            return updatedPresence;
        }

        public async Task DeleteAsync(int id)
        {
            _presenceRepository.Delete(id);
           await _repositoryManager.SaveAsync();
        }

    }
}
