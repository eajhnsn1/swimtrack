using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Eji.SwimTrack.DAL.Repositories;
using Eji.SwimTrack.Models.Entities;
using Eji.SwimTrack.Service.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eji.SwimTrack.Service.Controllers
{
    [Produces("application/json")]
    [Route("api/Swim")]
    public class SwimController : Controller
    {
        ISwimRepository swimRepository = null;
        IMapper mapper = null;

        public SwimController(IMapper mapper, ISwimRepository swimRepository)
        {
            this.mapper = mapper;
            this.swimRepository = swimRepository;
        }

        // GET: api/Swim
        [HttpGet]
        public async Task<IEnumerable<SwimData>> Get()
        {
            // TODO: limit it to the user's swims
            return (await swimRepository.GetAllAsync()).Select(s => mapper.Map<SwimData>(s));
        }

        // GET: api/Swim/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<SwimData> Get(int id)
        {
            Swim swim = await swimRepository.FindAsync(id);

            return mapper.Map<SwimData>(swim);
        }
        
        // POST: api/Swim
        [HttpPost]
        public async Task Post(SwimData swimData)
        {
            Swim swim = mapper.Map<Swim>(swimData);

            int records = await swimRepository.AddAsync(swim);
            if (records == 0)
            {
                throw new InvalidOperationException("Failed to save new swim data");
            }
        }
        
        // PUT: api/Swim/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
           
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

    }
}
