using System.Text.Json.Serialization;

namespace CoffeeApp.Models
{
    public class TemperatureResponse
    {
        [JsonPropertyName("current_weather")]
        public CurrentWeather CurrentWeather { get; set; }
    }
    public class CurrentWeather
    {
        [JsonPropertyName("temperature")]
        public float Temperature { get; set; }
    }
}