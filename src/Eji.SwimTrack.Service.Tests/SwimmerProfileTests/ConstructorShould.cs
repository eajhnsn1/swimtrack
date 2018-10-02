using AutoMapper;
using Eji.SwimTrack.Models.Entities;
using Eji.SwimTrack.Service.DataMapping;
using Eji.SwimTrack.Service.Models.Swimmers;
using FluentAssertions;
using FluentAssertions.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Eji.SwimTrack.Service.Tests.SwimmerProfileTests
{
    [Collection("AutoMapper")]
    public class ConstructorShould
    {
        public ConstructorShould()
        {
            Mapper.Reset();
            Mapper.Initialize(m => m.AddProfile<SwimmerProfile>());
        }

        [Fact]
        public void MapSwimmerToSwimmerData()
        {
            Swimmer swimmer = new Swimmer()
            {
                FirstName = "John",
                LastName = "Doe",
                Nickname = "Johnny",
                BirthDate = 29.October(1999),
                DisplayName = "John Doe",
                Id = 1000,
            };

            SwimmerData swimmerData = Mapper.Map<SwimmerData>(swimmer);

            swimmerData.Should().NotBeNull();
            swimmerData.FirstName.Should().Be(swimmer.FirstName);
            swimmerData.LastName.Should().Be(swimmer.LastName);
            swimmerData.Nickname.Should().Be(swimmer.Nickname);
            swimmerData.BirthDate.Should().Be(swimmer.BirthDate);
            swimmerData.DisplayName.Should().Be(swimmer.DisplayName);
            swimmerData.Id.Should().Be(swimmer.Id);
        }
    }
}
