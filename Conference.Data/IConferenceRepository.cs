using Conferency.Data.Db;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Conference.Data
{
    public interface IConferanceRepository
    {        
        Task<List<UsersView>> GetUsersViewAsync(string orderByProperty = "", bool isDiscending = false);
        Task<List<SortingProperty>> GetSortingPropertiesAsync();
        Task<SortingProperty> GetSortingPropertyAsync(long id);               
    }
}