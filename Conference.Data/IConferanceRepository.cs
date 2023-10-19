using Conferency.Data.Db;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Conference.Data
{
    public interface IConferanceRepository
    {
        void AddUser(User user);
        Task<List<Region>> GetRegionsAsync();
        Task<List<User>> GetSortedUsersAsync(bool isDiscending = false, params string[] properties);
        Task<List<SortingProperty>> GetSortingPropertiesAsync();
        Task<SortingProperty> GetSortingPropertyAsync(long id);
        Task<User> GetUserAsync(string email, string password);
        Task<User> GetUserByEmailAsync(string email);
        Task<List<User>> GetUsersAsync(int page = 0, int pageSize = 0);
        Task SaveChangesAsync();
    }
}