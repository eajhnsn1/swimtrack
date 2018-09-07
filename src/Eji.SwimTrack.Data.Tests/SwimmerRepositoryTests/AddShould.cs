using Eji.SwimTrack.Models.Entities;
using System;
using FluentAssertions.Extensions;
using System.Collections.Generic;
using System.Text;
using Eji.SwimTrack.Data.Tests.SwimmerRepositoryTests;
using FluentAssertions;
using Xunit;
using System.Threading.Tasks;

namespace Eji.SwimTrack.Data.Tests.RepositoryTests
{
    public class AddSingleSwimmerShould : SwimmerRepositoryTestBase
    {
        [Fact]
        public void AddASwimmer()
        {
            Swimmer newSwimmer = new Swimmer()
            {
                BirthDate = 12.February(2000),
                DisplayName = "Test Swimmer",
                FirstName = "Justin",
                LastName = "Case",
                Nickname = "TS"
            };

            int initialCount = repository.Count;

            repository.Add(newSwimmer).Should().Be(1);
            repository.Count.Should().Be(initialCount + 1);
        }

        [Fact]
        public async Task AddASwimmerAsync()
        {
            Swimmer newSwimmer = new Swimmer()
            {
                BirthDate = 12.February(2000),
                DisplayName = "Test Swimmer",
                FirstName = "Justin",
                LastName = "Case",
                Nickname = "TS"
            };

            int initialCount = repository.Count;

            (await repository.AddAsync(newSwimmer)).Should().Be(1);
            repository.Count.Should().Be(initialCount + 1);
        }
    }
}
