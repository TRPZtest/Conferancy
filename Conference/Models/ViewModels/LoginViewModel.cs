using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Conference.Models.ViewModels
{
    public class LoginViewModel
    {
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
        [Display(Name = "Login email")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Required]
        public string Email { get; set; }
        public string ErrorMessage { get; set; }
    } 

    public class LoginRequestModel
    {
       
        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }
    }
}