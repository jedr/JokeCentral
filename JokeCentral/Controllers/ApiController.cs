using JokeCentral.Api;
using Microsoft.AspNetCore.Mvc;

namespace JokeCentral.Controllers
{
    public class ApiController : Controller
    {
        public string Index()
        {
            return new JokeService().GetJoke().Text;
        }
    }
}
