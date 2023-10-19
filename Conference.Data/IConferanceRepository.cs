using Conference.Data.Db;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Conference.Data
{
    public interface IConferanceRepository
    {
        void AddUser(User user);
        Task<List<Region>> GetRegionsAsync();
        Task<User> GetUserByEmailAsync(string email);
        Task<User> GetUserAsync(string email, string password);
        Task<List<User>> GetUsersAsync(int page = 0, int pageSize = 0);
        Task SaveChangesAsync();
    }
}