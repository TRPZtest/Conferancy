using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Conferancy.Models.ViewModels
{
    public class UsersListRequestModel
    {
        public string SortingProperty { get; set; }
        public bool IsDescending { get; set; }      
    }
}