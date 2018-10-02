using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Eji.SwimTrack.DAL.Repositories;
using Eji.SwimTrack.Models.Entities;
using Eji.SwimTrack.Service.Converters;
using Eji.SwimTrack.Service.Models.Swimmers;
using Microsoft.AspNetCore.Mvc;

namespace Eji.SwimTrack.Service.Controllers
{
    [Produces("application/json")]
    [Route("api/Swimmer")]
    public class SwimmerController : Controller
    {
        readonly ISwimmerRepository swimmerRepository = null;
        readonly IMapper mapper = null;

        public SwimmerController(IMapper mapper, ISwimmerRepository swimmerRepository)
        {
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.swimmerRepository = swimmerRepository ?? throw new ArgumentNullException(nameof(swimmerRepository));
        }

        [HttpGet]
        public async Task<IEnumerable<SwimmerData>> Get()
        {
            // TODO: limit it to the user's swims
            return (await swimmerRepository.GetAllAsync()).Select(s => mapper.Map<SwimmerData>(s));
        }

        // GET: api/Swim/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<SwimmerData> Get(int id)
        {
            Swimmer swimmer = await swimmerRepository.FindAsync(id);

            return mapper.Map<SwimmerData>(swimmer);
        }
        
        // POST: api/Swim
        [HttpPost]
        public async Task Post(SwimmerData swimmerData)
        {
            Swimmer swim = mapper.Map<Swimmer>(swimmerData);

            int records = await swimmerRepository.AddAsync(swim);
            if (records == 0)
            {
                // TODO: throw something better
                throw new InvalidOperationException("Failed to save new swim data");
            }
        }
        
        // PUT: api/Swim/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]SwimmerData swimmerData)
        {
            if (id != swimmerData.Id)
            {
                // TODO: throw something better
                throw new InvalidOperationException("Invalid URL for the posted swim");
            }

            Swimmer swimmer = mapper.Map<Swimmer>(swimmerData);

            int records = swimmerRepository.Update(swimmer);
            if (records != 1)
            {
                // TODO: throw something better - could be an optimistic locking issue
                throw new InvalidOperationException();
            }
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}/{timestamp}")]
        public void Delete(int id, string timestamp)
        {
            byte[] tsBytes = TimeStampConverter.ConvertTimeStamp(timestamp);
            if (tsBytes == null)
            {
                throw new InvalidOperationException("Record timestamp required to delete"); 
            }

            swimmerRepository.Delete(id, tsBytes);
        }
    }
}