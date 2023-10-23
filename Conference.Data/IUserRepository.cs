using Conferency.Data.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conferency.Data
{
    public interface IUserRepository
    {
        void AddUser(User user);
        Task<List<Region>> GetRegionsAsync();
        Task<User> GetUserAsync(string email, string password);
        Task<User> GetUserByEmailAsync(string email);
        Task SaveChangesAsync();
    }
}
