using Conference.Data.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Conference.Models.ViewModels
{
    public class UsersListViewModel
    {
        public List<User> Users { get; set; }
        public long CurrentUserId { get; set; }
    }
}