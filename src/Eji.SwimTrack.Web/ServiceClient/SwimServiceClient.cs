using Eji.SwimTrack.Service.Models;
using Eji.SwimTrack.Web.ServiceClient.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Eji.SwimTrack.Web.ServiceClient
{
    /// <summary>
    /// REST client for the swim api
    /// </summary>
    public class SwimServiceClient : ServiceClientBase, ISwimServiceClient
    {
        public SwimServiceClient(IOptions<SwimServiceClientOptions> options, IHttpClientFactory httpClientFactory)
            : base (new Uri(options.Value.Url), httpClientFactory)
        {
        }
        
        /// <summary>
        /// Adds a new swim 
        /// </summary>
        public async Task AddSwim(SwimData swimData)
        {
            await PostAsync<SwimData>(ApiUri, swimData);
        }

        /// <summary>
        /// Retrieves a single swim
        /// </summary>
        public async Task<SwimData> GetSwim(int swimId)
        {
            return await GetAsync<SwimData>(GetObjectUri(swimId));
        }

        /// <summary>
        /// Retrieve all swims
        /// </summary>
        public async Task<IEnumerable<SwimData>> GetAllSwimsAsync()
        {
            return await GetAsync<List<SwimData>>(ApiUri);
        }
    }
}
