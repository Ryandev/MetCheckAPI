
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using MetCheckAPI;


namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter latitude:");
            string latitudeStr = Console.ReadLine();
            double latitude = 0;

            if (double.TryParse(latitudeStr, out latitude) == false)
            {
                latitude = 50.9;
                Console.WriteLine($"Failed to parse longitude. Using value {latitude}");
            }

            Console.WriteLine("Enter longitude:");
            string longitudeStr = Console.ReadLine();
            double longitude = -1;

            if (double.TryParse(longitudeStr, out longitude) == false)
            {
                longitude = -1;
                Console.WriteLine($"Failed to parse longitude. Using value {longitude}");
            }

            Run(latitude, longitude).GetAwaiter().GetResult();
        }

        static public async Task Run(double latitude, double longitude)
        {
            Console.WriteLine($"Fetching location data {latitude},{longitude}...");
            ForecastBody? forecast = await Forecaster.Fetch(latitude, longitude);
            Console.WriteLine(forecast?.ToString() ?? "Forecast fetch failed");
        }

    }
}
