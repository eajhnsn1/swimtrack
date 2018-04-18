using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eji.SwimTrack.Service.Models;
using Eji.SwimTrack.Service.Models.Common;
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

        [HttpPost]
        public async Task<IActionResult> Execute(SwimListCommand command, int[] selectedSwim)
        {
            await Task.Delay(1);


            return new OkResult();
        }

        public async Task<IActionResult> Index([FromQuery]SwimFilterModel filter)
        {
            IEnumerable<SwimData> allSwims = await swimService.GetAllSwimsAsync();

            if (filter == null)
            {
                filter = new SwimFilterModel();
            }

            IEnumerable<SwimData> swimsForDisplay = allSwims;
            if (filter.Stroke != Stroke.Unknown)
            {
                swimsForDisplay = allSwims.Where(s => s.Stroke == filter.Stroke);
            }


            SwimIndexViewModel model = new SwimIndexViewModel(swimsForDisplay, filter);

            // temporary just for the grid
            ViewBag.Data = allSwims;

            return View(model);
        }
    }
}