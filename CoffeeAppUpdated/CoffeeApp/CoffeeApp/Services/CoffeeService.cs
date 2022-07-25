using CoffeeApp.Exceptions;
using System.Text.Json;

namespace CoffeeApp.Services
{
    public static class CoffeeService
    {
        public static async Task<string> BrewCoffee(byte count, DateTime dateTime)
        {
            if (count % 5 == 0)
            {
                throw new FifthCallException();
            }
            
            if (dateTime.Day == 1 && dateTime.Month == 4)
            {
                throw new TeapotException();
            }

            float temperature = await TemperatureService.GetTemperature();

            string message = temperature > 30 ? 
                "Your refreshing iced coffee is ready" : 
                "Your piping hot coffee is ready";

            return JsonSerializer.Serialize(new
            {
                message = message,
                prepared = dateTime.ToString("s")
            });
        }
    }
}