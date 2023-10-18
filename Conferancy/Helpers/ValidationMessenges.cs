using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Conference.Helpers
{
    public static class ValidationMessenges
    {
        public static string FirstNameRequired () =>  "Please enter your first name";
        public static string SecondNameRequired() => "Please enter your second name";
        public static string SecondAgeRequired() => "Please enter your age";
        public static string RegionRequired() => "Please select your region";
        public static string EmailRequired() => "Please enter your email";
        public static string PasswordRequired() => "Please enter the password";
    }
}