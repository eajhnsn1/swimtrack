using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Eji.SwimTrack.Web.Models;
using Eji.SwimTrack.Web.ServiceClient;
using Eji.SwimTrack.Service.Models;

namespace Eji.SwimTrack.Web.Controllers
{
    public class HomeController : Controller
    {
        ISwimServiceClient swimService = null;

        public HomeController(ISwimServiceClient client)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            this.swimService = client;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<SwimData> data = await swimService.GetAllSwimsAsync();

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
