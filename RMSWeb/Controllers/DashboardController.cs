using Microsoft.AspNetCore.Mvc;

namespace RMSWeb.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
