using Microsoft.AspNetCore.Mvc;

namespace PaymentGateway.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
