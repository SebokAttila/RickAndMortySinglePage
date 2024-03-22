using Microsoft.AspNetCore.Mvc;

namespace RickAndMortySinglePage.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
