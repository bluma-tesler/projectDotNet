using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesler.Core.Entities;
using Tesler.Core.Repositories;

namespace Tesler.Data.Repositories
{
    public class UserRepository :Repository<User> ,IUserRepository
    {
        public UserRepository(DataContext context):base(context)
        {
           
        }
        public async Task<User?> GetByUserNamePasswordAsync(string userName,string password)
        {
            return await this._dbSet
               .Where(u => u.Name == userName && u.Password == password)
               .FirstOrDefaultAsync();
        }
    }
}
