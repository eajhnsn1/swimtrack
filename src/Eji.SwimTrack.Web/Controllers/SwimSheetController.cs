using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Eji.SwimTrack.Web.Controllers
{
    public class SwimSheetController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}