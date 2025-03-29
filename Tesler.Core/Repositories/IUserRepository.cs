using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesler.Core.Entities;

namespace Tesler.Core.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetByUserNamePasswordAsync(string userName, string password);

    }
}
