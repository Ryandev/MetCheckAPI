
using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using Xunit;

using MetCheckAPI;


namespace UnitTest
{
    public class TestDeserialize
    {
        [Fact]
        public void TestDeserializeResponse0()
        {
            string path = Asset.PathForResource("ExampleResponse0.txt");
            string response = System.IO.File.ReadAllText(path);
            Assert.True(response.Length > 0);

            JsonSerializerOptions options = new JsonSerializerOptions();
            options.IgnoreNullValues = true;

            ForecastBody data = JsonSerializer.Deserialize<ForecastBody>(response, options);

            Assert.Equal(2020, data.TimeStamp.Year);
            Assert.Equal(5, data.TimeStamp.Month);
            Assert.Equal(8, data.TimeStamp.Day);

            Assert.Single(data.MetData.Forecast.Forecasts);

            ForecastSnapshot item = data.MetData.Forecast.Forecasts[0];

            Assert.InRange<double>(item.Temperature, 12.9, 13.1);
            Assert.InRange<double>(item.DewPoint, 6.9, 7.1);
            Assert.InRange<double>(item.Rain, 0.9, 1.1);
            Assert.Equal(2798, item.FreezingLevel);
            Assert.Equal(3U, item.UVIndex);
            Assert.InRange<double>(item.CloudCoverageTotal, 90.9, 91.1);
            Assert.InRange<double>(item.CloudCoverageLow, 1.9, 2.1);
            Assert.InRange<double>(item.CloudCoverageMid, 77.9, 78.1);
            Assert.InRange<double>(item.CloudCoverageHigh, 89.9, 90.1);
            Assert.InRange<double>(item.Humidity, 62.9, 63.1);
            Assert.InRange<double>(item.WindSpeed, 5.9, 6.1);
            Assert.InRange<double>(item.PressureAtSeaLevel, 1017, 1018);
            Assert.InRange<double>(item.WindGustSpeed, 5.9, 6.1);
            Assert.InRange<double>(item.WindDirection, 96.9, 97.1);
            Assert.Equal("E", item.WindLetter);
            Assert.Equal("PC", item.Icon);
            Assert.Equal("Partly Cloudy", item.IconName);
            Assert.InRange<double>(item.ChanceOfRain, 2.9, 3.1);
            Assert.InRange<double>(item.ChanceOfSnow, 3.9, 4.1);
            Assert.Equal(5, item.Sunrise.Hour);
            Assert.Equal(52, item.Sunrise.Minute);
            Assert.Equal(18, item.Sunset.Hour);
            Assert.Equal(59, item.Sunset.Minute);
            Assert.Equal(10, item.TimeStamp.Hour);
            Assert.Equal(0, item.TimeStamp.Minute);

            Assert.True(item.IsDayTime);
        }

        [Fact]
        public void TestDeserializeResponse1()
        {
            string path = Asset.PathForResource("ExampleResponse1.txt");
            string response = System.IO.File.ReadAllText(path);
            Assert.True(response.Length > 0);

            ForecastBody data = JsonSerializer.Deserialize<ForecastBody>(response);

            Assert.Equal(154, data.MetData.Forecast.Forecasts.Count);
        }
    }
}
