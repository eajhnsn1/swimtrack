using Eji.SwimTrack.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eji.SwimTrack.Web.ServiceClient
{
    /// <summary>
    /// Interface to the swim api
    /// </summary>
    public interface ISwimServiceClient
    {
        Uri ApiUri { get; }

        Task AddSwim(SwimData swimData);

        Task<SwimData> GetSwim(int swimId);

        Task<IEnumerable<SwimData>> GetAllSwimsAsync();
    }
}
