using Microsoft.AspNetCore.Mvc;

namespace Therapy.UI.Areas.manage.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
