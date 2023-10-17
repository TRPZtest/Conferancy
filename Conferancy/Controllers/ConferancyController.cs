using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Conferancy.Controllers
{
    public class ConferancyController : Controller
    {
        public ConferancyController() { }
        public async Task<ActionResult> Registration()
        {
            return View();
        }
    }
}
