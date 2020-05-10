
///-----------------------------------------------------------------
///   Namespace:      MetCheckAPI
///   Description:    Point of public access for Library consumers
///-----------------------------------------------------------------

using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;

using MetCheckAPI.Private;


namespace MetCheckAPI
{
    public enum ForecastRequestType
    {
        Normal,
        Astronomy,
        Fishing,
        Aviation,
        Soil,
        Storm,
        ClothesDrying,
    }

    public struct ForecastRequestLocation
    {
        public float Latitude { get; set; }
        public float Longitude { get; set; }

        public static ForecastRequestLocation Point(float latitude, float longitude)
        {
            return new ForecastRequestLocation()
            {
                Latitude = latitude,
                Longitude = longitude,
            };
        }
    }

    public sealed class Forecaster
    {
        public static async Task<ForecastBody?> Fetch(double latitude, double longitude, ForecastRequestType requestType = ForecastRequestType.Normal)
        {
            ForecastRequestLocation location = ForecastRequestLocation.Point((float)latitude, (float)longitude);
            return await Fetch(location, requestType);
        }

        public static async Task<ForecastBody?> Fetch(float latitude, float longitude, ForecastRequestType requestType = ForecastRequestType.Normal)
        {
            ForecastRequestLocation location = ForecastRequestLocation.Point(latitude, longitude);
            return await Fetch(location, requestType);
        }

        public static async Task<ForecastBody?> Fetch(ForecastRequestLocation location, ForecastRequestType requestType=ForecastRequestType.Normal)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", FetchSettings.UserAgent);

            string response = await client.GetStringAsync(_FetchUrlForLocation(location, requestType));

            ForecastBody? data = null;

            if ( response.Length > 0 )
            {
                data = JsonSerializer.Deserialize<ForecastBody>(response);
            }

            return data;
        }

        private static string _FetchUrlForLocation(ForecastRequestLocation location, ForecastRequestType requestType)
        {
            UriBuilder uriBuilder = new UriBuilder
            {
                Scheme = FetchSettings.Scheme,
                Host = FetchSettings.Host,
                Path = FetchSettings.Path
            };

            var query = HttpUtility.ParseQueryString("");

            query["lat"] = location.Latitude.ToString();
            query["lon"] = location.Longitude.ToString();
            query["Fc"] = requestType.UrlRequestParameter();

            uriBuilder.Query = query.ToString();

            string url = uriBuilder.ToString();

            return url;
        }
    }

}
