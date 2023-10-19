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
using Conferancy.Helpers;
using Conferancy.Auth;

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

        //[HttpGet]
        //public async Task <ActionResult> Login()
        //{

        //}

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
               
                var user = Mapper.Map<User>(model);
                _repository.AddUser(user);
                await _repository.SaveChangesAsync();

                var token = _authService.GenerateJwt(user);
                var jwtCookie = new System.Web.HttpCookie("Jwt", token);
                jwtCookie.Expires = DateTime.UtcNow.AddDays(3);

                HttpContext.Response.Cookies.Add(jwtCookie);

                return RedirectToAction("UsersList");
            }
                        
            var regions = await _repository.GetRegionsAsync();
            var viewModel = new RegistrationViewModel { Regions = regions };

            return View(viewModel);
        }
        
        public async Task<ActionResult> IsEmailUnique(string email)
        {
            var existedUser = await _repository.GetUserByEmailAsync(email);

            if (existedUser != null)
                return Json("Email is already in use", JsonRequestBehavior.AllowGet);
            else
                return Json(true, JsonRequestBehavior.AllowGet);
        }

        [AuthAttribute]
        public async Task<ActionResult> UsersList()
        {
            var users = await _repository.GetUsersAsync();


            return Json(User);
        }
    }
}
