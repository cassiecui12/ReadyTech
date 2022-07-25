using CoffeeApp.Services;
using System.Text.Json;
using CoffeeApp.Exceptions;

namespace CoffeeApp.Test
{
    public class CoffeeServiceTests
    {
        [Fact]
        public void WhenCountNotDivisibleByFiveAndDateNowAprilFirstShouldReturnString()
        {
            byte count = 1;
            DateTime dateTime = new(2022, 1, 1);
            var response = CoffeeService.BrewCoffee(count, dateTime);

            string expected = JsonSerializer.Serialize(new
            {
                message = "Your piping hot coffee is ready",
                prepared = dateTime.ToString("s")
            });

            Assert.Equal(expected, response);
        }

        [Fact]
        public void WhenDateIsAprilFirstShouldThrowTeapotException()
        {
            byte count = 1;
            DateTime dateTime = new(2022, 4, 1);
            var action = () => CoffeeService.BrewCoffee(count, dateTime);

            Assert.Throws<TeapotException>(action);
        }

        [Fact]
        public void WhenCountDivisibleByFiveShouldThrowFifthCallException()
        {
            byte count = 5;
            DateTime dateTime = new(2022, 4, 1);
            var action = () => CoffeeService.BrewCoffee(count, dateTime);

            Assert.Throws<FifthCallException>(action);
        }
    }
}