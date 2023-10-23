using Conferency.Data.Db;
using System.Linq.Dynamic.Core;
using Conferency.Data.Helpers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Conference.Data
{
    public class ConferanceRepository : IConferanceRepository
    {
        private readonly AppDbContext _context;

        public ConferanceRepository(AppDbContext context)
        {
            _context = context;
        }                 
        
        public async Task<List<SortingProperty>> GetSortingPropertiesAsync()
        {
            var properties = await _context.SortingProperties
                .AsNoTracking()
                .ToListAsync();

            return properties;
        }

        public async Task<SortingProperty> GetSortingPropertyAsync(long id)
        {
            var property = await _context.SortingProperties
                .Include(x => x.SortingColumn)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            return property;
        }
        
        public async Task<List<UsersView>> GetUsersViewAsync(string orderByProperty = "", bool isDiscending = false)
        {
            if (string.IsNullOrEmpty(orderByProperty))
                return await _context.UsersViews.ToListAsync();
            if (isDiscending)
                return await _context.UsersViews
                    .OrderByDescendingDynamic(x => $"x.{orderByProperty}")
                    .ToListAsync();
            else 
                return await _context.UsersViews
                .OrderByDynamic(x => $"x.{orderByProperty}")
                .ToListAsync();
        }        
    }
}
