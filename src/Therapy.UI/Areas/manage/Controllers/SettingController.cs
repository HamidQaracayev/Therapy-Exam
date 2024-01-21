using Microsoft.AspNetCore.Mvc;
using Therapy.Business.CustomExceptions;
using Therapy.Business.Services.Interfaces;
using Therapy.Core.Models;

namespace Therapy.UI.Areas.manage.Controllers
{
    [Area("manage")]
    public class SettingController : Controller
    {
        private readonly ISettingService _settingservice;

        public SettingController(ISettingService settingservice)
        {
            _settingservice = settingservice;
        }

        public async Task<IActionResult> Index()
        {
            var settings = await  _settingservice.GetAll();
            return View(settings);
        }
        public async Task<IActionResult> Update(int id)
        {
            if(id<=0 && id==null) return NotFound();
            var existSetting = await _settingservice.GetById(id);
            if(existSetting == null) return NotFound();
            return View(existSetting);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Settings settings)
        {
            if (!ModelState.IsValid) { return View(); }
            try
            {
                await _settingservice.Update(settings);
            }
            catch (EntityIsNullException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View();
            }
            return View("Index");
        }
    }
}
