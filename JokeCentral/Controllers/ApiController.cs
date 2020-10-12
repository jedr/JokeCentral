using System.Threading.Tasks;
using JokeCentral.Api;
using Microsoft.AspNetCore.Mvc;

namespace JokeCentral.Controllers
{
    public class ApiController : Controller
    {
        public async Task<string> Index()
        {
            var joke = await new JokeService().GetJokeAsync();
            return joke.Text;
        }
    }
}
