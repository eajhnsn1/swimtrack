using Eji.SwimTrack.Models.Entities;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Eji.SwimTrack.Data.Tests.SwimRepositoryTests
{
    public class DeleteShould : SwimRepositoryTestBase
    {
        [Fact]
        public void DeleteSwim_GivenIdAndTimestamp()
        {
            Swim swimToDelete = repository.GetAll().Skip(4).First();
            int id = swimToDelete.Id;
            byte[] ts = swimToDelete.Timestamp;

            repository.Delete(id, ts).Should().Be(1, "one record was effected");
            repository.Find(id).Should().BeNull("it was deleted");
        }

        [Fact]
        public void DeleteSwim_GivenSwim()
        {
            Swim swimToDelete = repository.GetAll().Skip(4).First();
            int id = swimToDelete.Id;

            repository.Delete(swimToDelete).Should().Be(1, "one record was effected");
            repository.Find(id).Should().BeNull("it was deleted");
        }
    }
}
