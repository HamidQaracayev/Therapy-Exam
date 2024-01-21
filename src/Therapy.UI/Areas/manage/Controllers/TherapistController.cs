using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Therapy.Business.CustomExceptions;
using Therapy.Business.Services.Interfaces;
using Therapy.Core.Models;
using Therapy.Data.DAL;

namespace Therapy.UI.Areas.manage.Controllers
{
    [Area("manage")]
    [Authorize(Roles ="Admin")]
    public class TherapistController : Controller
    {
        private readonly ITherapistService _therapistservice;
        private readonly AppDbContext _context;

        public TherapistController(ITherapistService therapistservice,AppDbContext context)
        {
            _therapistservice = therapistservice;
            _context = context;
        }

        public IActionResult Index()
        {
            List<Therapist> therapist = _context.Therapists.ToList();
            return View(therapist);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Therapist therapist)
        {
            if(!ModelState.IsValid) { return View(); }
            try
            {
                await _therapistservice.CreateAsync(therapist);
            }
            catch (EntityIsNullException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View();
            }
            catch (ContentTypeNotValidException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View();
            }
            catch (InvalidImageSizeException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View();
            }
            catch (ImageIsNullException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View();
            }
            return RedirectToAction("Index");


        }
        public async Task<IActionResult> Update(int id)
        {
            if (id <= 0 || id == null) return NotFound();
            var existTherapist = await _therapistservice.GetById(id);
            if(existTherapist == null) return NotFound();
            return View(existTherapist);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Therapist therapist)
        {
            if (!ModelState.IsValid) { return View(); }

            try
            {
                await _therapistservice.UpdateAsync(therapist);
            }
            catch (EntityIsNullException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View();

            }
            catch (ContentTypeNotValidException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View();
            }
            catch (InvalidImageSizeException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View();
            }
            catch (ImageIsNullException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View();
            }

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0 || id == null) return NotFound();
            try
            {
               await  _therapistservice.Delete(id);
            }
            catch (IdBelowZero ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message); return View();
            }
            catch (EntityIsNullException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message); return View();
            }

            return RedirectToAction("Index");
        }

    }
}
