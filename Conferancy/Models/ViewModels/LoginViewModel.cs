using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Conferancy.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string Email { get; set; }        
    } 
}