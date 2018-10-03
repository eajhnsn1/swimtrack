using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Eji.SwimTrack.Service.Models.Swimmers;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Eji.SwimTrack.Web.ServiceClient
{
    public class SwimmerServiceClient : ServiceClientBase, ISwimmerServiceClient
    {
        const string CONFIG_SWIMMERAPIURI = "SwimTrackServices:SwimmerApiUrl";

        public SwimmerServiceClient(IConfiguration configuration, IHttpClientFactory httpClientFactory)
            : base(configuration, httpClientFactory, CONFIG_SWIMMERAPIURI)
        {
        }
        
        /// <summary>
        /// Adds a new swim 
        /// </summary>
        public async Task AddSwimmer(SwimmerData swimmerData)
        {
            await PostAsync<SwimmerData>(ApiUri, swimmerData);
        }

        /// <summary>
        /// Retrieves a single swim
        /// </summary>
        public async Task<SwimmerData> GetSwimmer(int swimmerId)
        {
            return await GetAsync<SwimmerData>(GetObjectUri(swimmerId));
        }

        /// <summary>
        /// Retrieve all swims
        /// </summary>
        public async Task<IEnumerable<SwimmerData>> GetAllSwimmersAsync()
        {
            return await GetAsync<List<SwimmerData>>(ApiUri);
        }
    }
}
