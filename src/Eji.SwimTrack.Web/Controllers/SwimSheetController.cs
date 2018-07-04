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
    public class SwimSheetController : Controller
    {
        ISwimServiceClient swimService = null;

        public SwimSheetController(ISwimServiceClient swimService)
        {
            this.swimService = swimService ?? throw new ArgumentNullException(nameof(swimService));
        }
        public async Task<IActionResult> Index(string meetTitle, string meetSubtitle, int[] selectedSwim)
        {
            List<SwimData> swimsToPrint = new List<SwimData>();

            // obtain all of the swims, sequentially for now
            foreach (int id in selectedSwim)
            {
                swimsToPrint.Add(await swimService.GetSwim(id));
            }


            SwimSheetViewModel vm = new SwimSheetViewModel(swimsToPrint, meetTitle, meetSubtitle);


            return View(vm);
        }
    }
}