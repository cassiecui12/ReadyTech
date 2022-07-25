using CoffeeApp.Exceptions;
using System.Text.Json;

namespace CoffeeApp.Services
{
    public static class CoffeeService
    {
        public static string BrewCoffee(byte count, DateTime dateTime)
        {
            if (count % 5 == 0)
            {
                throw new FifthCallException();
            }
            
            if (dateTime.Day == 1 && dateTime.Month == 4)
            {
                throw new TeapotException();
            }

            return JsonSerializer.Serialize(new
            {
                message = "Your piping hot coffee is ready",
                prepared = dateTime.ToString("s")
            });
        }
    }
}