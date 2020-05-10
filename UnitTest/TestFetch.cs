
using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Xunit;

using MetCheckAPI;


namespace UnitTest
{
    public class TestFetch
    {
        [Fact]
        public async void TestGet()
        {
            var location = ForecastRequestLocation.Point((float)50.9, -1);

            ForecastBody? response = await Forecaster.Fetch(location);

            Assert.NotNull(response);
            Assert.NotNull(response?.MetData);
            Assert.NotNull(response?.MetData.Forecast);
            Assert.InRange(response?.MetData.Forecast.Forecasts.Count ?? 0, 1, 10000);
        }

        [Fact]
        public async void TestTypeGetAstronomy()
        {
            var location = ForecastRequestLocation.Point((float)50.9, -1);

            ForecastBody? response = await Forecaster.Fetch(location, ForecastRequestType.Astronomy);

            Assert.NotNull(response);
            Assert.NotNull(response?.MetData);
            Assert.NotNull(response?.MetData.Forecast);
            Assert.InRange(response?.MetData.Forecast.Forecasts.Count ?? 0, 1, 10000);

            ForecastSnapshot? snapshot = response?.MetData.Forecast.Forecasts[0];

            Assert.NotNull(snapshot);
            Assert.NotNull(snapshot?.SeeingIndex);
            Assert.NotNull(snapshot?.PickeringIndex);
            Assert.NotNull(snapshot?.TransIndex);
        }

        [Fact]
        public async void TestTypeGetAviation()
        {
            var location = ForecastRequestLocation.Point((float)50.9, -1);

            ForecastBody? response = await Forecaster.Fetch(location, ForecastRequestType.Aviation);

            Assert.NotNull(response);
            Assert.NotNull(response?.MetData);
            Assert.NotNull(response?.MetData.Forecast);
            Assert.InRange(response?.MetData.Forecast.Forecasts.Count ?? 0, 1, 10000);

            ForecastSnapshot? snapshot = response?.MetData.Forecast.Forecasts[0];

            Assert.NotNull(snapshot);
            Assert.NotNull(snapshot?.CumulusBaseHeight);
            Assert.NotNull(snapshot?.StratusBaseHeight);
        }

        [Fact]
        public async void TestTypeGetFishing()
        {
            var location = ForecastRequestLocation.Point((float)50.9, -1);

            ForecastBody? response = await Forecaster.Fetch(location, ForecastRequestType.Fishing);

            Assert.NotNull(response);
            Assert.NotNull(response?.MetData);
            Assert.NotNull(response?.MetData.Forecast);
            Assert.InRange(response?.MetData.Forecast.Forecasts.Count ?? 0, 1, 10000);

            ForecastSnapshot? snapshot = response?.MetData.Forecast.Forecasts[0];

            Assert.NotNull(snapshot);
            Assert.NotNull(snapshot?.FishingIndex);
        }

        [Fact]
        public async void TestTypeGetSoil()
        {
            var location = ForecastRequestLocation.Point((float)50.9, -1);

            ForecastBody? response = await Forecaster.Fetch(location, ForecastRequestType.Soil);

            Assert.NotNull(response);
            Assert.NotNull(response?.MetData);
            Assert.NotNull(response?.MetData.Forecast);
            Assert.InRange(response?.MetData.Forecast.Forecasts.Count ?? 0, 1, 10000);

            ForecastSnapshot? snapshot = response?.MetData.Forecast.Forecasts[0];

            Assert.NotNull(snapshot);
            Assert.NotNull(snapshot?.EvapoTranspiration);
            Assert.NotNull(snapshot?.SoilMoisture10mm);
            Assert.NotNull(snapshot?.SoilMoisture100mm);
            Assert.NotNull(snapshot?.SoilMoisture400mm);
        }

        [Fact]
        public async void TestTypeGetStorm()
        {
            var location = ForecastRequestLocation.Point((float)50.9, -1);

            ForecastBody? response = await Forecaster.Fetch(location, ForecastRequestType.Storm);

            Assert.NotNull(response);
            Assert.NotNull(response?.MetData);
            Assert.NotNull(response?.MetData.Forecast);
            Assert.InRange(response?.MetData.Forecast.Forecasts.Count ?? 0, 1, 10000);

            ForecastSnapshot? snapshot = response?.MetData.Forecast.Forecasts[0];

            Assert.NotNull(snapshot);
            Assert.NotNull(snapshot?.StormRisk);
            Assert.NotNull(snapshot?.TornadoRisk);
        }

        [Fact]
        public async void TestTypeGetClothesDrying()
        {
            var location = ForecastRequestLocation.Point((float)50.9, -1);

            ForecastBody? response = await Forecaster.Fetch(location, ForecastRequestType.ClothesDrying);

            Assert.NotNull(response);
            Assert.NotNull(response?.MetData);
            Assert.NotNull(response?.MetData.Forecast);
            Assert.InRange(response?.MetData.Forecast.Forecasts.Count ?? 0, 1, 10000);

            ForecastSnapshot? snapshot = response?.MetData.Forecast.Forecasts[0];

            Assert.NotNull(snapshot);
            Assert.NotNull(snapshot?.DryingTimeLight);
            Assert.NotNull(snapshot?.DryingTimeHeavy);
        }
    }
}
