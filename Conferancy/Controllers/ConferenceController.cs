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

namespace Conference.Controllers
{
    public class ConferenceController : Controller
    {
        private readonly IConferanceRepository _repository;

        public ConferenceController(IConferanceRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task <ActionResult> Registration()
        {
            var regions = await _repository.GetRegionsAsync();

            var viewModel = new RegistrationViewModel { Regions = regions };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Registration(User user)
        {
            return View();
        }
    }
}
