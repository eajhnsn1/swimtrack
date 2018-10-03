using Eji.SwimTrack.Service.Models.Swimmers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eji.SwimTrack.Web.ServiceClient
{
    /// <summary>
    /// Interface to the Swimmer API
    /// </summary>
    interface ISwimmerServiceClient
    {
        Uri ApiUri { get; }

        Task AddSwimmer(SwimmerData swimmerData);

        Task<SwimmerData> GetSwimmer(int swimmerId);

        Task<IEnumerable<SwimmerData>> GetAllSwimmersAsync();
    }
}
