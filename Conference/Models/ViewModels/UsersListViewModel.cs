using Conferency.Data.Db;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Conference.Models.ViewModels
{
    public class UsersListViewModel
    {
        public List<UserViewModel> Users { get; set; }
        public long CurrentUserId { get; set; }
    }

    public class UserViewModel
    {
        public long Id { get; set; }
        public string FullName { get; set; }               
        public string Password { get; set; }     
        public string Email { get; set; }

        [Column(TypeName = "date")]
        public DateTime Birthday { get; set; }
     
        public string PhoneNumber { get; set; }

        public int RegionId { get; set; }

        public int? Age { get; set; }

        public virtual Region Region { get; set; }
    }
}