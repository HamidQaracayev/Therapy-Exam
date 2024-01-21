using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Therapy.Business.ViewModel;
using Therapy.Core.Models;
using Therapy.Data.DAL;

namespace Therapy.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            HomeViewModel vm = new HomeViewModel()
            {
                Therapist = _context.Therapists.ToList(),
            };
            return View(vm);
        }

        
    }
}