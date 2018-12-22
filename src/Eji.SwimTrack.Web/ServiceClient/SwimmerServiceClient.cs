using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Eji.SwimTrack.Service.Models.Swimmers;
using Eji.SwimTrack.Web.ServiceClient.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Eji.SwimTrack.Web.ServiceClient
{
    public class SwimmerServiceClient : ServiceClientBase, ISwimmerServiceClient
    {
        public SwimmerServiceClient(IOptions<SwimmerServiceClientOptions> options, IHttpClientFactory httpClientFactory)
            : base(new Uri(options.Value.Url), httpClientFactory)
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
