using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FluentAssertions;
using Eji.SwimTrack.Models.Entities;
using System.Linq;

namespace Eji.SwimTrack.Data.Tests.SwimmerRepositoryTests
{
    public class DeleteShould : SwimmerRepositoryTestBase
    {
        [Fact]
        public void DeleteSwim_GivenIdAndTimestamp()
        {
            Swimmer swimmerToDelete = repository.GetAll().Skip(4).First();
            int id = swimmerToDelete.Id;
            byte[] ts = swimmerToDelete.Timestamp;

            repository.Delete(id, ts).Should().Be(1, "one record was effected");
            repository.Find(id).Should().BeNull("it was deleted");
        }

        [Fact]
        public void DeleteSwim_GivenSwim()
        {
            Swimmer swimToDelete = repository.GetAll().Skip(4).First();
            int id = swimToDelete.Id;

            repository.Delete(swimToDelete).Should().Be(1, "one record was effected");
            repository.Find(id).Should().BeNull("it was deleted");
        }
    }
}
