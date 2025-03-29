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
    public class UserService:IUserService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IRepositoryManager _repositoryManager;
        private readonly IUserRepository _userRepository1;
        public UserService(IRepository<User> userRepository, IRepositoryManager repositoryManager,IUserRepository userRepository1)
        {
            _userRepository = userRepository;
            _repositoryManager = repositoryManager;
            _userRepository1 = userRepository1;
        }

        public async Task<List<User>> GetListAsync()
        {
            return (await _userRepository.GetAllAsync()).ToList();
        }
        public async Task<User?> GetByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<User> AddAsync(User user)
        {
            var addedUser=_userRepository.Add(user);
           await _repositoryManager.SaveAsync();
            return addedUser;
        }

        public async Task<User> UpdateAsync(User user)
        {
            var updatedUser=_userRepository.Update(user);
            await _repositoryManager.SaveAsync();
            return updatedUser;
        }

        public async Task DeleteAsync(int id)
        {
            _userRepository.Delete(id);
             await _repositoryManager.SaveAsync();
        }
        public async Task<User?> GetByUserNamePasswordAsync(string name, string password)
        {
            return await _userRepository1.GetByUserNamePasswordAsync(name, password);
        }
    }
}
