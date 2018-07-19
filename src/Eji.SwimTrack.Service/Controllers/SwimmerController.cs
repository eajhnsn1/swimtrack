using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Eji.SwimTrack.Service.Controllers
{
    public class SwimmerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}