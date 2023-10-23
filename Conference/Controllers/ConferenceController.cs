using Conference.Di;
using Conference.Data;
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
using Conferency.Data.Db;

namespace Conference.Controllers
{
    public class ConferenceController : Controller
    {
        private readonly IConferanceRepository _repository;   

        public ConferenceController(IConferanceRepository repository)
        {
            _repository = repository;            
        }
                                                    
        [AuthAttribute(redirectToLoginPage: false)]
        public async Task<ActionResult> UsersList()
        {
            var users = await _repository.GetUsersViewAsync();
            var currentUserId = HttpContext.GetUserId();

            var sortingProperties = await _repository.GetSortingPropertiesAsync();

            var viewModel = new UsersListViewModel { CurrentUserId = currentUserId, Users = users, SortingProperties = sortingProperties }; 

            return View(viewModel);
        }

        [AuthAttribute(redirectToLoginPage: false)]
        public async Task<ActionResult> SortedUsers(long propertyId)
        {         
            if (ModelState.IsValid)
            {
                var currentUserId = HttpContext.GetUserId();            

                var property = await _repository.GetSortingPropertyAsync(propertyId);

                var users = await _repository.GetUsersViewAsync(property.SortingColumn.ColumnName, property.IsDescending);
               
                return PartialView("UsersListPartial", new UsersListViewModel { Users = users, CurrentUserId = currentUserId });
            }
            else return View("Error");
        }       
    }
}
