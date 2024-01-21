using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Therapy.Core.Models;

namespace Therapy.UI.Controllers
{
    public class HomeController : Controller
    {
        

        public IActionResult Index()
        {
            return View();
        }

        
    }
}