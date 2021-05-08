using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace UnderstandingHttp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using var httpClient = new HttpClient();

            var json = await httpClient.GetStringAsync("https://localhost:5001/WeatherForecast");

            var forecasts = JsonConvert.DeserializeObject<IEnumerable<Forecast>>(json);

            foreach (var forecast in forecasts)
            {
                Console.WriteLine($"{forecast.Date.DayOfWeek}:\t{forecast.TemperatureC}°C\t{forecast.Summary}");
            }

            //var response = await httpClient.GetAsync("https://localhost:5001/WeatherForecast");
            //await ProcessResponse(response);
        }

        private static async Task ProcessResponse(HttpResponseMessage response)
        {
            WriteReponseInfo(response);

            var hasContent = response.Content.Headers.ContentLength != null;

            if (!hasContent)
            {
                Console.WriteLine("No content");
                return;
            }

            var json = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Body:\n{json}");
        }

        static void WriteReponseInfo(HttpResponseMessage response)
        {
            Console.WriteLine($"Status code: {response.StatusCode} ({(int)response.StatusCode})");
            Console.WriteLine($"Is successful: {response.IsSuccessStatusCode}");
            Console.WriteLine($"Content length: {response.Content.Headers.ContentLength}");
            Console.WriteLine($"Content encoding: {response.Content.Headers.ContentType}");
        }
    }
}
