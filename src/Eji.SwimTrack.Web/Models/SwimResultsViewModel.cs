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
    public class SwimResultsViewModel
    {


        /// <summary>
        /// Constructor
        /// </summary>
        public SwimResultsViewModel(IEnumerable<SwimData> swims)
        {

        }
    }
}
