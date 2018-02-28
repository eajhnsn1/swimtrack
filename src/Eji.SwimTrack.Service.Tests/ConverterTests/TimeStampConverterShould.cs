using Eji.SwimTrack.Service.Controllers;
using Moq;
using Newtonsoft.Json;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Eji.SwimTrack.Service.Converters;

namespace Eji.SwimTrack.Service.Tests.ControllerBaseTests
{
    public class TimeStampConverterShould 
    {
        [Fact]
        public void ConvertTimeStamp_GivenEmptyString()
        {
            Assert.Null(TimeStampConverter.ConvertTimeStamp(""));
        }

        [Fact]
        public void ConvertTimeStampReturnEmpty_GivenInvalidString()
        {
            Assert.Null(TimeStampConverter.ConvertTimeStamp("a;lskdjfl;asjf883ra;j"));
        }

        [Fact]
        public void ConvertTimeStamp()
        {
            byte[] timeStamp = new byte[] { 1, 2, 3, 4, 5, 6 };
            string stringContent = JsonConvert.SerializeObject(timeStamp);

            byte[] converted = TimeStampConverter.ConvertTimeStamp(stringContent);

            Assert.True(converted.SequenceEqual(timeStamp));
        }
    }
}
