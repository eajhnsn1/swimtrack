using Eji.SwimTrack.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eji.SwimTrack.Web.Models
{
    /// <summary>
    /// ViweModel for SwimController.Index, a list of swim search results
    /// </summary>
    public class SwimIndexViewModel
    {
        List<SwimViewModel> swims = new List<SwimViewModel>();

        public SwimEditViewModel NewSwim
        {
            get; set;
        }

        public IEnumerable<SwimViewModel> Swims
        {
            get { return swims; }
        }

        public int[] SelectedSwims { get; set; }

        public SwimFilterModel Filter
        {
            get; set;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public SwimIndexViewModel(IEnumerable<SwimData> swims, SwimFilterModel filter)
        {
            if (swims == null)
            {
                throw new ArgumentNullException(nameof(swims));
            }

            Filter = filter;

            this.swims.AddRange(swims.Select(s => new SwimViewModel(s)));
        }
    }
}
