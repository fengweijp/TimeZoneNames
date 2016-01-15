﻿using System.Diagnostics;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace TimeZoneNames.Tests
{
    public class TimeZoneCountriesTests
    {
        private readonly ITestOutputHelper _output;

        public TimeZoneCountriesTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void Can_Get_Zones_For_US()
        {
            var zones = TimeZoneNames.GetTimeZoneIdsForCountry("US");

            foreach (var zone in zones)
                _output.WriteLine(zone);

            Assert.Equal(29, zones.Length);

            Assert.True(zones.Contains("America/New_York"));
            Assert.True(zones.Contains("America/Chicago"));
            Assert.True(zones.Contains("America/Denver"));
            Assert.True(zones.Contains("America/Los_Angeles"));
            Assert.True(zones.Contains("America/Phoenix"));
            Assert.True(zones.Contains("Pacific/Honolulu"));

            Assert.True(!zones.Contains("Europe/London"));
        }

        [Fact]
        public void Can_Get_Zones_For_GB()
        {
            var zones = TimeZoneNames.GetTimeZoneIdsForCountry("GB");

            foreach (var zone in zones)
                _output.WriteLine(zone);

            Assert.Equal(1, zones.Length);

            Assert.Equal("Europe/London", zones[0]);
        }

        [Fact]
        public void Can_Get_Zones_For_RU()
        {
            var zones = TimeZoneNames.GetTimeZoneIdsForCountry("RU");

            foreach (var zone in zones)
                _output.WriteLine(zone);

            Assert.Equal(21, zones.Length);

            Assert.True(zones.Contains("Europe/Moscow"));
            Assert.True(zones.Contains("Europe/Kaliningrad"));
            Assert.True(zones.Contains("Asia/Vladivostok"));
            Assert.True(zones.Contains("Asia/Kamchatka"));
            
            Assert.True(!zones.Contains("Europe/London"));
        }

        [Fact]
        public void Can_Get_Zones_For_CA()
        {
            var zones = TimeZoneNames.GetTimeZoneIdsForCountry("CA");

            foreach (var zone in zones)
                _output.WriteLine(zone);

            Assert.Equal(28, zones.Length);

            Assert.True(zones.Contains("America/Vancouver"));
            Assert.True(zones.Contains("America/Fort_Nelson"));
            Assert.True(zones.Contains("America/Toronto"));

            Assert.True(!zones.Contains("Europe/London"));
        }
    }
}
