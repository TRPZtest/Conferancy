using Conference.Data;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace Conferancy.Auth
{
    public class AuthAttribute : FilterAttribute, IAuthenticationFilter
    {     
        private readonly AuthService _authService;

        public AuthAttribute()
        {          
            _authService = new AuthService();
        }

        public void OnAuthentication(AuthenticationContext filterContext)
        {

            var token = filterContext.HttpContext.Request.Cookies.Get("Jwt")?.Value;
            
            if (string.IsNullOrEmpty(token))
                filterContext.Result = new HttpUnauthorizedResult();

            var userId = _authService.ValidateJwt(token);           
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(
                new System.Web.Routing.RouteValueDictionary 
                {
                    { "controller", "Conference" }, 
                    { "action", "Login" }
                });
        }
    }
}