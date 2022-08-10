using Microsoft.AspNetCore.Mvc;

namespace Filmes_API.Controllers
{
    public class FilmeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
