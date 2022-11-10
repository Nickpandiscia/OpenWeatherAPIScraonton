using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace OpenWeatherMapAPI
{
    public class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();
            Console.WriteLine("Please enter your API key...");
            var userAPI = Console.ReadLine();

            while (true)
            {
                Console.WriteLine("Hit enter to continue...");
                var lat = 41.4090;
                var lon = 75.6624;
                var cityName = Console.ReadLine();
                var weatherURL = $"https://api.openweathermap.org/data/3.0/onecall?lat={lat}&lon={lon}&appid={userAPI}";

                var response = client.GetStringAsync(weatherURL).Result;
                var formattedResponse = JObject.Parse(response).GetValue("daily").ToString();

                Console.WriteLine(formattedResponse);
                Console.ReadLine();



            }

        }
    }
}
