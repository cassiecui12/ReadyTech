using CoffeeApp.Exceptions;
using Microsoft.AspNetCore.Mvc;
using CoffeeApp.Services;
using CoffeeApp;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("brew-coffee")]
    public class CoffeeController : ControllerBase
    {
        public CoffeeController()
        {
        }

        [HttpGet]
        public async Task<IActionResult> BrewCoffee()
        {
            try
            {
                Startup.Count++;
                string response = await CoffeeService.BrewCoffee(Startup.Count, DateTime.Now);
                return new ContentResult
                {
                    StatusCode = 200,
                    Content = response,
                    ContentType = "text/plain",
                };
            }
            catch (FifthCallException)
            {
                Startup.Count = 0;
                return new ContentResult
                {
                    StatusCode = 503,
                    ContentType = "text/plain",
                };
            }
            catch (TeapotException)
            {
                return new ContentResult
                {
                    StatusCode = 418,
                    ContentType = "text/plain",
                };
            }
            catch (Exception ex)
            {
                return new ContentResult
                {
                    StatusCode = 500,
                    Content = ex.Message,
                    ContentType = "text/plain",
                };
            }
        }
    }
}