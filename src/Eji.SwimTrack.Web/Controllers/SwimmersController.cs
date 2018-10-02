using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eji.SwimTrack.Web.Controllers
{
    public class SwimmersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
