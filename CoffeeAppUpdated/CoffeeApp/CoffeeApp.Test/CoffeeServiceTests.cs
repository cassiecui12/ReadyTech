using CoffeeApp.Services;
using System.Text.Json;
using CoffeeApp.Exceptions;

namespace CoffeeApp.Test
{
    public class CoffeeServiceTests
    {
        [Fact]
        public async Task WhenCountNotDivisibleByFiveAndDateNowAprilFirstShouldReturnString()
        {
            byte count = 1;
            DateTime dateTime = new(2022, 1, 1);
            var response = await CoffeeService.BrewCoffee(count, dateTime);

            string expected = JsonSerializer.Serialize(new
            {
                message = "Your piping hot coffee is ready",
                prepared = dateTime.ToString("s")
            });

            Assert.Equal(expected, response);
        }

        [Fact]
        public async Task WhenDateIsAprilFirstShouldThrowTeapotException()
        {
            byte count = 1;
            DateTime dateTime = new(2022, 4, 1);
            var action = async () => await CoffeeService.BrewCoffee(count, dateTime);

            await Assert.ThrowsAsync<TeapotException>(action);
        }

        [Fact]
        public async Task WhenCountDivisibleByFiveShouldThrowFifthCallException()
        {
            byte count = 5;
            DateTime dateTime = new(2022, 4, 1);
            var action = async () => await CoffeeService.BrewCoffee(count, dateTime);

            await Assert.ThrowsAsync<FifthCallException>(action);
        }
    }
}