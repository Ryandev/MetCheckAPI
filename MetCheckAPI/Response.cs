
///-----------------------------------------------------------------
///   Namespace:      MetCheckAPI
///   Description:    Contains definitions of JSON responses from API
///-----------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;

using MetCheckAPI.Private;


namespace MetCheckAPI
{
    public struct ForecastBody
    {
        [JsonPropertyName("feedCreation")]
        public DateTime TimeStamp { get; set; }

        [JsonPropertyName("metcheckData")]
        public ForecastMetData MetData { get; set; }

        public override string ToString()
        {
            return $"<ResponseBody Date={TimeStamp} MetData={MetData}>";
        }
    }

    public struct ForecastMetData
    {
        [JsonPropertyName("forecastLocation")]
        public ForecastSummary Forecast { get; set; }

        public override string ToString()
        {
            return $"<ResponseMetData ForeCast={Forecast}>";
        }
    }

    public struct ForecastSummary
    {
        [JsonPropertyName("forecast")]
        public List<ForecastSnapshot> Forecasts { get; set; }

        [JsonPropertyName("continent")]
        public string Continent { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("location")]
        public string LocationName { get; set; }

        [JsonPropertyName("latitude")]
        public float Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public float Longitude { get; set; }

        public override string ToString()
        {
            StringBuilder sbForecasts = new StringBuilder();

            foreach ( ForecastSnapshot snapshot in Forecasts )
            {
                sbForecasts.Append(snapshot.ToString());
                sbForecasts.Append(", \n");
            }

            return $"<ResponseForecast ForeCasts:{sbForecasts}";
        }
    }

    public struct ForecastSnapshot
    {
        /// <summary>Temperature</summary>
        /// <remarks>Value is expressed in degrees celcius</remarks>
        [JsonPropertyName("temperature")]
        [JsonConverter(typeof(StringFloatConverter))]
        public float Temperature { get; set; }

        /// <remarks>Value is expressed in degrees celcius</remarks>
        [JsonPropertyName("dewpoint")]
        [JsonConverter(typeof(StringFloatConverter))]
        public float DewPoint { get; set; }

        /// <remarks>Value is expressed in mm/hr</remarks>
        [JsonPropertyName("rain")]
        [JsonConverter(typeof(StringFloatConverter))]
        public float Rain { get; set; }

        /// <remarks>Value is expressed in meters</remarks>
        [JsonPropertyName("freezinglevel")]
        [JsonConverter(typeof(StringInt32Converter))]
        public Int32 FreezingLevel { get; set; }

        /// <remarks>Value is expressed from 1 to 10</remarks>
        [JsonPropertyName("uvIndex")]
        [JsonConverter(typeof(StringUInt32Converter))]
        public UInt32 UVIndex { get; set; }

        /// <remarks>Value is expressed in percent where 0=0% & 100=100%</remarks>
        [JsonPropertyName("totalcloud")]
        [JsonConverter(typeof(StringFloatConverter))]
        public float CloudCoverageTotal { get; set; }

        /// <remarks>Value is expressed in percent where 0=0% & 100=100%</remarks>
        [JsonPropertyName("highcloud")]
        [JsonConverter(typeof(StringFloatConverter))]
        public float CloudCoverageHigh { get; set; }

        /// <remarks>Value is expressed in percent where 0=0% & 100=100%</remarks>
        [JsonPropertyName("medcloud")]
        [JsonConverter(typeof(StringFloatConverter))]
        public float CloudCoverageMid { get; set; }

        /// <remarks>Value is expressed in percent where 0=0% & 100=100%</remarks>
        [JsonPropertyName("lowcloud")]
        [JsonConverter(typeof(StringFloatConverter))]
        public float CloudCoverageLow { get; set; }

        /// <remarks>Value is expressed in percent where 0=0% & 100=100%</remarks>
        [JsonPropertyName("humidity")]
        [JsonConverter(typeof(StringFloatConverter))]
        public float Humidity { get; set; }

        /// <remarks>Value is expressed in mph</remarks>
        [JsonPropertyName("windspeed")]
        [JsonConverter(typeof(StringFloatConverter))]
        public float WindSpeed { get; set; }

        /// <remarks>Value is expressed in millibars</remarks>
        [JsonPropertyName("meansealevelpressure")]
        [JsonConverter(typeof(StringFloatConverter))]
        public float PressureAtSeaLevel { get; set; }

        /// <remarks>Value is expressed in mph</remarks>
        [JsonPropertyName("windgustspeed")]
        [JsonConverter(typeof(StringFloatConverter))]
        public float WindGustSpeed { get; set; }

        /// <summary>Direction of Wind</summary>
        /// <remarks>Value is expressed in degrees</remarks>
        [JsonPropertyName("winddirection")]
        [JsonConverter(typeof(StringFloatConverter))]
        public float WindDirection { get; set; }

        /// <summary>Direction of Wind</summary>
        /// <remarks>e.g E = East, ESE = EastSouthEast</remarks>
        [JsonPropertyName("windletter")]
        public string WindLetter { get; set; }

        [JsonPropertyName("icon")]
        public string Icon { get; set; }

        [JsonPropertyName("iconName")]
        public string IconName { get; set; }

        /// <summary>Propbability rain will occur</summary>
        /// <remarks>Value is expressed in percent where 0=0% & 100=100%</remarks>
        [JsonPropertyName("chanceofrain")]
        [JsonConverter(typeof(StringFloatConverter))]
        public float ChanceOfRain { get; set; }

        /// <summary>Propbability snow will occur</summary>
        /// <remarks>Value is expressed in percent where 0=0% & 100=100%</remarks>
        [JsonPropertyName("chanceofsnow")]
        [JsonConverter(typeof(StringFloatConverter))]
        public float ChanceOfSnow { get; set; }

        [JsonIgnore]
        /// <summary>DateTime Sunrise will occur</summary>
        public DateTime Sunrise
        {
            get
            {
                DateTime beginningOfDay = new DateTime(TimeStamp.Year, TimeStamp.Month, TimeStamp.Day);
                return beginningOfDay.Add(SunriseOffset);
            }
        }

        [JsonIgnore]
        /// <summary>DateTime Sunset will occur</summary>
        public DateTime Sunset
        {
            get
            {
                DateTime beginningOfDay = new DateTime(TimeStamp.Year, TimeStamp.Month, TimeStamp.Day);
                return beginningOfDay.Add(SunsetOffset);
            }
        }

        /// <summary>DateTime forecast is for</summary>
        [JsonPropertyName("utcTime")]
        public DateTime TimeStamp { get; set; }

        /// <summary>TimeSpan from midnight Sunrise will occur</summary>
        [JsonPropertyName("sunrise")]
        [JsonConverter(typeof(YYMMToTimeSpanConverter))]
        public TimeSpan SunriseOffset { get; set; }

        /// <summary>TimeSpan from midnight Sunset will occur</summary>
        [JsonPropertyName("sunset")]
        [JsonConverter(typeof(YYMMToTimeSpanConverter))]
        public TimeSpan SunsetOffset { get; set; }

        /// <summary>No documentation available, see referenced link</summary>
        /// <remarks>Only set if #Forecaster.Fetch is Called with ForecastRequestType.Astronomy</remarks>
        /// <see cref="https://www.metcheck.com/OTHER/json_data.asp"/>
        [JsonPropertyName("seeingIndex")]
        [JsonConverter(typeof(StringFloatNullableConverter))]
        public float? SeeingIndex { get; set; }

        /// <summary>No documentation available, see referenced link</summary>
        /// <remarks>Only set if #Forecaster.Fetch is Called with ForecastRequestType.Astronomy</remarks>
        /// <see cref="https://www.metcheck.com/OTHER/json_data.asp"/>
        [JsonPropertyName("pickeringIndex")]
        [JsonConverter(typeof(StringFloatNullableConverter))]
        public float? PickeringIndex { get; set; }

        /// <summary>No documentation available, see referenced link</summary>
        /// <remarks>Only set if #Forecaster.Fetch is Called with ForecastRequestType.Astronomy</remarks>
        /// <see cref="https://www.metcheck.com/OTHER/json_data.asp"/>
        [JsonPropertyName("transIndex")]
        [JsonConverter(typeof(StringFloatNullableConverter))]
        public float? TransIndex { get; set; }

        /// <summary>Height from ground from start of Cumulus clouds in meters</summary>
        /// <remarks>Only set if #Forecaster.Fetch is Called with ForecastRequestType.Aviation</remarks>
        /// <see cref="https://www.metcheck.com/OTHER/json_data.asp"/>
        [JsonPropertyName("cumulusBaseHeight")]
        [JsonConverter(typeof(StringFloatNullableConverter))]
        public float? CumulusBaseHeight { get; set; }

        /// <summary>Height from ground from start of Status clouds in meters</summary>
        /// <remarks>Only set if #Forecaster.Fetch is Called with ForecastRequestType.Aviation</remarks>
        /// <see cref="https://www.metcheck.com/OTHER/json_data.asp"/>
        [JsonPropertyName("stratusBaseHeight")]
        [JsonConverter(typeof(StringFloatNullableConverter))]
        public float? StratusBaseHeight { get; set; }

        /// <summary>Likelyhood of successful fishing</summary>
        /// <remarks>Only set if #Forecaster.Fetch is Called with ForecastRequestType.Fishing</remarks>
        /// <see cref="https://www.metcheck.com/OTHER/json_data.asp"/>
        [JsonPropertyName("fishingIndex")]
        public string? FishingIndex { get; set; }

        /// <summary>No documentation available, see referenced link</summary>
        /// <remarks>Only set if #Forecaster.Fetch is Called with ForecastRequestType.Soil</remarks>
        /// <see cref="https://www.metcheck.com/OTHER/json_data.asp"/>
        [JsonPropertyName("evapoTranspiration")]
        [JsonConverter(typeof(StringFloatNullableConverter))]
        public float? EvapoTranspiration { get; set; }

        /// <summary>No documentation available, see referenced link</summary>
        /// <remarks>Only set if #Forecaster.Fetch is Called with ForecastRequestType.Soil</remarks>
        /// <see cref="https://www.metcheck.com/OTHER/json_data.asp"/>
        [JsonPropertyName("soilMoisture1.0cm")]
        public string? SoilMoisture10mm { get; set; }

        /// <summary>No documentation available, see referenced link</summary>
        /// <remarks>Only set if #Forecaster.Fetch is Called with ForecastRequestType.Soil</remarks>
        /// <see cref="https://www.metcheck.com/OTHER/json_data.asp"/>
        [JsonPropertyName("soilMoisture10cm")]
        public string? SoilMoisture100mm { get; set; }

        /// <summary>No documentation available, see referenced link</summary>
        /// <remarks>Only set if #Forecaster.Fetch is Called with ForecastRequestType.Soil</remarks>
        /// <see cref="https://www.metcheck.com/OTHER/json_data.asp"/>
        [JsonPropertyName("soilMoisture40cm")]
        public string? SoilMoisture400mm { get; set; }

        /// <summary>Storm Risk</summary>
        /// <remarks>Only set if #Forecaster.Fetch is Called with ForecastRequestType.Storm</remarks>
        /// <see cref="https://www.metcheck.com/OTHER/json_data.asp"/>
        [JsonPropertyName("stormRisk")]
        public string? StormRisk { get; set; }

        /// <summary>Tornado Risk</summary>
        /// <remarks>Only set if #Forecaster.Fetch is Called with ForecastRequestType.Storm</remarks>
        /// <see cref="https://www.metcheck.com/OTHER/json_data.asp"/>
        [JsonPropertyName("tornadoRisk")]
        public string? TornadoRisk { get; set; }

        /* clothes drying */
        /// <summary>Outside Clothes Drying Time 'Light'</summary>
        /// <remarks>Only set if #Forecaster.Fetch is Called with ForecastRequestType.ClothesDrying</remarks>
        /// <see cref="https://www.metcheck.com/OTHER/json_data.asp"/>
        [JsonPropertyName("dryingTimeLight")]
        public string? DryingTimeLight { get; set; }

        /// <summary>Outside Clothes Drying Time 'Heavy'</summary>
        /// <remarks>Only set if #Forecaster.Fetch is Called with ForecastRequestType.ClothesDrying</remarks>
        /// <see cref="https://www.metcheck.com/OTHER/json_data.asp"/>
        [JsonPropertyName("dryingTimeHeavy")]
        public string? DryingTimeHeavy { get; set; }

        [JsonIgnore]
        public bool IsDayTime => TimeStamp > Sunrise && TimeStamp < Sunset;

        [JsonIgnore]
        public bool IsNightTime => IsDayTime == false;

        public override string ToString()
        {
            StringBuilder sbProps = new StringBuilder();
            foreach (PropertyInfo prop in typeof(ForecastSnapshot).GetProperties())
            {
                sbProps.Append(prop.Name);
                sbProps.Append("=");
                sbProps.Append(prop.GetValue(this) ?? "None");
                sbProps.Append(", ");
            }

            return $"<ForecastSnapshot {sbProps}>";
        }
    }
}
