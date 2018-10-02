using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;
using AutoMapper;
using Eji.SwimTrack.Service.Controllers;
using Eji.SwimTrack.Models.Entities;
using Eji.SwimTrack.Service.Models;
using Eji.SwimTrack.DAL.Repositories;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FluentAssertions;
using FluentAssertions.Extensions;
using Eji.SwimTrack.Models;
using Eji.SwimTrack.Service.Models.Swimmers;

namespace Eji.SwimTrack.Service.Tests.SwimmerControllerTests
{
    public abstract class SwimmerControllerTestBase
    {
        // rather than mock mapping, just using a dead simple automapper map
        protected IMapper simpleMapper;

        // mock repository
        protected Mock<ISwimmerRepository> swimmerRepo;

        // fake swimmers
        protected List<Swimmer> swimmers;

        public SwimmerControllerTestBase()
        {
            MapperConfiguration mapConfig = new MapperConfiguration(e =>
            {
                e.CreateMap<Swimmer, SwimmerData>();
                e.CreateMap<SwimmerData, Swimmer>();
            });
            simpleMapper = mapConfig.CreateMapper();

            swimmers = new List<Swimmer>()
            {
                new Swimmer() { FirstName = "Jane", LastName="Doe", BirthDate = 4.January(2010), DisplayName="Jane Doe", Nickname="Janie", Id=1 },
                new Swimmer() { FirstName = "John", LastName="Doe", BirthDate = 24.June(2005), DisplayName="John Doe", Nickname="Buttercup", Id=2 }
            };

            Task<IEnumerable<Swimmer>> repoResult = Task<IEnumerable<Swimmer>>.FromResult<IEnumerable<Swimmer>>(swimmers);

            swimmerRepo = new Mock<ISwimmerRepository>();
            swimmerRepo.Setup(r => r.GetAllAsync()).Returns(repoResult);
            swimmerRepo.Setup(r => r.GetAll()).Returns(swimmers);
        }
    }
}
