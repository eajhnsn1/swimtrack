using Eji.SwimTrack.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eji.SwimTrack.Web.Models
{
    public class SwimSheetViewModel
    {

        List<SwimViewModel> swims = new List<SwimViewModel>();

        public IEnumerable<SwimViewModel> Swims
        {
            get { return swims; }
        }

        public string Title
        {
            get; set;
        }

        public string SubTitle
        {
            get; set;
        }

        public SwimSheetViewModel(IEnumerable<SwimData> swims, string title, string subTitle)
        {
            this.swims.AddRange(swims.Select(s => new SwimViewModel(s)));

            this.Title = title;
            this.SubTitle = subTitle;
        }
    }
}
