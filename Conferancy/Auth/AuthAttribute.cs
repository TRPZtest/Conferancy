using Conference.Helpers;
using Conference.Data;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace Conference.Auth
{
    public class AuthAttribute : FilterAttribute, IAuthenticationFilter
    {     
        private readonly AuthService _authService;
        private readonly bool _redirectToLoginPage;

        public AuthAttribute(bool redirectToLoginPage)
        {          
            _authService = new AuthService();
            _redirectToLoginPage = redirectToLoginPage;
        }

        public void OnAuthentication(AuthenticationContext filterContext)
        {

            var token = filterContext.HttpContext.Request.Cookies.Get("Jwt")?.Value;
            
            if (string.IsNullOrEmpty(token) && _redirectToLoginPage)
                filterContext.Result = new HttpUnauthorizedResult();

            var userId = _authService.ValidateJwt(token);

            if (userId == 0 && _redirectToLoginPage)      
                filterContext.Result = new HttpUnauthorizedResult();          
            else
                filterContext.HttpContext.AddUserId(userId);

        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            
            var userId = filterContext.HttpContext.GetUserId();
            if (userId == 0 && _redirectToLoginPage)
                filterContext.Result = new RedirectToRouteResult(
                    new System.Web.Routing.RouteValueDictionary 
                    {
                        { "controller", "Conference" }, 
                        { "action", "Login" }
                    });
        }
    }
}