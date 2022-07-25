using CoffeeApp.Models;
using System.Text.Json;

namespace CoffeeApp.Services
{
    public static class TemperatureService
    {
        public static async Task<float> GetTemperature()
        {
            HttpClient httpClient = new();

            var response = await httpClient.GetAsync("https://api.open-meteo.com/v1/forecast?latitude=-36.8509&longitude=174.7645&current_weather=true");
            string content = await response.Content.ReadAsStringAsync();
            TemperatureResponse result = JsonSerializer.Deserialize<TemperatureResponse>(content)!;
            return result.CurrentWeather.Temperature;
        }
    }
}