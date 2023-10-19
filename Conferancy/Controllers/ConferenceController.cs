using Conference.Di;
using Conference.Data;
using Conference.Data.Db;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Conference.Models.ViewModels;
using AutoMapper;
using Conference.Helpers;
using Conference.Auth;

namespace Conference.Controllers
{
    public class ConferenceController : Controller
    {
        private readonly IConferanceRepository _repository;
        private readonly AuthService _authService;

        public ConferenceController(IConferanceRepository repository)
        {
            _repository = repository;
            _authService = new AuthService();
        }

        [HttpGet]
        public ActionResult Login(LoginViewModel viewModel = null)
        {            
            return View(viewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginRequestModel request)
        {
            if (ModelState.IsValid)
            {
                var hashedPassword = PasswordHelper.HashPassword(request.Password);

                var user = await _repository.GetUserAsync(request.Email, hashedPassword);

                if (user == null)
                    return View(new LoginViewModel { ErrorMessage = "Invalid email or password" });
                else
                {
                    setAuthCoockie(user);
                        
                    return RedirectToAction("UsersList");
                }
            }
            else
                return View("Error");
        }

        [HttpGet]
        public async Task <ActionResult> Registration()
        {
            var regions = await _repository.GetRegionsAsync();

            var viewModel = new RegistrationViewModel { Regions = regions };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Registration(RegistrationViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.Password = PasswordHelper.HashPassword(model.Password);
               
                var user = AutoMapper.Mapper.Map<User>(model);
                _repository.AddUser(user);
                await _repository.SaveChangesAsync();

                setAuthCoockie(user);

                return RedirectToAction("UsersList");
            }
                        
            var regions = await _repository.GetRegionsAsync();
            var viewModel = new RegistrationViewModel { Regions = regions };

            return View(viewModel);
        }

        [HttpPost]       
        public ActionResult Logout()
        {
            var jwt = HttpContext.Response.Cookies.Get("Jwt");

            jwt.Expires = DateTime.Now;

            return RedirectToAction("", ""); //Home Index
        }
        
        public async Task<ActionResult> IsEmailUnique(string email)
        {
            var existedUser = await _repository.GetUserByEmailAsync(email);

            if (existedUser != null)
                return Json("Email is already in use", JsonRequestBehavior.AllowGet);
            else
                return Json(true, JsonRequestBehavior.AllowGet);
        }
       
        [AllowAnonymous]
        [AuthAttribute(redirectToLoginPage: false)]
        public async Task<ActionResult> UsersList()
        {
            var users = await _repository.GetUsersAsync();
            var currentUserId = HttpContext.GetUserId();

            var viewModel = new UsersListViewModel { CurrentUserId = currentUserId, Users = users }; 

            return View(viewModel);
        }

        private void setAuthCoockie(User user)
        {
            var token = _authService.GenerateJwt(user);
            var jwtCookie = new System.Web.HttpCookie("Jwt", token)
            {
                Expires = DateTime.UtcNow.AddDays(3)
            };

            HttpContext.Response.Cookies.Add(jwtCookie);
        }
    }
}
