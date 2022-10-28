using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class FacturacionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
