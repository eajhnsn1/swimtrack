using System;
using System.Collections.Generic;
using System.Text;
using Eji.SwimTrack.Models.Entities;
using FluentAssertions;
using Xunit;

namespace Eji.SwimTrack.Data.Tests.SwimmerRepositoryTests
{
    public class UpdateShould : SwimmerRepositoryTestBase
    {

        [Fact]
        public void UpdateTheRecord()
        {
            Swimmer swimmer = repository.GetFirst();

            swimmer.DisplayName = "Updated from Unit Test";
            repository.Update(swimmer).Should().Be(1, "a single row was impacted");

            // make sure an add wasn't performed
            repository.GetFirst().DisplayName.Should().Be("Updated from Unit Test", "it was updated");
        }

        [Fact]
        public void NotAddARecord()
        {
            Swimmer swimmer = repository.GetFirst();
            int initialCount = repository.Count;

            swimmer.DisplayName = "Updated...";
            repository.Update(swimmer).Should().Be(1, "a single row was impacted");

            // make sure an add wasn't performed
            repository.Count.Should().Be(initialCount, "we updated a record, not added one");
        }
    }
}
