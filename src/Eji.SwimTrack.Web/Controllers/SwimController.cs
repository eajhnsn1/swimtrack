using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eji.SwimTrack.Service.Models;
using Eji.SwimTrack.Web.Models;
using Eji.SwimTrack.Web.ServiceClient;
using Microsoft.AspNetCore.Mvc;

namespace Eji.SwimTrack.Web.Controllers
{
    public class SwimController : Controller
    {
        ISwimServiceClient swimService = null;

        /// <summary>
        /// Constructor
        /// </summary>
        public SwimController(ISwimServiceClient client)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            swimService = client;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<SwimData> data = await swimService.GetAllSwimsAsync();

            SwimIndexViewModel model = new SwimIndexViewModel(data);

            // temporary just for the grid
            ViewBag.Data = data;

            return View(model);
        }
    }
}