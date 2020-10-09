using Microsoft.AspNetCore.Mvc;

namespace JokeCentral.Controllers
{
    public class ApiController : Controller
    {
        public string Index()
        {
            return "You're not completely useless, you can always serve as a bad example.";
        }
    }
}
