using System;
using System.Collections.Generic;
using System.Text;
using Eji.SwimTrack.Models.Entities;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;

namespace Eji.SwimTrack.Data.Tests.SwimRepositoryTests
{
    public class UpdateShould : SwimRepositoryTestBase
    {
        [Fact]
        public void UpdateTheRecord()
        {
            Swim swim = repository.GetFirst();

            swim.Distance = 99;
            repository.Update(swim).Should().Be(1, "a single row was impacted");

            // make sure an add wasn't performed
            repository.GetFirst().Distance.Should().Be(99, "it was updated");
        }

        [Fact]
        public void NotAddARecord()
        {
            Swim swim = repository.GetFirst();
            int initialCount = repository.Count;

            swim.Distance = 99;
            repository.Update(swim).Should().Be(1, "a single row was impacted");

            // make sure an add wasn't performed
            repository.Count.Should().Be(initialCount, "we updated a record, not added one");
        }
    }
}
