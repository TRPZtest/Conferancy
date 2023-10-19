using Conferency.Data.Db;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Conference.Models.ViewModels
{
    public class UsersListViewModel
    {
        public List<UsersView> Users { get; set; }
        public long CurrentUserId { get; set; }
        [Display(Name = "Sort by")]
        public List<SortingProperty> SortingProperties { get; set; }
    }    
}