using System.Threading.Tasks;
using JokeCentral.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace JokeCentral.Controllers
{
    public class ApiController : Controller
    {
        private ILogger<ApiController> logger;

        public ApiController(ILogger<ApiController> logger)
        {
            this.logger = logger;
        }

        public async Task<string> Index()
        {
            var joke = await new JokeService().GetJokeAsync();
            this.logger.LogInformation("Joke: {0}", joke.Text);
            return joke.Text;
        }
    }
}
