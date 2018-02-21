using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Eji.SwimTrack.DAL.Repositories;
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
            return swimRepository.GetAll().Select(s => mapper.Map<SwimData>(s));
        }

        // GET: api/Swim/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {

            return "value";

        }
        
        // POST: api/Swim
        [HttpPost]
        public void Post([FromBody]string value)
        {
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
