using Microsoft.AspNetCore.Mvc;

namespace PAPSPNEW.Controllers
{
    public class RestauranteController : Controller
    {
        public IActionResult Restaurante()
        {
            return View();
        }
    }
}
